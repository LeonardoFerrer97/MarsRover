namespace MarsRover.Exceptions
{
    [Serializable]
    public class InvalidDirectionException : Exception
    {
        public InvalidDirectionException() { }

        public InvalidDirectionException(string direction)
            : base(String.Format("Invalid direction {0}", direction))
        {

        }
    }
}
