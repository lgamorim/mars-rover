using FluentAssertions;
using MarsRover.App;

namespace MarsRover.App.UnitTests;

public class MarsRoverAppRunnerTests
{
    private static string MapLines(params string[] lines)
    {
        return string.Join(Environment.NewLine, lines) + Environment.NewLine;
    }

    [Fact]
    public void Should_PromptForPlateauGrid_When_Running()
    {
        var input = new StringReader(MapLines("5 5"));
        var output = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, new StringWriter());

        runner.Run();

        output.ToString().Should().Contain("Plateau Grid (x, y):");
    }

    [Fact]
    public void Should_ReturnZero_When_InputIsExhausted()
    {
        var input = new StringReader(MapLines("5 5"));
        var runner = new MarsRoverAppRunner(input, new StringWriter(), new StringWriter());

        var exitCode = runner.Run();

        exitCode.Should().Be(0);
    }

    [Fact]
    public void Should_ReturnOneAndWriteError_When_PlateauGridIsInvalid()
    {
        var input = new StringReader(MapLines("5"));
        var error = new StringWriter();
        var runner = new MarsRoverAppRunner(input, new StringWriter(), error);

        var exitCode = runner.Run();

        exitCode.Should().Be(1);
        error.ToString().Should().NotBeEmpty();
    }

    [Fact]
    public void Should_PrintFinalPosition_When_RoverIsDeployedAndExplored()
    {
        var input = new StringReader(MapLines("5 5", "1 2 N", "LMLMLMLMM"));
        var output = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, new StringWriter());

        runner.Run();

        output.ToString().Should().Contain("#1 Final Position:").And.Contain("1 3 N");
    }

    [Fact]
    public void Should_PrintFinalPositionForEachRover_When_SquadIsDeployedAndExplored()
    {
        var input = new StringReader(MapLines(
            "5 5",
            "1 2 N", "LMLMLMLMM",
            "3 3 E", "MMRMMRMRRM"));
        var output = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, new StringWriter());

        runner.Run();

        var result = output.ToString();
        result.Should().Contain("#1 Final Position:").And.Contain("1 3 N");
        result.Should().Contain("#2 Final Position:").And.Contain("5 1 E");
    }

    [Fact]
    public void Should_PromptForLandingPosition_When_PlateauIsDefined()
    {
        var input = new StringReader(MapLines("5 5"));
        var output = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, new StringWriter());

        runner.Run();

        output.ToString().Should().Contain("Landing Position #1:");
    }

    [Fact]
    public void Should_WriteErrorAndRetry_When_LandingPositionIsInvalid()
    {
        var input = new StringReader(MapLines("5 5", "9 9 N", "1 2 N", "M"));
        var output = new StringWriter();
        var error = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, error);

        runner.Run();

        error.ToString().Should().NotBeEmpty();
        output.ToString().Should().Contain("1 3 N");
    }

    [Fact]
    public void Should_WriteErrorAndRetry_When_ControlInstructionIsInvalid()
    {
        var input = new StringReader(MapLines("5 5", "1 2 N", "LMX", "LM"));
        var output = new StringWriter();
        var error = new StringWriter();
        var runner = new MarsRoverAppRunner(input, output, error);

        runner.Run();

        error.ToString().Should().NotBeEmpty();
        output.ToString().Should().Contain("#1 Final Position:");
    }
}
