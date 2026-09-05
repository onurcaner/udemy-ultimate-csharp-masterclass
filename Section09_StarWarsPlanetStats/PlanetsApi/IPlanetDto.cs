namespace Section09_StarWarsPlanetStats.PlanetsApi;

internal interface IPlanetDto
{
    public string Name { get; }
    public string Diameter { get; }
    public string SurfaceWater { get; }
    public string Population { get; }
}