namespace MarsRover.App;

public static class Program
{
    private static int Main(string[] args)
    {
        var runner = new MarsRoverAppRunner(Console.In, Console.Out, Console.Error);

        return runner.Run();
    }
}
