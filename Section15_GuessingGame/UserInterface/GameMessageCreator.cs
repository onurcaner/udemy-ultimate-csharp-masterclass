using Section15_GuessingGame.Game;

namespace Section15_GuessingGame.UserInterface;

public static class GameMessageCreator
{
    public static string CreateWelcome()
    {
        return "Welcome to Guessing Game!";
    }

    public static IReadOnlyList<string> CreateRules(IGuessingGameOptions options)
    {
        return
        [
            $"Try to guess the number within {options.MaxAllowedTurns} turns.",
            $"The number range is [{options.MinDiceNumber}, {options.MaxDiceNumber}]."
        ];
    }

    public static string CreateRemainingAttempts(int attempts)
    {
        return $"You have {attempts} attempts left.";
    }

    public static string CreateCorrectGuess()
    {
        return "Correct guess!";
    }

    public static string CreateWrongGuess()
    {
        return "Wrong guess!";
    }

    public static string CreateVictory()
    {
        return "Victory! You won!";
    }

    public static string CreateDefeat()
    {
        return "Defeated! Try your luck next time...";
    }
}