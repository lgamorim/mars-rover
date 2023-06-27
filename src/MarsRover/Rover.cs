namespace MarsRover;

public class Rover
{
    private Rover()
    {
        Id = Guid.NewGuid();
    }

    private Guid Id { get; }

    public Position Position { get; private set; }

    public static Rover Land(Position position)
    {
        var rover = new Rover {Position = position};

        return rover;
    }

    public void SpinLeft()
    {
        Position = Position.SpinLeft();
    }

    public void SpinRight()
    {
        Position = Position.SpinRight();
    }

    public void MoveForward()
    {
        Position = Position.MoveForward();
    }

    public override bool Equals(object obj)
    {
        if (obj != null && obj.GetType() != GetType()) return false;
        var other = (Rover) obj;
        return other != null && other.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}