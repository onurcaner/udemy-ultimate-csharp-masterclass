FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Section12_TicketsDataAggregator/Section12_TicketsDataAggregator.csproj", "Section12_TicketsDataAggregator/"]
RUN dotnet restore "Section12_TicketsDataAggregator/Section12_TicketsDataAggregator.csproj"
COPY . .
WORKDIR "/src/Section12_TicketsDataAggregator"
RUN dotnet build "./Section12_TicketsDataAggregator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Section12_TicketsDataAggregator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Section12_TicketsDataAggregator.dll"]
