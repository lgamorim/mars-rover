using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.UnitTests
{
    public class PlateauTests
    {
        private string MapFlat(params object[] input)
        {
            var flatted = "";
            foreach (var str in input) flatted += str + " ";

            return flatted.TrimEnd();
        }

        [Fact]
        public void ShouldLandRoverSequentiallyWhenDeploying()
        {
            //Arrange
            const string coordinates = "5 5";
            var plateau = Plateau.Define(coordinates);

            var position1 = "1 2 N";
            var position2 = "3 3 E";

            //Act
            var rover1 = plateau.Deploy(position1);
            var rover2 = plateau.Deploy(position2);

            //Assert
            plateau.TotalRovers.Should().Be(2);
            plateau.Squad[0].Should().Be(rover1);
            plateau.Squad[plateau.TotalRovers - 1].Should().Be(rover2);
        }

        [Fact]
        public void ShouldLandRoverWhenDeployingInsideBoundaries()
        {
            //Arrange
            const string coordinates = "5 5";
            var plateau = Plateau.Define(coordinates);

            const int x = 1;
            const int y = 2;
            const CardinalPoint cardinalPoint = CardinalPoint.N;
            var position = MapFlat(x, y, cardinalPoint);

            //Act
            var rover = plateau.Deploy(position);

            //Assert
            plateau.Squad[plateau.TotalRovers - 1].Should().Be(rover);
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }

        [Fact]
        public void ShouldMatchUpperCoordinatesAfterCreating()
        {
            //Arrange
            const int x = 5;
            const int y = 5;
            var coordinates = MapFlat(x, y);

            //Act
            var plateau = Plateau.Define(coordinates);

            //Assert
            plateau.Surface.Width.Should().Be(x);
            plateau.Surface.Height.Should().Be(y);
        }

        [Fact]
        public void ShouldNavigateLastDeployedRoverWhenExploring()
        {
            //Arrange
            const string coordinates = "5 5";
            var plateau = Plateau.Define(coordinates);

            var position1 = "1 2 N";
            var instructions1 = "LMLMLMLMM";
            var position2 = "3 3 E";
            var instructions2 = "MMRMMRMRRM";

            //Act
            var rover1 = plateau.Deploy(position1);
            rover1 = plateau.Explore(instructions1);
            var rover2 = plateau.Deploy(position2);
            rover2 = plateau.Explore(instructions2);

            //Assert
            rover1.Position.Equals(new Position(1, 3, CardinalPoint.N));
            rover2.Position.Equals(new Position(5, 1, CardinalPoint.E));
        }

        [Fact]
        public void ShouldThrowExceptionWhenDeployingOutsideBoundaries()
        {
            //Arrange
            const string coordinates = "5 5";
            const string position = "-1 -2 N";

            //Act
            var plateau = Plateau.Define(coordinates);
            var action = new Action(() => plateau.Deploy(position));

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenMovingOutsideBoundaries()
        {
            //Arrange
            const string coordinates = "5 5";
            const string position = "1 2 N";
            const string instructions = "LMM";

            //Act
            var plateau = Plateau.Define(coordinates);
            plateau.Deploy(position);
            var action = new Action(() => plateau.Explore(instructions));

            //Assert
            action.Should().Throw<RoverMovingOutsidePlateauException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpperCoordinatesAreInvalid()
        {
            //Arrange
            const string coordinates = "-5 -5";

            //Act
            var action = new Action(() => Plateau.Define(coordinates));

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}