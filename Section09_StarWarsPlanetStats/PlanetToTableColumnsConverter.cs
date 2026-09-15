using Section09_StarWarsPlanetStats.Models;

namespace Section09_StarWarsPlanetStats;

internal static class PlanetToTableColumnsConverter
{
    public static int ColumnCount => PlanetToTableColumnsConverter.CreateHeaderColumns().Count();

    public static IEnumerable<string> CreateHeaderColumns()
    {
        return
        [
            "Name",
            "Diameter",
            "Surface Water",
            "Population"
        ];
    }

    public static IEnumerable<string> CreateDataColumns(IPlanet planet)
    {
        string name = planet.Name;
        string diameter = planet.Diameter is not null ? $"{planet.Diameter}km" : "";
        string surfaceWater = planet.SurfaceWaterPercent is not null ? $"{planet.SurfaceWaterPercent}%" : "";
        string population = planet.Population is not null ? $"{planet.Population}" : "";

        return
        [
            name,
            diameter,
            surfaceWater,
            population
        ];
    }
}