using Section17_QuoteFinder.DataAccess;

namespace Section17_QuoteFinder.Model;

internal class Quote
{
    public Quote(string author, string text)
    {
        this.Author = author;
        this.Text = text;
    }

    public string Author { get; init; }
    public string Text { get; init; }

    public string ToPrettyString()
    {
        return $"\"{this.Text}\" - {this.Author}";
    }

    public static Quote FromQuoteDto(QuoteDto quoteDto)
    {
        return new Quote(quoteDto.QuoteAuthor, quoteDto.QuoteText);
    }
}