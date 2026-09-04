using Section09_StarWarsPlanetStats.PlanetsApi;

namespace Section09_StarWarsPlanetStats.Models;

public class PlanetsModel : IPlanetsModel
{
    private readonly IPlanetsApiClient _planetsApiClient = new PlanetsApiClient();

    public async Task<IEnumerable<IPlanet>> GetPlanetsAsync()
    {
        IEnumerable<IPlanetDto> apiPlanets = await this._planetsApiClient.GetPlanetsAsync();
        IEnumerable<IPlanet> planets = apiPlanets.Select(Planet.FromPlanetApiData);
        return planets;
    }
}