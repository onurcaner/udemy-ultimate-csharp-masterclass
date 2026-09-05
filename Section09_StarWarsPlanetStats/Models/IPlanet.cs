namespace Section09_StarWarsPlanetStats.Models;

internal interface IPlanet
{
    public string Name { get; }
    public long? Diameter { get; }
    public int? SurfaceWaterPercent { get; }
    public int? Population { get; }
}