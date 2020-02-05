using FluentAssertions;
using Xunit;

namespace MarsRover.UnitTests
{
    public class RoverTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldMoveToXPlus1WhenFacingEastAndMoveForward(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.E;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.MoveForward();

            //Assert
            rover.Position.X.Should().Be(x + 1);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToNorthWhenFacingEastAndSpinLeft(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.E;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinLeft();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.N);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToSouthWhenFacingEastAndSpinRight(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.E;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinRight();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.S);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldMoveToYPlus1WhenFacingNorthAndMoveForward(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.N;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.MoveForward();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y + 1);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToWestWhenFacingNorthAndSpinLeft(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.N;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinLeft();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.W);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToEastWhenFacingNorthAndSpinRight(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.N;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinRight();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.E);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldMoveToYMinus1WhenFacingSouthAndMoveForward(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.S;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.MoveForward();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y - 1);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToEastWhenFacingSouthAndSpinLeft(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.S;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinLeft();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.E);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToWestWhenFacingSouthAndSpinRight(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.S;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinRight();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.W);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldMoveToXMinus1WhenFacingWestAndMoveForward(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.W;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.MoveForward();

            //Assert
            rover.Position.X.Should().Be(x - 1);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToSouthWhenFacingWestAndSpinLeft(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.W;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinLeft();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.S);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 3)]
        public void ShouldSpinToNorthWhenFacingWestAndSpinRight(int x, int y)
        {
            //Arrange
            const CardinalPoint cardinalPoint = CardinalPoint.W;
            var position = new Position(x, y, cardinalPoint);
            var rover = Rover.Land(position);

            //Act
            rover.SpinRight();

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(CardinalPoint.N);
        }

        [Theory]
        [InlineData(1, 2, CardinalPoint.N)]
        [InlineData(3, 3, CardinalPoint.E)]
        public void ShouldMatchDeployedPositionAfterLanding(int x, int y, CardinalPoint cardinalPoint)
        {
            //Arrange
            var position = new Position(x, y, cardinalPoint);

            //Act
            var rover = Rover.Land(position);

            //Assert
            rover.Position.X.Should().Be(x);
            rover.Position.Y.Should().Be(y);
            rover.Position.CardinalPoint.Should().Be(cardinalPoint);
        }
    }
}