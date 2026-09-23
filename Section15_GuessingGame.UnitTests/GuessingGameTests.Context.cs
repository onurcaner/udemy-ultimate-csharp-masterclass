using Moq;
using Moq.Language;
using Section15_GuessingGame.Game;
using Section15_GuessingGame.RandomNumberGenerator;
using Section15_GuessingGame.UserInterface;

namespace Section15_UnitTestsForGuessingGame;

public partial class GuessingGameTests
{
    protected static Mock<IGuessingGameOptions> CreateGameOptionsMock(int minDiceNumber, int maxDiceNumber,
        int maxAllowedTurns)
    {
        Mock<IGuessingGameOptions> gameOptionsMock = new();
        gameOptionsMock.Setup(gameOptions => gameOptions.MinDiceNumber).Returns(minDiceNumber);
        gameOptionsMock.Setup(gameOptions => gameOptions.MaxDiceNumber).Returns(maxDiceNumber);
        gameOptionsMock.Setup(gameOptions => gameOptions.MaxAllowedTurns).Returns(maxAllowedTurns);

        return gameOptionsMock;
    }

    protected static Mock<IRandomNumberGenerator> CreateRandomNumberGeneratorMock(int targetNumber)
    {
        Mock<IRandomNumberGenerator> randomNumberGeneratorMock = new();
        randomNumberGeneratorMock
            .Setup(randomNumberGenerator => randomNumberGenerator.Roll(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(targetNumber);

        return randomNumberGeneratorMock;
    }

    protected static Mock<IUserInterface> CreateUserInterfaceMock(IEnumerable<int> guesses)
    {
        Mock<IUserInterface> userInterfaceStub = new();
        ISetupSequentialResult<int> userInterfaceStubSequence = userInterfaceStub
            .SetupSequence(userInterface => userInterface.ReadInputNumber());

        foreach (int guess in guesses)
        {
            userInterfaceStubSequence.Returns(guess);
        }

        return userInterfaceStub;
    }

    protected static GuessingGame CreateSut(
        int minDiceNumber,
        int maxDiceNumber,
        int maxAllowedTurns,
        int targetNumber,
        IEnumerable<int> guesses
    )
    {
        return GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, maxAllowedTurns, targetNumber, guesses)
            .Sut;
    }

    protected static GuessingGameTestContext CreateGuessingGameWithMocks(
        int minDiceNumber,
        int maxDiceNumber,
        int maxAllowedTurns,
        int targetNumber,
        IEnumerable<int> guesses
    )
    {
        Mock<IGuessingGameOptions> gameOptionsMock =
            GuessingGameTests.CreateGameOptionsMock(minDiceNumber, maxDiceNumber, maxAllowedTurns);
        Mock<IRandomNumberGenerator> randomNumberGeneratorMock =
            GuessingGameTests.CreateRandomNumberGeneratorMock(targetNumber);
        Mock<IUserInterface> userInterfaceMock = GuessingGameTests.CreateUserInterfaceMock(guesses);

        GuessingGame guessingGame =
            new(gameOptionsMock.Object, randomNumberGeneratorMock.Object, userInterfaceMock.Object);

        return new GuessingGameTestContext
        {
            Sut = guessingGame,
            GuessingGameOptionsMock = gameOptionsMock,
            RandomNumberGeneratorMock = randomNumberGeneratorMock,
            UserInterfaceMock = userInterfaceMock
        };
    }

    protected record GuessingGameTestContext
    {
        public required GuessingGame Sut { get; init; }
        public required Mock<IGuessingGameOptions> GuessingGameOptionsMock { get; init; }
        public required Mock<IRandomNumberGenerator> RandomNumberGeneratorMock { get; init; }
        public required Mock<IUserInterface> UserInterfaceMock { get; init; }
    }
}