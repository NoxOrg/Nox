namespace Nox.Exceptions
{

    /// <summary>
    ///  Nox configuration is invalid
    /// </summary>
    public class EventNameIsEmptyException : Exception
    {
        public EventNameIsEmptyException(string message)
            : base(message)
        {
        }

        public EventNameIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
