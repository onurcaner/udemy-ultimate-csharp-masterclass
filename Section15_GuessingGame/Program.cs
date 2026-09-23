using Section15_GuessingGame.Game;
using Section15_GuessingGame.RandomNumberGenerator;
using Section15_GuessingGame.UserInterface;

namespace Section15_GuessingGame;

internal static class Program
{
    private static void Main()
    {
        IGuessingGameOptions guessingGameOptions = new GuessingGuessingGameOptions
        {
            MinDiceNumber = 1,
            MaxDiceNumber = 6,
            MaxAllowedTurns = 3
        };

        new GuessingGame(
            guessingGameOptions,
            new BasicRandomNumberGenerator(),
            new ConsoleUserInterface()
        ).Play();
    }
}