#!/bin/bash

GENERATED_CODE_FOLDER="./generated-code/src/IO.Swagger"
PACKAGE_PATH="../Conductor"

function remove_empty_lines_prefix_from_file {
    local path="${1}"
    sed -i "" '/./,$!d' "${file}"
}

function replace_package_files {
    local path="${1}"
    local source_path="${GENERATED_CODE_FOLDER}/${path}"
    local destination_path="${PACKAGE_PATH}/${path}"
    echo "starting to replace generated files from ${source_path} to ${destination_path}"
    rm -rf "${destination_path:?}/"*
    echo "deleted all files from ${destination_path}"
    for filename in "${source_path}/"*; do
        cp "${filename}" "${destination_path}/"
    done
    echo "done copying code from ${source_path} to ${destination_path}"
}

function replace_in_file_with_perl_regex {
    local filepath="${1}"
    local regex="${2}"
    local replacement="${3}"
    perl -pi -e "s/${regex}/${replacement}/gms" "${filepath}"
}

function remove_header_from_file {
    local filepath="${1}"
    local header_regex="\/\*.*?\*\/"
    replace_in_file_with_perl_regex "${filepath}" "${header_regex}" ""
    remove_empty_lines_prefix_from_file "${filepath}"
}

function replace_namespace_from_file {
    local filepath="${1}"
    replace_in_file_with_perl_regex "${filepath}" "IO.Swagger" "Conductor"
}

function replace_default_url_from_file {
    local filepath="${1}"
    old_url="https:\/\/pg-staging.orkesconductor.com\/"
    new_url="https:\/\/play.orkes.io\/"
    replace_in_file_with_perl_regex "${filepath}" "${old_url}" "${new_url}"
}

function update_package_file {
    local path="${1}"
    local update_package_file_function=${2}
    echo "starting to update package file: ${file}"
    ${update_package_file_function} "${file}"
    remove_empty_lines_prefix_from_file "${file}"
    echo "done updating package: ${file}"
}

function update_package_files {
    local package_to_update="${1}"
    local update_package_file_function=${2}
    local path="${PACKAGE_PATH}/${package_to_update}"
    echo "starting to update package files: ${path}"
    for file in "${path}/"*; do
        update_package_file "${file}" ${update_package_file_function}
    done
    echo "done updating package files: ${path}"
}

function update_package {
    local package_to_update="${1}"
    local update_package_file_function=${2}
    local startup_function=${3}
    echo "starting to update package: ${package_to_update}"
    replace_package_files "${package_to_update}"
    if [ -n "${startup_function}" ]; then
        ${startup_function}
    fi
    update_package_files "${package_to_update}" ${update_package_file_function}
    echo "done updating package: ${package_to_update}"
}

function update_client_package_file {
    local filepath="${1}"
    remove_header_from_file "${filepath}"
    replace_namespace_from_file "${filepath}"
    replace_default_url_from_file "${filepath}"
}

function update_api_package_file {
    local filepath="${1}"
    # remove_header_from_file "${filepath}"
    # replace_namespace_from_file "${filepath}"
    # replace_default_url_from_file "${filepath}"
}

update_package "Client" update_client_package_file
update_package "Api" update_api_package_file
