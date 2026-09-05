namespace Section09_StarWarsPlanetStats.Models;

internal interface IPlanetsModel
{
    public Task<IEnumerable<IPlanet>> GetPlanetsAsync();
}