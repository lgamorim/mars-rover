namespace MarsRover
{
    public class RoverPositionOutsidePlateauException : ApplicationException
    {
        public RoverPositionOutsidePlateauException()
        {
        }

        public RoverPositionOutsidePlateauException(string message) : base(message)
        {
        }
    }
}