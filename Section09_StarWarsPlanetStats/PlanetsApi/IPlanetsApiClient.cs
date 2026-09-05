namespace Section09_StarWarsPlanetStats.PlanetsApi;

internal interface IPlanetsApiClient
{
    public Task<IEnumerable<IPlanetDto>> GetPlanetsAsync();
}