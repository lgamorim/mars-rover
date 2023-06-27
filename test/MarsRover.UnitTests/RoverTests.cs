using FluentAssertions;

namespace MarsRover.UnitTests;

public class RoverTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_MoveToXPlus1_When_FacingEastAndMoveForward(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.E;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.MoveForward();

        rover.Position.X.Should().Be(x + 1);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToNorth_When_FacingEastAndSpinLeft(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.E;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinLeft();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.N);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToSouth_When_FacingEastAndSpinRight(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.E;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinRight();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.S);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_MoveToYPlus1_When_FacingNorthAndMoveForward(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.N;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.MoveForward();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y + 1);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToWest_When_FacingNorthAndSpinLeft(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.N;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinLeft();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.W);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToEast_When_FacingNorthAndSpinRight(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.N;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinRight();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.E);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_MoveToYMinus1_When_FacingSouthAndMoveForward(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.S;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.MoveForward();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y - 1);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToEast_When_FacingSouthAndSpinLeft(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.S;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinLeft();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.E);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToWest_When_FacingSouthAndSpinRight(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.S;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinRight();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.W);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_MoveToXMinus1_When_FacingWestAndMoveForward(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.W;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.MoveForward();

        rover.Position.X.Should().Be(x - 1);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToSouth_When_FacingWestAndSpinLeft(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.W;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinLeft();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.S);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(3, 3)]
    public void Should_SpinToNorth_When_FacingWestAndSpinRight(int x, int y)
    {
        const CardinalPoint cardinalPoint = CardinalPoint.W;
        var position = new Position(x, y, cardinalPoint);
        var rover = Rover.Land(position);

        rover.SpinRight();

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(CardinalPoint.N);
    }

    [Theory]
    [InlineData(1, 2, CardinalPoint.N)]
    [InlineData(3, 3, CardinalPoint.E)]
    public void Should_MatchDeployedPosition_After_Landing(int x, int y, CardinalPoint cardinalPoint)
    {
        var position = new Position(x, y, cardinalPoint);

        var rover = Rover.Land(position);

        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }
}