using System.Text.Json;

namespace Section09_StarWarsPlanetStats.PlanetsApi;

public class PlanetsApiClient : IPlanetsApiClient
{
    public async Task<IEnumerable<IPlanetDto>> GetPlanetsAsync()
    {
        try
        {
            using HttpResponseMessage response = await new HttpClient().GetAsync("https://swapi.info/api/planets/");
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