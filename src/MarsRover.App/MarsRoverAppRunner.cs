using MarsRover;

namespace MarsRover.App;

public class MarsRoverAppRunner(TextReader input, TextWriter output, TextWriter error)
{
    private Plateau plateau = null!;

    public int Run()
    {
        output.Write("Plateau Grid (x, y):\t");
        var line = input.ReadLine();
        try
        {
            plateau = Plateau.Define(line!);
        }
        catch (Exception ex)
        {
            error.WriteLine(ex.Message);
            return 1;
        }

        while (true)
        {
            var rover = DeployRover();
            if (rover is null) return 0;

            rover = ExplorePlateau();
            if (rover is null) return 0;

            output.WriteLine($"#{plateau.TotalRovers} Final Position:\t{rover.Position}");
        }
    }

    private Rover? DeployRover()
    {
        output.Write($"Landing Position #{plateau.TotalRovers + 1}:\t");
        var line = input.ReadLine();
        if (line is null) return null;

        try
        {
            return plateau.Deploy(line);
        }
        catch (Exception ex)
        {
            error.WriteLine(ex.Message);
            return DeployRover();
        }
    }

    private Rover? ExplorePlateau()
    {
        output.Write($"Control Rover #{plateau.TotalRovers}:\t");
        var line = input.ReadLine();
        if (line is null) return null;

        try
        {
            return plateau.Explore(line);
        }
        catch (Exception ex)
        {
            error.WriteLine(ex.Message);
            return ExplorePlateau();
        }
    }
}
