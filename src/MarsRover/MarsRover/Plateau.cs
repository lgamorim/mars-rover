using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Plateau
    {
        private Plateau()
        {
            Squad = new List<Rover>();
        }

        public Surface Surface { get; private set; }

        public IList<Rover> Squad { get; }

        public int TotalRovers => Squad.Count;

        public static Plateau Define(string input)
        {
            var coordinates = input.Split(' ');
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            var surface = new Surface(x, y);

            var plateau = new Plateau {Surface = surface};

            return plateau;
        }

        public Rover Deploy(string input)
        {
            var location = input.Split(' ');
            var x = int.Parse(location[0]);
            var y = int.Parse(location[1]);
            Enum.TryParse(location[2], out CardinalPoint orientation);

            if (x < 0 || y < 0)
                throw new ArgumentException("The X and Y coordinates must be equal to or greater than zero.");

            var position = new Position(x, y, orientation);
            var rover = Rover.Land(position);
            Squad.Add(rover);

            return rover;
        }

        public Rover Explore(string input)
        {
            var rover = Squad[TotalRovers - 1];
            foreach (var action in input)
            {
                Enum.TryParse(action.ToString(), out Instruction instruction);
                switch (instruction)
                {
                    case Instruction.L:
                        rover.SpinLeft();
                        break;
                    case Instruction.R:
                        rover.SpinRight();
                        break;
                    case Instruction.M:
                        if (IsRoverMovingOutsideBoundaries(rover))
                            throw new RoverMovingOutsidePlateauException("The rover cannot move outside the plateau boundaries.");

                        rover.MoveForward();
                        break;
                }
            }

            return rover;
        }

        private bool IsRoverMovingOutsideBoundaries(Rover rover)
        {
            var position = rover.Position;
            var newPosition = position.MoveForward();
            if (newPosition.X > Surface.Width || newPosition.Y > Surface.Height) return true;
            if (newPosition.X < 0 || newPosition.Y < 0) return true;

            return false;
        }
    }
}