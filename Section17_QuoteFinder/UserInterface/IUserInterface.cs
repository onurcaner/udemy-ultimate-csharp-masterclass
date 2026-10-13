namespace Section17_QuoteFinder.UserInterface;

internal interface IUserInterface
{
    public void WriteLine(string text);
    public string ReadWord(string invalidInputMessage);
    public int ReadIntegerNumber(string invalidInputMessage);
}