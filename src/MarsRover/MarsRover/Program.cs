using System;

namespace MarsRover
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Plateau plateau;
            string input;

            Console.Write("Plateau Grid (x, y):\t");
            input = Console.ReadLine();
            plateau = Plateau.Define(input);

            var index = 1;
            while (true)
            {
                Console.Write($"Landing Position #{index}:\t");
                input = Console.ReadLine();
                plateau.Deploy(input);

                Console.Write($"Control Rover #{index}:\t");
                input = Console.ReadLine();
                var rover = plateau.Explore(input);

                Console.WriteLine($"#{index++} Final Position:\t{rover.Position}");
            }
        }
    }
}