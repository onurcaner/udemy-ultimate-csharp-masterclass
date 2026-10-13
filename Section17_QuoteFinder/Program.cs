using Section17_QuoteFinder.DataAccess;
using Section17_QuoteFinder.UserInterface;

namespace Section17_QuoteFinder;

internal static class Program
{
    private static void Main()
    {
        new App(new FakeQuotesApi(), new ConsoleInterface())
            .RunAsync()
            .Wait();

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}