using Section09_StarWarsPlanetStats.PlanetsApi;

namespace Section09_StarWarsPlanetStats.Models;

internal class Planet : IPlanet
{
    public Planet(
        string name,
        long? diameter,
        int? surfaceWaterPercent,
        int? population
    )
    {
        this.Name = name;
        this.Diameter = diameter;
        this.SurfaceWaterPercent = surfaceWaterPercent;
        this.Population = population;
    }

    public string Name { get; init; }
    public long? Diameter { get; init; }
    public int? SurfaceWaterPercent { get; init; }
    public int? Population { get; init; }

    public static Planet FromPlanetApiData(IPlanetDto planetDto)
    {
        bool hasDiameter = long.TryParse(planetDto.Diameter, out long diameter);
        bool hasSurfaceWaterPercent = int.TryParse(planetDto.SurfaceWater, out int surfaceWaterPercent);
        bool hasPopulation = int.TryParse(planetDto.Population, out int population);
        return new Planet(
            planetDto.Name,
            hasDiameter ? diameter : null,
            hasSurfaceWaterPercent ? surfaceWaterPercent : null,
            hasPopulation ? population : null
        );
    }
}