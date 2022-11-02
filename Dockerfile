FROM mcr.microsoft.com/dotnet/sdk:6.0 AS raw_base_image
RUN mkdir /package
COPY ./Conductor /package/Conductor

FROM raw_base_image AS linter
WORKDIR /package/Conductor
RUN dotnet format --verify-no-changes ./*.csproj

FROM raw_base_image AS build
WORKDIR /package/Conductor
RUN dotnet build ./*.csproj

FROM build AS test
COPY ./Tests /package/Tests
WORKDIR /package/Tests
RUN dotnet test


# RUN [ ! -z "${NUGET_SRC}" ] & \
#     [ ! -z "${NUGET_API_KEY}" ] & \
#     [ ! -z "${PKG_VER}" ]
# RUN dotnet pack -o ./build --include-symbols --include-source -v n -c Release "/p:Version=${PKG_VER}"
# RUN dotnet nuget push -s "${NUGET_SRC}" -k "${NUGET_API_KEY}" "./build/*.symbols.nupkg"
