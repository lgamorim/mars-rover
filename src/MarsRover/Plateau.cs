namespace MarsRover;

public class Plateau
{
    private Plateau(Surface surface)
    {
        Surface = surface;
        Squad = new List<Rover>();
    }

    public Surface Surface { get; }

    public IList<Rover> Squad { get; }

    public int TotalRovers => Squad.Count;

    public static Plateau Define(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input), "The input coordinates cannot be null.");

        var coordinates = input.Split(' ');
        if (coordinates.Length != 2)
            throw new ArgumentException("The input coordinates to define the plateau are not valid.");

        var succeeded = int.TryParse(coordinates[0], out int x);
        if (!succeeded)
            throw new ArgumentException($"The coordinate {coordinates[0]} in the X axis is not a valid number.");

        succeeded = int.TryParse(coordinates[1], out int y);
        if (!succeeded)
            throw new ArgumentException($"The coordinate {coordinates[1]} in the Y axis is not a valid number.");

        var surface = new Surface(x, y);
        var plateau = new Plateau(surface);

        return plateau;
    }

    public Rover Deploy(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input), "The input location cannot be null.");

        var location = input.Split(' ');
        if (location.Length != 3)
            throw new ArgumentException("The input location to deploy a rover is not valid.");

        var succeeded = int.TryParse(location[0], out int x);
        if (!succeeded)
            throw new ArgumentException($"The position {location[0]} in the X axis is not a valid number.");

        succeeded = int.TryParse(location[1], out int y);
        if (!succeeded)
            throw new ArgumentException($"The position {location[1]} in the Y axis is not a valid number.");

        succeeded = Enum.TryParse(location[2], out CardinalPoint orientation);
        if (!succeeded)
            throw new ArgumentException($"The orientation {location[2]} is not a valid cardinal point.");

        var position = new Position(x, y, orientation);
        if (IsRoverPositionOutsideBoundaries(position))
            throw new RoverPositionOutsidePlateauException("The rover cannot land outside the plateau boundaries.");

        var rover = Rover.Land(position);
        Squad.Add(rover);

        return rover;
    }

    public Rover Explore(string input)
    {
        var rover = Squad[TotalRovers - 1];
        foreach (var action in input)
        {
            var succeeded = Enum.TryParse(action.ToString(), out Instruction instruction);
            if (!succeeded)
                throw new ArgumentException($"The instruction {action} given is not a valid action.");

            switch (instruction)
            {
                case Instruction.L:
                    rover.SpinLeft();
                    break;
                case Instruction.R:
                    rover.SpinRight();
                    break;
                case Instruction.M:
                    var newPosition = rover.Probe();
                    if (IsRoverPositionOutsideBoundaries(newPosition))
                        throw new RoverPositionOutsidePlateauException("The rover cannot move outside the plateau boundaries.");

                    rover.MoveForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return rover;
    }

    private bool IsRoverPositionOutsideBoundaries(Position position)
    {
        if (position.X > Surface.Width || position.Y > Surface.Height) return true;
        return position.X < 0 || position.Y < 0;
    }
}