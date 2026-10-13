namespace Section17_QuoteFinder.DataAccess;

internal interface IQuotesApi : IDisposable
{
    public Task<string> GetQuotesAsync(int page, int quotesPerPage);
}