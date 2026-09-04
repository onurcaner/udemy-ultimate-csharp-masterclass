namespace Section09_StarWarsPlanetStats.Models;

public interface IPlanetsModel
{
    public Task<IEnumerable<IPlanet>> GetPlanetsAsync();
}