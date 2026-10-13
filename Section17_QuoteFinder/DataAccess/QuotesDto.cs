using System.Text.Json.Serialization;

namespace Section17_QuoteFinder.DataAccess;

internal record QuotesDto
{
    [JsonPropertyName("statusCode")] public required int StatusCode { get; init; }
    [JsonPropertyName("message")] public required string Message { get; init; }
    [JsonPropertyName("pagination")] public required PaginationDto Pagination { get; init; }
    [JsonPropertyName("totalQuotes")] public required int TotalQuotes { get; init; }
    [JsonPropertyName("data")] public required IReadOnlyList<QuoteDto> Data { get; init; }
}