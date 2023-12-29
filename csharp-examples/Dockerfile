FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["csharp-examples/csharp-examples.csproj", "csharp-examples/"]
COPY ["Conductor/conductor-csharp.csproj", "Conductor/"]
RUN dotnet restore "./csharp-examples/./csharp-examples.csproj"
COPY . .
WORKDIR "/src/csharp-examples"
RUN dotnet build "./csharp-examples.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./csharp-examples.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "csharp-examples.dll"]