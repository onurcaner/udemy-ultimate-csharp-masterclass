using Moq;
using Section15_GuessingGame.Game;

namespace Section15_UnitTestsForGuessingGame;

public partial class GuessingGameTests
{
    [TestCase(1, 6, 3, 1, new[] { 1 })]
    [TestCase(1, 6, 3, 1, new[] { 2, 1 })]
    [TestCase(1, 6, 3, 1, new[] { 3, 2, 1 })]
    [TestCase(1, 6, 4, 1, new[] { 4, 3, 2, 1 })]
    [TestCase(1, 6, 5, 1, new[] { 5, 4, 3, 2, 1 })]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    public void Play_ReturnsTrue_WhenUserGuessesCorrectly(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses
    )
    {
        // Arrange
        GuessingGame sut =
            GuessingGameTests.CreateSut(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        bool actualResult = sut.Play();

        // Assert
        Assert.That(actualResult, Is.True);
    }

    [TestCase(1, 6, 1, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    [TestCase(1, 6, 2, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    [TestCase(1, 6, 3, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    [TestCase(1, 6, 4, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    [TestCase(1, 6, 5, 1, new[] { 6, 5, 4, 3, 2, 1 })]
    public void Play_ReturnsFalse_WhenUserCantGuessesCorrectly(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses
    )
    {
        // Arrange
        GuessingGame sut =
            GuessingGameTests.CreateSut(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        bool actualResult = sut.Play();

        // Assert
        Assert.That(actualResult, Is.False);
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 6)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 6)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 5)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 4)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 3)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 2)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 1)]
    public void Play_ReadsUserInput_ManyTimesAsRequired(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.ReadInputNumber(),
            Times.Exactly(expectedTimes)
        );
    }

    [Test]
    public void Play_DisplaysWelcome_OncePerPlay()
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext =
            GuessingGameTests.CreateGuessingGameWithMocks(0, 0, 1, 0, [0]);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(userInterface => userInterface.DisplayWelcome(), Times.Once);
    }

    [Test]
    public void Play_DisplaysRules_OncePerPlay()
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext =
            GuessingGameTests.CreateGuessingGameWithMocks(0, 0, 1, 0, [0]);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayRules(guessingGameTestContext.GuessingGameOptionsMock.Object),
            Times.Once
        );
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 6)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 6)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 5)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 4)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 3)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 2)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 1)]
    public void Play_DisplaysRemainingAttempts_ManyTimesAsRequired(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayRemainingAttempts(It.IsAny<int>()),
            Times.Exactly(expectedTimes)
        );
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 1)]
    public void Play_DisplaysCorrectGuessNotice_AtMostOnce(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayCorrectGuessNotice(),
            Times.Exactly(expectedTimes)
        );
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 6)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 5)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 4)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 3)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 2)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 0)]
    public void Play_DisplaysWrongGuessNotice_ManyTimesAsRequired(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayWrongGuessNotice(),
            Times.Exactly(expectedTimes)
        );
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 1)]
    public void Play_DisplaysVictoryNotice_OnceWhenPlayerWins(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayVictory(),
            Times.Exactly(expectedTimes)
        );
    }

    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 0 }, 1)]
    [TestCase(1, 6, 6, 1, new[] { 6, 5, 4, 3, 2, 1 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 5, 4, 3, 2, 1, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 4, 3, 2, 1, 0, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 3, 2, 1, 0, 0, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 2, 1, 0, 0, 0, 0 }, 0)]
    [TestCase(1, 6, 6, 1, new[] { 1, 0, 0, 0, 0, 0 }, 0)]
    public void Play_DisplaysDefeatedNotice_OnceWhenPlayerDoesntWin(
        int minDiceNumber,
        int maxDiceNumber,
        int allowedTurns,
        int targetNumber,
        int[] guesses,
        int expectedTimes
    )
    {
        // Arrange
        GuessingGameTestContext guessingGameTestContext = GuessingGameTests
            .CreateGuessingGameWithMocks(minDiceNumber, maxDiceNumber, allowedTurns, targetNumber, guesses);

        // Act
        guessingGameTestContext.Sut.Play();

        // Assert
        guessingGameTestContext.UserInterfaceMock.Verify(
            userInterface => userInterface.DisplayDefeat(),
            Times.Exactly(expectedTimes)
        );
    }
}