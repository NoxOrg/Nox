namespace Nox.Exceptions
{

    /// <summary>
    ///  Nox configuration is invalid
    /// </summary>
    public class EventTraitIsEmptyException : Exception
    {
        public EventTraitIsEmptyException(string message)
            : base(message)
        {
        }

        public EventTraitIsEmptyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
