# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Copiar el frontend al directorio wwwroot (esto es importante)
COPY wwwroot /app/wwwroot


ENTRYPOINT ["dotnet", "ClasificadorComents.dll"]
