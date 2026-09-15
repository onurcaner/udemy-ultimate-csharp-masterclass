FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Section14_NumericTypesSuggester/Section14_NumericTypesSuggester.csproj", "Section14_NumericTypesSuggester/"]
RUN dotnet restore "Section14_NumericTypesSuggester/Section14_NumericTypesSuggester.csproj"
COPY . .
WORKDIR "/src/Section14_NumericTypesSuggester"
RUN dotnet build "./Section14_NumericTypesSuggester.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Section14_NumericTypesSuggester.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Section14_NumericTypesSuggester.dll"]
