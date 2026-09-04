namespace Section09_StarWarsPlanetStats.PlanetsApi;

public interface IPlanetDto
{
    public string Name { get; }
    public string Diameter { get; }
    public string SurfaceWater { get; }
    public string Population { get; }
}