FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Section15_GuessingGame.UnitTests/Section15_GuessingGame.UnitTests.csproj", "Section15_GuessingGame.UnitTests/"]
COPY ["Section15_GuessingGame/Section15_GuessingGame.csproj", "Section15_GuessingGame/"]
RUN dotnet restore "Section15_GuessingGame.UnitTests/Section15_GuessingGame.UnitTests.csproj"
COPY . .
WORKDIR "/src/Section15_GuessingGame.UnitTests"

# Build is optional, test will build by default
RUN dotnet build "./Section15_GuessingGame.UnitTests.csproj" -c Release

# Run tests directly
ENTRYPOINT ["dotnet", "test", "./Section15_GuessingGame.UnitTests.csproj", "-c", "Release", "--logger", "console;verbosity=detailed"]