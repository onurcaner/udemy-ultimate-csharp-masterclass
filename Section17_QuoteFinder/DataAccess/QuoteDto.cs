using System.Text.Json.Serialization;

namespace Section17_QuoteFinder.DataAccess;

internal record QuoteDto
{
    [JsonPropertyName("_id")] public required string Id { get; init; }
    [JsonPropertyName("quoteAuthor")] public required string QuoteAuthor { get; init; }
    [JsonPropertyName("quoteGenre")] public required string QuoteGenre { get; init; }
    [JsonPropertyName("quoteText")] public required string QuoteText { get; init; }
    [JsonPropertyName("__v")] public required int V { get; init; }
}