namespace Nox.Infrastructure.Messaging
{

    /// <summary>
    ///  Nox configuration is invalid
    /// </summary>
    public class UnknownMessageTypeException : Exception
    {
        public UnknownMessageTypeException(string message)
            : base(message)
        {
        }

        public UnknownMessageTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
