namespace Nox.Infrastructure.Messaging
{

    /// <summary>
    ///  Nox configuration is invalid
    /// </summary>
    public class EventTraitIsNotFoundException : Exception
    {
        public EventTraitIsNotFoundException(string message)
            : base(message)
        {
        }

        public EventTraitIsNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
