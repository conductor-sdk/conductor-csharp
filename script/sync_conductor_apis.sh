#!/bin/bash

SWAGGER_API_DOCS_URL="https://pg-staging.orkesconductor.com/api-docs"
LANGUAGE_TO_GENERATE_CODE="csharp"
PACKAGE_PATH="../Conductor"
SWAGGER_GENERATED_CODE_PACKAGE="src/IO.Swagger"

TEMPORARY_FILE="temp.txt"
REPLACEMENT_FOR_LINE_ENDING='\f'
SWAGGER_GENERATED_CODE_FOLDER="./swagger-code"

function install_dependencies {
    brew install swagger-codegen
}

function generate_code {
    swagger-codegen generate -l "${LANGUAGE_TO_GENERATE_CODE}" -i "${SWAGGER_API_DOCS_URL}" -o "$SWAGGER_GENERATED_CODE_FOLDER"
}

function do_line_ending_replacement {
    tr '\n' $REPLACEMENT_FOR_LINE_ENDING <"$1" >"$TEMPORARY_FILE" && mv "$TEMPORARY_FILE" "$1"
}

function undo_line_ending_replacement {
    tr $REPLACEMENT_FOR_LINE_ENDING '\n' <"$1" >"$TEMPORARY_FILE" && mv "$TEMPORARY_FILE" "$1"
}

function remove_empty_lines_prefix_from_file {
    local path="${1}"
    sed -i "" '/./,$!d' "${file}"
}

function replace_package_files {
    local path="${1}"
    local source_path="${SWAGGER_GENERATED_CODE_FOLDER}/${SWAGGER_GENERATED_CODE_PACKAGE}/${path}"
    local destination_path="${PACKAGE_PATH}/${path}"
    echo "starting to replace generated files from ${source_path} to ${destination_path}"
    rm -rf "${destination_path:?}/"*
    echo "deleted all files from ${destination_path}"
    for filename in "${source_path}/"*; do
        cp "${filename}" "${destination_path}/"
    done
    echo "done copying code from ${source_path} to ${destination_path}"
}

function replace_with_sed {
    local filepath="${1}"
    local pattern_regex="$2"
    local replacement="${3}"
    sed -i '' -E s/"${pattern_regex}"/"${replacement}"/g "${filepath}"
}

function remove_header_from_file {
    local filepath="${1}"
    replace_with_sed "${filepath}" "^\/\*.*\*\/" ""
    sed -i '' '/./,$!d' "${filepath}"
}

function replace_namespace_from_file {
    local filepath="${1}"
    replace_with_sed "${filepath}" "IO.Swagger.Client" "Conductor"
}

function update_package_file {
    local path="${1}"
    local update_package_file_function=${2}
    echo "starting to update package file: ${file}"
    do_line_ending_replacement "${file}"
    ${update_package_file_function} "${file}"
    undo_line_ending_replacement "${file}"
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

function update_client_package_startup {
    echo "startup for client package"
}

function update_client_package_file {
    local filepath="${1}"
    remove_header_from_file "${filepath}"
    replace_namespace_from_file "${filepath}"
}

# install_dependencies
# generate_code

update_package "Client" update_client_package_file update_client_package_startup
