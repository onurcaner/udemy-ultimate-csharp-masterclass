namespace Section09_StarWarsPlanetStats.PlanetsApi;

public interface IPlanetsApiClient
{
    public Task<IEnumerable<IPlanetDto>> GetPlanetsAsync();
}