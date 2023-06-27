using FluentAssertions;

namespace MarsRover.UnitTests;

public class SurfaceTests
{
    [Fact]
    public void Should_CreateRectangle_When_CoordinatesAreValid()
    {
        const int x = 1;
        const int y = 1;

        var surface = new Surface(x, y);

        surface.Width.Should().Be(x);
        surface.Height.Should().Be(y);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    [InlineData(0, 0)]
    [InlineData(-1, -1)]
    public void Should_ThrowArgumentException_When_CoordinatesAreInvalid(int x, int y)
    {
        var action = new Action(() => new Surface(x, y));

        action.Should().Throw<ArgumentException>();
    }
}