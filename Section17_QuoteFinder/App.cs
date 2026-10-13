using System.Collections.Concurrent;
using System.Text.Json;
using Section17_QuoteFinder.DataAccess;
using Section17_QuoteFinder.Helpers;
using Section17_QuoteFinder.Model;
using Section17_QuoteFinder.UserInterface;

namespace Section17_QuoteFinder;

internal class App
{
    private readonly IQuotesApi _quotesApi;
    private readonly IUserInterface _userInterface;

    public App(IQuotesApi quotesApi, IUserInterface userInterface)
    {
        this._quotesApi = quotesApi;
        this._userInterface = userInterface;
    }

    public async Task RunAsync()
    {
        // Read user input
        this._userInterface.WriteLine(Message.InputWordInformation);
        string word = this._userInterface.ReadWord(Message.InputWordFail);
        this._userInterface.WriteLine(Message.InputNumberOfPageInformation);
        int numberOfPages = this._userInterface.ReadIntegerNumber(Message.InputNumberOfPageFail);
        this._userInterface.WriteLine(Message.InputQuotesPerPageInformation);
        int quotesPerPage = this._userInterface.ReadIntegerNumber(Message.InputQuotesPerPageFail);

        // Query data and fill the concurrent bag
        ConcurrentBag<Quote> quoteBag = new();
        IEnumerable<Task> tasks = Enumerable.Range(1, numberOfPages).Select(async page =>
        {
            string json = await this._quotesApi.GetQuotesAsync(page, quotesPerPage);
            QuotesDto? quotesDto = JsonSerializer.Deserialize<QuotesDto>(json);
            if (quotesDto is null)
            {
                throw new InvalidDataException();
            }

            IEnumerable<Quote> quotes = quotesDto.Data.Select(Quote.FromQuoteDto);
            foreach (Quote quote in quotes)
            {
                quoteBag.Add(quote);
            }
        });

        // Await parallel tasks
        await Task.WhenAll(tasks);

        // Filter quotes based on input, and sort by length
        Quote[] quotes = quoteBag
            .Where(quote => WordExtractor.GetAllWords(quote.Text).Contains(word))
            .ToArray();
        quotes.Sort((left, right) => left.Text.Length - right.Text.Length);

        // Display results
        this._userInterface.WriteLine(string.Empty);
        this._userInterface.WriteLine(string.Format(Message.FoundQuotes, quotes.Length));
        foreach (Quote quote in quotes)
        {
            this._userInterface.WriteLine(quote.ToPrettyString());
        }
    }
}