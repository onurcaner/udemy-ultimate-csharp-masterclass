using System.Text.Json;

namespace Section09_StarWarsPlanetStats.PlanetsApi;

internal class PlanetsApiClient : IPlanetsApiClient
{
    private const string PlanetsApiUrl = "https://swapi.info/api/planets/";

    public async Task<IEnumerable<IPlanetDto>> GetPlanetsAsync()
    {
        try
        {
            using HttpResponseMessage response = await new HttpClient().GetAsync(PlanetsApiClient.PlanetsApiUrl);
            response.EnsureSuccessStatusCode();

            await using Stream stream = await response.Content.ReadAsStreamAsync();
            IEnumerable<IPlanetDto>? data = await JsonSerializer.DeserializeAsync<IEnumerable<PlanetDto>>(stream);

            return data ?? [];
        }
        catch (HttpRequestException exception)
        {
            Console.WriteLine(exception.Message);
            return [];
        }
    }
}