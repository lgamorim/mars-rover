using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.UnitTests
{
    public class SurfaceTests
    {
        [Fact]
        public void ShouldCreateRectangleWhenCoordinatesAreValid()
        {
            //Arrange
            const int x = 5;
            const int y = 5;

            //Act
            var surface = new Surface(x, y);

            //Assert
            surface.Width.Should().Be(x);
            surface.Height.Should().Be(y);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCoordinatesAreInvalid()
        {
            //Arrange
            const int x = -5;
            const int y = -5;

            //Act
            var action = new Action(() => new Surface(x, y));

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}