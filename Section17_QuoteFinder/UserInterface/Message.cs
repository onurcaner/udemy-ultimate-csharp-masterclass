namespace Section17_QuoteFinder.UserInterface;

internal class Message
{
    public const string InputWordInformation = "Please enter a word that is searched within quotes:";

    public const string InputWordFail =
        "Please enter a single word, non-empty, without spaces, numbers, special characters, etc:";

    public const string InputNumberOfPageInformation = "Please enter a number that is pages of data to check:";

    public const string InputNumberOfPageFail = "Please enter a valid integer number:";

    public const string InputQuotesPerPageInformation =
        "Please enter a number that is quotes per page of data to check:";

    public const string InputQuotesPerPageFail = "Please enter a valid integer number:";

    public const string FoundQuotes = "Found {0} quotes:";
}