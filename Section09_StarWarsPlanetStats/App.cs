using Section09_StarWarsPlanetStats.Models;
using Section09_StarWarsPlanetStats.TablePrinter;

namespace Section09_StarWarsPlanetStats;

internal class App
{
    public static async Task RunAsync()
    {
        // Fetching Planets
        Console.WriteLine("Hello, World! Fetching Star Wars Planet Stats..");
        IEnumerable<IPlanet> planets = await new PlanetsModel().GetPlanetsAsync();


        // Printing the Table
        Console.WriteLine();
        new UniversalTablePrinter(
            new ConsoleLinePrinter(),
            PlanetToTableColumnsConverter.ColumnCount,
            20,
            1
        ).PrintTable(
            PlanetToTableColumnsConverter.CreateHeaderColumns(),
            planets.Select(PlanetToTableColumnsConverter.CreateDataColumns)
        );


        // User input
        PlanetProperty selectedPlanetProperty = PlanetProperty.Name;
        for (bool isLooping = true; isLooping;)
        {
            Console.WriteLine();
            Console.WriteLine("The statistics of which property would you like to see?");
            Console.WriteLine("diameter");
            Console.WriteLine("surface water");
            Console.WriteLine("population");
            string? userInput = Console.ReadLine();
            if (userInput is null)
            {
                continue;
            }

            switch (userInput.ToLower().Trim())
            {
                case "diameter":
                    selectedPlanetProperty = PlanetProperty.Diameter;
                    isLooping = false;
                    break;

                case "surface water":
                    selectedPlanetProperty = PlanetProperty.SurfaceWater;
                    isLooping = false;
                    break;

                case "population":
                    selectedPlanetProperty = PlanetProperty.Population;
                    isLooping = false;
                    break;

                default:
                    selectedPlanetProperty = PlanetProperty.Name;
                    isLooping = true;
                    break;
            }
        }


        // Printing Sorted Table
        IEnumerable<IPlanet> sortedPlanets = planets.ToSorted(selectedPlanetProperty);
        Console.WriteLine();
        new UniversalTablePrinter(new ConsoleLinePrinter(),
            PlanetToTableColumnsConverter.ColumnCount,
            20,
            1
        ).PrintTable(
            PlanetToTableColumnsConverter.CreateHeaderColumns(),
            sortedPlanets.Select(PlanetToTableColumnsConverter.CreateDataColumns)
        );


        // Exit
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    internal class ConsoleLinePrinter : ILinePrinter
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}