namespace MarsRover;

public readonly struct Surface
{
    public Surface(int width, int height)
    {
        if (width < 1 || height < 1) throw new ArgumentException("The width and height must be positive integers.");
        Width = width;
        Height = height;
    }

    public int Height { get; }

    public int Width { get; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;

        var other = (Surface)obj;
        return other.Width == Width && other.Height == Height;
    }

    public override int GetHashCode()
    {
        return Width.GetHashCode() + Height.GetHashCode();
    }

    public override string ToString()
    {
        return Width + " " + Height;
    }

    public static bool operator ==(Surface left, Surface right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Surface left, Surface right)
    {
        return !(left == right);
    }
}