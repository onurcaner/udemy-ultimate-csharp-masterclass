using Section15_GuessingGame.Game;

namespace Section15_GuessingGame.UserInterface;

internal class ConsoleUserInterface : IUserInterface
{
    public int ReadInputNumber()
    {
        while (true)
        {
            string? userInput = Console.ReadLine();
            if (userInput is null)
            {
                this.DisplayMessage("Input can not be not null.");
                continue;
            }

            if (userInput.Length == 0)
            {
                this.DisplayMessage("Input must be non empty.");
                continue;
            }

            if (!int.TryParse(userInput, out int number))
            {
                this.DisplayMessage("Input must be integral number.");
                continue;
            }

            return number;
        }
    }

    public void DisplayWelcome()
    {
        Console.WriteLine(GameMessageCreator.CreateWelcome());
    }

    public void DisplayRules(IGuessingGameOptions guessingGameOptions)
    {
        IEnumerable<string> messages = GameMessageCreator.CreateRules(guessingGameOptions);
        foreach (string message in messages)
        {
            Console.WriteLine(message);
        }
    }

    public void DisplayRemainingAttempts(int attempts)
    {
        Console.WriteLine(GameMessageCreator.CreateRemainingAttempts(attempts));
    }

    public void DisplayCorrectGuessNotice()
    {
        Console.WriteLine(GameMessageCreator.CreateCorrectGuess());
    }

    public void DisplayWrongGuessNotice()
    {
        Console.WriteLine(GameMessageCreator.CreateWrongGuess());
    }

    public void DisplayVictory()
    {
        Console.WriteLine(GameMessageCreator.CreateVictory());
    }

    public void DisplayDefeat()
    {
        Console.WriteLine(GameMessageCreator.CreateDefeat());
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}