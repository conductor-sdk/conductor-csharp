FROM mcr.microsoft.com/dotnet/sdk:6.0 AS raw_base_image
RUN mkdir /package
COPY /Conductor /package/Conductor
WORKDIR /package/Conductor

FROM raw_base_image AS linter
RUN dotnet format --verify-no-changes ./*.csproj

FROM raw_base_image AS build
RUN dotnet build ./*.csproj

FROM build as build_with_integration_tests_env
ARG SDK_INTEGRATION_TESTS_SERVER_API_URL
ENV SDK_INTEGRATION_TESTS_SERVER_API_URL=${SDK_INTEGRATION_TESTS_SERVER_API_URL}
ARG SDK_INTEGRATION_TESTS_SERVER_KEY_ID
ENV SDK_INTEGRATION_TESTS_SERVER_KEY_ID=${SDK_INTEGRATION_TESTS_SERVER_KEY_ID}
ARG SDK_INTEGRATION_TESTS_SERVER_KEY_SECRET
ENV SDK_INTEGRATION_TESTS_SERVER_KEY_SECRET=${SDK_INTEGRATION_TESTS_SERVER_KEY_SECRET}

FROM build_with_integration_tests_env AS test
COPY /Tests /package/Tests
WORKDIR /package/Tests
RUN dotnet test -l "console;verbosity=normal"

FROM raw_base_image as pack_release
ARG SDK_VERSION
RUN dotnet pack \
    -o ./build \
    --include-symbols \
    --include-source \
    -v n \
    -c Release "/p:Version=${SDK_VERSION}" \
    ./*.csproj

FROM pack_release as publish_release
ARG NUGET_SRC
ARG NUGET_API_KEY
RUN dotnet nuget push \
    -s "${NUGET_SRC}" \
    -k "${NUGET_API_KEY}" \
    "./build/*.symbols.nupkg"
