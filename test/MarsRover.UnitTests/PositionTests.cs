using FluentAssertions;

namespace MarsRover.UnitTests;

public class PositionTests
{
    [Theory]
    [InlineData(CardinalPoint.S, CardinalPoint.E)]
    [InlineData(CardinalPoint.E, CardinalPoint.N)]
    [InlineData(CardinalPoint.W, CardinalPoint.S)]
    [InlineData(CardinalPoint.N, CardinalPoint.W)]
    public void Should_Rotate90DegreesLeft_When_SpinLeft(CardinalPoint origin, CardinalPoint rotated)
    {
        var originalPosition = new Position(1, 1, origin);
        var finalPosition = new Position(1, 1, rotated);

        var result = originalPosition.SpinLeft();

        result.Should().Be(finalPosition);
    }

    [Theory]
    [InlineData(CardinalPoint.S, CardinalPoint.W)]
    [InlineData(CardinalPoint.E, CardinalPoint.S)]
    [InlineData(CardinalPoint.W, CardinalPoint.N)]
    [InlineData(CardinalPoint.N, CardinalPoint.E)]
    public void Should_Rotate90DegreesRight_When_SpinRight(CardinalPoint origin, CardinalPoint rotated)
    {
        var originalPosition = new Position(1, 1, origin);
        var finalPosition = new Position(1, 1, rotated);

        var result = originalPosition.SpinRight();

        result.Should().Be(finalPosition);
    }

    [Fact]
    public void Should_MoveToYMinus1_When_FacingSouthAndMoveForward()
    {
        var originalPosition = new Position(1, 1, CardinalPoint.S);
        var finalPosition = new Position(1, 0, CardinalPoint.S);

        var result = originalPosition.MoveForward();

        result.Should().Be(finalPosition);
    }

    [Fact]
    public void Should_MoveToXPlus1_When_FacingEastAndMoveForward()
    {
        var originalPosition = new Position(1, 1, CardinalPoint.E);
        var finalPosition = new Position(2, 1, CardinalPoint.E);

        var result = originalPosition.MoveForward();

        result.Should().Be(finalPosition);
    }

    [Fact]
    public void Should_MoveToXMinus1_When_FacingWestAndMoveForward()
    {
        var originalPosition = new Position(1, 1, CardinalPoint.W);
        var finalPosition = new Position(0, 1, CardinalPoint.W);

        var result = originalPosition.MoveForward();

        result.Should().Be(finalPosition);
    }

    [Fact]
    public void Should_MoveToYPlus1_When_FacingNorthAndMoveForward()
    {
        var originalPosition = new Position(1, 1, CardinalPoint.N);
        var finalPosition = new Position(1, 2, CardinalPoint.N);

        var result = originalPosition.MoveForward();

        result.Should().Be(finalPosition);
    }
}