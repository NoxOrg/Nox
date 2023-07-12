namespace Nox.Integration.Exceptions;

[Serializable]
public class NoxIntegrationException : Exception
{
    public NoxIntegrationException()
    {
    }

    public NoxIntegrationException(string message)
        : base(message)
    {
    }

    public NoxIntegrationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}