namespace Section17_QuoteFinder.UserInterface;

internal class ConsoleInterface : IUserInterface
{
    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    public string ReadWord(string invalidInputMessage)
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                this.WriteLine(invalidInputMessage);
                continue;
            }

            bool hasNonLetters = input.Any(character => !char.IsLetter(character));
            if (hasNonLetters)
            {
                this.WriteLine(invalidInputMessage);
                continue;
            }

            return input;
        }
    }

    public int ReadIntegerNumber(string invalidInputMessage)
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                this.WriteLine(invalidInputMessage);
                continue;
            }

            bool hasNonDigits = input.Any(character => !char.IsDigit(character));
            if (hasNonDigits)
            {
                this.WriteLine(invalidInputMessage);
                continue;
            }

            bool isParsable = int.TryParse(input, out int number);
            if (!isParsable)
            {
                this.WriteLine(invalidInputMessage);
                continue;
            }

            return number;
        }
    }
}