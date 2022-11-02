FROM public.ecr.aws/lambda/java:11 as with_swagger_codegen_installed
ARG SWAGGER_CODEGEN_VERSION="3.0.35"
RUN yum install -y wget
RUN wget "https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/${SWAGGER_CODEGEN_VERSION}/swagger-codegen-cli-${SWAGGER_CODEGEN_VERSION}.jar" -O swagger-codegen-cli.jar

FROM with_swagger_codegen_installed as with_generated_code
ARG SWAGGER_GENERATED_CODE_LANGUAGE="csharp"
ARG SWAGGER_GENERATED_CODE_FOLDER="./generated-code"
ARG SWAGGER_SERVER_API_DOCS_URL="https://pg-staging.orkesconductor.com/api-docs"
RUN java -jar swagger-codegen-cli.jar generate -l "${SWAGGER_GENERATED_CODE_LANGUAGE}" -i "${SWAGGER_SERVER_API_DOCS_URL}" -o "${SWAGGER_GENERATED_CODE_FOLDER}"
WORKDIR /the/workdir/path

FROM with_generated_code as run_script
COPY ./update_packages.sh ./
RUN ./update_packages.sh
