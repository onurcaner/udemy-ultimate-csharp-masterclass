using System.Text.Json.Serialization;

namespace Section17_QuoteFinder.DataAccess;

internal record PaginationDto
{
    [JsonPropertyName("currentPage")] public required int CurrentPage { get; init; }
    [JsonPropertyName("nextPage")] public required int NextPage { get; init; }
    [JsonPropertyName("totalPages")] public required int TotalPages { get; init; }
}