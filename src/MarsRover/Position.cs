namespace MarsRover;

public readonly struct Position
{
    public Position(int x, int y, CardinalPoint cardinalPoint)
    {
        X = x;
        Y = y;
        CardinalPoint = cardinalPoint;
    }

    public int X { get; }

    public int Y { get; }

    public CardinalPoint CardinalPoint { get; }

    public Position SpinLeft()
    {
        var newPosition = CardinalPoint switch
        {
            CardinalPoint.N => new Position(X, Y, CardinalPoint.W),
            CardinalPoint.E => new Position(X, Y, CardinalPoint.N),
            CardinalPoint.S => new Position(X, Y, CardinalPoint.E),
            CardinalPoint.W => new Position(X, Y, CardinalPoint.S),
            _ => throw new ArgumentOutOfRangeException()
        };

        return newPosition;
    }

    public Position SpinRight()
    {
        var newPosition = CardinalPoint switch
        {
            CardinalPoint.N => new Position(X, Y, CardinalPoint.E),
            CardinalPoint.E => new Position(X, Y, CardinalPoint.S),
            CardinalPoint.S => new Position(X, Y, CardinalPoint.W),
            CardinalPoint.W => new Position(X, Y, CardinalPoint.N),
            _ => throw new ArgumentOutOfRangeException()
        };

        return newPosition;
    }

    public Position MoveForward()
    {
        var newPosition = CardinalPoint switch
        {
            CardinalPoint.N => new Position(X, Y + 1, CardinalPoint),
            CardinalPoint.E => new Position(X + 1, Y, CardinalPoint),
            CardinalPoint.S => new Position(X, Y - 1, CardinalPoint),
            CardinalPoint.W => new Position(X - 1, Y, CardinalPoint),
            _ => throw new ArgumentOutOfRangeException()
        };

        return newPosition;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;

        var other = (Position)obj;
        return other.X == X && other.Y == Y && other.CardinalPoint == CardinalPoint;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() + Y.GetHashCode() + CardinalPoint.GetHashCode();
    }

    public override string ToString()
    {
        return X + " " + Y + " " + CardinalPoint;
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }
}