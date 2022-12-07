namespace MarsRover.Exceptions
{
    [Serializable]
    public class MessageNotValidException : Exception
    {
        public MessageNotValidException() { }

        public MessageNotValidException(string message)
            : base(String.Format("Message not valid: {0}", message))
        {

        }
    }
}
