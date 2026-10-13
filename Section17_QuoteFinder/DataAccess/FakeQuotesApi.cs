using System.Text.Json;

namespace Section17_QuoteFinder.DataAccess;

// this class may be used to get quotes in case Quotes Garden API is down
// it can be used where IQuotesApi is used,
// it generates quotes using 500 most common English words
// so, of course, the quotes are nonsense
internal class FakeQuotesApi : IQuotesApi
{
    private readonly Random _random = new();

    public async Task<string> GetQuotesAsync(int page, int quotesPerPage)
    {
        await Task.Delay(2000);

        QuotesDto quotesDto = new()
        {
            StatusCode = 200,
            Message = "Success",
            Pagination = new PaginationDto
            {
                CurrentPage = page,
                NextPage = Math.Min(page + 1, int.MaxValue),
                TotalPages = int.MaxValue
            },
            TotalQuotes = 0,
            Data = [.. this.GenerateRandomQuoteDtoCollection(quotesPerPage)]
        };

        string json = JsonSerializer.Serialize(quotesDto);

        return json;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // Cleanup
    }

    private IEnumerable<QuoteDto> GenerateRandomQuoteDtoCollection(int quotesPerPage)
    {
        return Enumerable
            .Range(0, quotesPerPage)
            .Select(_ => new QuoteDto
            {
                Id = "Unknown",
                QuoteAuthor = "Unknown",
                QuoteGenre = "Unknown",
                QuoteText = this.GenerateRandomQuote(),
                V = 0
            });
    }

    private string GenerateRandomQuote()
    {
        int wordCount = this._random.Next(5, 30);
        IEnumerable<string> words = Enumerable
            .Range(0, wordCount)
            .Select(_ => this.GetRandomWord());

        return string.Join(" ", words) + ".";
    }

    private string GetRandomWord()
    {
        string[] words = CommonWords.All.ToArray();
        int index = this._random.Next(0, words.Length);

        return words[index];
    }
}