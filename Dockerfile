FROM mcr.microsoft.com/dotnet/sdk:6.0 AS raw_base_image
RUN mkdir ./package
COPY ./ ./package
WORKDIR /package

FROM raw_base_image AS linter
RUN dotnet format --verify-no-changes ./*.csproj

# FROM raw_base_image AS built_base_image
# RUN [ ! -z "${NUGET_SRC}" ] & \
#     [ ! -z "${NUGET_API_KEY}" ] & \
#     [ ! -z "${PKG_VER}" ]
# RUN dotnet build ./*.csproj

# FROM built_base_image
# RUN dotnet pack -o ./build --include-symbols --include-source -v n -c Release "/p:Version=${PKG_VER}"
# RUN dotnet nuget push -s "${NUGET_SRC}" -k "${NUGET_API_KEY}" "./build/*.symbols.nupkg"
