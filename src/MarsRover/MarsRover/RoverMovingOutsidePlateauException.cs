using System;

namespace MarsRover
{
    public class RoverMovingOutsidePlateauException : ApplicationException
    {
        public RoverMovingOutsidePlateauException()
        {
        }

        public RoverMovingOutsidePlateauException(string message) : base(message)
        {
        }
    }
}