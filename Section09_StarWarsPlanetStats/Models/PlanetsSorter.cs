namespace Section09_StarWarsPlanetStats.Models;

internal static class PlanetsSorter
{
    private static readonly Dictionary<PlanetProperty, Func<IPlanet, object?>>
        s_planetPropertyToPropertySelectorMapping = new()
        {
            [PlanetProperty.Name] = planet => planet.Name,
            [PlanetProperty.Diameter] = planet => planet.Diameter,
            [PlanetProperty.SurfaceWater] = planet => planet.SurfaceWaterPercent,
            [PlanetProperty.Population] = planet => planet.Population
        };

    public static IEnumerable<IPlanet> ToSorted(this IEnumerable<IPlanet> planets, PlanetProperty sortByPlanetProperty)
    {
        Func<IPlanet, object?> propertySelector = PlanetsSorter
            .s_planetPropertyToPropertySelectorMapping[sortByPlanetProperty];

        return planets
            .Where(planet => propertySelector(planet) is not null)
            .OrderBy(propertySelector);
    }
}