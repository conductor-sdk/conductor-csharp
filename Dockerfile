FROM mcr.microsoft.com/dotnet/sdk:6.0 AS csharp-sdk
RUN mkdir /package
COPY /Conductor /package/Conductor
WORKDIR /package/Conductor

FROM csharp-sdk AS linter
RUN dotnet format --verify-no-changes *.csproj

FROM csharp-sdk AS build
RUN dotnet build *.csproj

FROM build as test
ARG KEY
ARG SECRET
ARG CONDUCTOR_SERVER_URL
ENV KEY=${KEY}
ENV SECRET=${SECRET}
ENV CONDUCTOR_SERVER_URL=${CONDUCTOR_SERVER_URL}
COPY /Tests /package/Tests
WORKDIR /package/Tests
RUN dotnet test -l "console;verbosity=normal"

FROM build as pack_release
COPY /README.md /package/Conductor/README.md
ARG SDK_VERSION
RUN dotnet pack "conductor-csharp.csproj" \
    -o /build \
    --include-symbols \
    --include-source \
    -c Release "/p:Version=${SDK_VERSION}"

FROM pack_release as publish_release
ARG NUGET_SRC
ARG NUGET_API_KEY
RUN dotnet nuget push "/build/*.symbols.nupkg" \
    --source "${NUGET_SRC}" \
    --api-key "${NUGET_API_KEY}"
