FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Section09_StarWarsPlanetStats/Section09_StarWarsPlanetStats.csproj", "Section09_StarWarsPlanetStats/"]
RUN dotnet restore "Section09_StarWarsPlanetStats/Section09_StarWarsPlanetStats.csproj"
COPY . .
WORKDIR "/src/Section09_StarWarsPlanetStats"
RUN dotnet build "./Section09_StarWarsPlanetStats.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Section09_StarWarsPlanetStats.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Section09_StarWarsPlanetStats.dll"]
