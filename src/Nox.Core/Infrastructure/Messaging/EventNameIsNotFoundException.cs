namespace Nox.Infrastructure.Messaging
{

    /// <summary>
    ///  Nox configuration is invalid
    /// </summary>
    public class EventNameIsNotFoundException : Exception
    {
        public EventNameIsNotFoundException(string message)
            : base(message)
        {
        }

        public EventNameIsNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
