using FluentAssertions;

namespace MarsRover.UnitTests;

public class PlateauTests
{
    private static string MapFlat(params object[] input)
    {
        var flatted = "";
        foreach (var str in input) flatted += str + " ";

        return flatted.TrimEnd();
    }

    [Fact]
    public void Should_MatchUpperCoordinates_When_InputToDefineIsValid()
    {
        const int x = 5;
        const int y = 5;
        var coordinates = MapFlat(x, y);

        var plateau = Plateau.Define(coordinates);

        plateau.Surface.Width.Should().Be(x);
        plateau.Surface.Height.Should().Be(y);
    }

    [Fact]
    public void Should_ThrowArgumentNullException_When_InputToDefineIsNull()
    {
        var action = new Action(() => Plateau.Define(null));

        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData("5")]
    [InlineData("5 5 5")]
    public void Should_ThrowArgumentException_When_InputToDefineIsInvalid(string coordinates)
    {
        var action = new Action(() => Plateau.Define(coordinates));

        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("X 5")]
    [InlineData("5 Y")]
    public void Should_ThrowArgumentException_When_CoordinateToDefineIsInvalid(string coordinates)
    {
        var action = new Action(() => Plateau.Define(coordinates));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_ThrowArgumentException_When_UpperCoordinatesToDefinePlateauAreInvalid()
    {
        const string coordinates = "-5 -5";

        var action = new Action(() => Plateau.Define(coordinates));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_LandEachRoverSequentially_When_DeployingInsideBoundaries()
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        const string position1 = "1 2 N";
        const string position2 = "3 3 E";

        var rover1 = plateau.Deploy(position1);
        var rover2 = plateau.Deploy(position2);

        plateau.TotalRovers.Should().Be(2);
        plateau.Squad[0].Should().Be(rover1);
        plateau.Squad[plateau.TotalRovers - 1].Should().Be(rover2);
    }

    [Fact]
    public void Should_LandRover_When_DeployingInsideBoundaries()
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        const int x = 1;
        const int y = 2;
        const CardinalPoint cardinalPoint = CardinalPoint.N;
        var position = MapFlat(x, y, cardinalPoint);

        var rover = plateau.Deploy(position);

        plateau.Squad[plateau.TotalRovers - 1].Should().Be(rover);
        rover.Position.X.Should().Be(x);
        rover.Position.Y.Should().Be(y);
        rover.Position.CardinalPoint.Should().Be(cardinalPoint);
    }

    [Fact]
    public void Should_ThrowArgumentNullException_When_InputToDeployIsNull()
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        var action = new Action(() => plateau.Deploy(null));

        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData("1 2")]
    [InlineData("1 2 N S")]
    public void Should_ThrowArgumentException_When_InputToDeployIsInvalid(string position)
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        var action = new Action(() => plateau.Deploy(position));

        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("N 2 1")]
    [InlineData("1 N 2")]
    [InlineData("1 2 X")]
    public void Should_ThrowArgumentException_When_LocationToDeployIsInvalid(string position)
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        var action = new Action(() => plateau.Deploy(position));

        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(-1, -2, CardinalPoint.N)]
    [InlineData(6, 7, CardinalPoint.E)]
    public void Should_ThrowRoverPositionOutsidePlateauException_When_DeployingOutsideBoundaries(int x, int y, CardinalPoint cardinalPoint)
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        var position = MapFlat(x, y, cardinalPoint);

        var action = new Action(() => plateau.Deploy(position));

        action.Should().Throw<RoverPositionOutsidePlateauException>();
    }

    [Fact]
    public void Should_NavigateLastDeployedRover_When_Exploring()
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        const string position1 = "1 2 N";
        const string instructions1 = "LMLMLMLMM";
        const string position2 = "3 3 E";
        const string instructions2 = "MMRMMRMRRM";

        var rover1 = plateau.Deploy(position1);
        rover1 = plateau.Explore(instructions1);
        var rover2 = plateau.Deploy(position2);
        rover2 = plateau.Explore(instructions2);

        rover1.Position.Equals(new Position(1, 3, CardinalPoint.N));
        rover2.Position.Equals(new Position(5, 1, CardinalPoint.E));
    }

    [Theory]
    [InlineData("LMN")]
    [InlineData("RMN")]
    [InlineData("MNM")]
    public void Should_ThrowArgumentException_When_InstructionToExploreIsInvalid(string instructions)
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        const string position = "1 2 N";
        plateau.Deploy(position);

        var action = new Action(() => plateau.Explore(instructions));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_ThrowRoverPositionOutsidePlateauException_When_ExploringOutsideBoundaries()
    {
        const string coordinates = "5 5";
        var plateau = Plateau.Define(coordinates);

        const string position = "1 2 N";
        plateau.Deploy(position);

        const string instructions = "LMM";

        var action = new Action(() => plateau.Explore(instructions));

        action.Should().Throw<RoverPositionOutsidePlateauException>();
    }
}