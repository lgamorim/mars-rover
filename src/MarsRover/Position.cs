namespace MarsRover;

public class Position
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
        Position newPosition;
        switch (CardinalPoint)
        {
            case CardinalPoint.N:
                newPosition = new Position(X, Y, CardinalPoint.W);
                break;
            case CardinalPoint.E:
                newPosition = new Position(X, Y, CardinalPoint.N);
                break;
            case CardinalPoint.S:
                newPosition = new Position(X, Y, CardinalPoint.E);
                break;
            case CardinalPoint.W:
                newPosition = new Position(X, Y, CardinalPoint.S);
                break;
            default:
                newPosition = null;
                break;
        }

        return newPosition;
    }

    public Position SpinRight()
    {
        Position newPosition;
        switch (CardinalPoint)
        {
            case CardinalPoint.N:
                newPosition = new Position(X, Y, CardinalPoint.E);
                break;
            case CardinalPoint.E:
                newPosition = new Position(X, Y, CardinalPoint.S);
                break;
            case CardinalPoint.S:
                newPosition = new Position(X, Y, CardinalPoint.W);
                break;
            case CardinalPoint.W:
                newPosition = new Position(X, Y, CardinalPoint.N);
                break;
            default:
                newPosition = null;
                break;
        }

        return newPosition;
    }

    public Position MoveForward()
    {
        Position newPosition;
        switch (CardinalPoint)
        {
            case CardinalPoint.N:
                newPosition = new Position(X, Y + 1, CardinalPoint);
                break;
            case CardinalPoint.E:
                newPosition = new Position(X + 1, Y, CardinalPoint);
                break;
            case CardinalPoint.S:
                newPosition = new Position(X, Y - 1, CardinalPoint);
                break;
            case CardinalPoint.W:
                newPosition = new Position(X - 1, Y, CardinalPoint);
                break;
            default:
                newPosition = null;
                break;
        }

        return newPosition;
    }

    public override bool Equals(object obj)
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
}