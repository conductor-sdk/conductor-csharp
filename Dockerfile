FROM mcr.microsoft.com/dotnet/sdk:6.0

ARG PKG_VER
ARG NUGET_SRC
ARG NUGET_API_KEY

# Assert All variables are assigned
RUN [ ! -z "${NUGET_SRC}" ] & \
    [ ! -z "${NUGET_API_KEY}" ] & \
    [ ! -z "${PKG_VER}" ]

WORKDIR  /package

COPY ./*.csproj ./*.config ./

RUN dotnet restore

COPY ./ ./

RUN dotnet pack -o ./build --include-symbols --include-source -v n -c Release "/p:Version=${PKG_VER}"
RUN dotnet nuget push -s "${NUGET_SRC}" -k "${NUGET_API_KEY}" "./build/*.symbols.nupkg"
