SWAGGER_API_DOCS_URL="https://pg-staging.orkesconductor.com/api-docs"
LANGUAGE_TO_GENERATE_CODE="csharp"
SWAGGER_GENERATED_CODE_FOLDER="./swagger-code"

function install_dependencies {
    brew install swagger-codegen
}

function generate_code {
    swagger-codegen generate -l "${LANGUAGE_TO_GENERATE_CODE}" -i "${SWAGGER_API_DOCS_URL}" -o "$SWAGGER_GENERATED_CODE_FOLDER"
}

install_dependencies
generate_code
