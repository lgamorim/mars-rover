namespace MarsRover.App;

public static class Program
{
    private static Plateau plateau;

    private static void Main(string[] args)
    {
        Console.Write("Plateau Grid (x, y):\t");
        var input = Console.ReadLine();
        try
        {
            plateau = Plateau.Define(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        while (true)
        {
            DeployRover();
            var rover = ExplorePlateau();
            Console.WriteLine($"#{plateau.TotalRovers} Final Position:\t{rover.Position}");
        }
    }

    private static Rover DeployRover()
    {
        Console.Write($"Landing Position #{plateau.TotalRovers + 1}:\t");
        var input = Console.ReadLine();
        try
        {
            var rover = plateau.Deploy(input);
            return rover;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return DeployRover();
        }
    }

    private static Rover ExplorePlateau()
    {
        Console.Write($"Control Rover #{plateau.TotalRovers}:\t");
        var input = Console.ReadLine();
        try
        {
            var rover = plateau.Explore(input);
            return rover;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return ExplorePlateau();
        }
    }
}