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

function copy_from_generated_files {
    local source_path="${SWAGGER_GENERATED_CODE_FOLDER}/${SWAGGER_GENERATED_CODE_PACKAGE}/${1}"
    local destination_path="${PACKAGE_PATH}/${1}"
    rm -rf "${destination_path:?}/"*
    echo "deleted all files from ${destination_path}"
    for filename in "${source_path}/"*; do
        cp "${source_path}/${filename}" "${destination_path}/"
    done
    echo "copied code from ${source_path} to ${destination_path}"
}

# function replace_with_sed {
#     sed -i '' -E s/"$1"/"$2"/g "$3"
# }

# function remove_file_header {
#     pattern="${2}"
#     replace="${3}"
#     replace_with_sed "$pattern" "$replace" "$1"
# }

# function replace_import_header {
#     pattern="from swagger_client.api_client import ApiClient"
#     replace="from conductor.client.http.api_client import ApiClient"
#     replace_with_sed "$pattern" "$replace" "$1"
# }

# function replace_authentication {
#     pattern="'api_key'"
#     replace=""
#     replace_with_sed "$pattern" "$replace" "$1"
# }

# function replace_url_api_prefix {
#     pattern="\'\/api"
#     replace="\'"
#     replace_with_sed "$pattern" "$replace" "$1"
# }

function update_client_package_startup {
    echo "starting to update client package"
}

function update_client_package_file {
    local filepath="${1}"
    echo "updating client file: ${filepath}"
}

function update_package_files {
    echo "starting to update package ${package_to_update} files..."
    local package_to_update="${1}"
    local update_package_file_function=${2}
    local startup_function=${3}
    copy_from_generated_files "${package_to_update}"
    if [ ! -z "${startup_function}" ]; then
        ${startup_function}
    fi
    for filename in "${PACKAGE_PATH}/${package_to_update}/"*; do
        local filepath="${PACKAGE_PATH}/${package_to_update}/${filename}"
        do_line_ending_replacement "${filepath}"
        ${update_package_file_function} "${filepath}"
        undo_line_ending_replacement "${filepath}"
        echo "done updating: ${filepath}"
    done
    echo "done updating package ${package_to_update} files"
}

# install_dependencies
# generate_code

update_package_files "Client" update_client_package_file update_client_package_startup
