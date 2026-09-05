using System.Text.Json.Serialization;

namespace Section09_StarWarsPlanetStats.PlanetsApi;

internal record PlanetDto : IPlanetDto
{
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("diameter")] public required string Diameter { get; init; }
    [JsonPropertyName("surface_water")] public required string SurfaceWater { get; init; }
    [JsonPropertyName("population")] public required string Population { get; init; }
}