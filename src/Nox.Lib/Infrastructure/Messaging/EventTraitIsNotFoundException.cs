namespace Nox.Infrastructure.Messaging
{

    /// <summary>
    /// DomainContext must be defined in IntegrationEventTypeAttribute.
    /// </summary>
    public class IntegrationEventDomainContextNullException : Exception
    {
        public IntegrationEventDomainContextNullException(string message)
            : base(message)
        {
        }

        public IntegrationEventDomainContextNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
