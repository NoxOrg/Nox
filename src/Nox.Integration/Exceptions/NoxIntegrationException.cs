using System;

namespace Nox.Integration.Exceptions;

[Serializable]
public class NoxIntegrationException : Exception
{
    public NoxIntegrationException(string message) : base(message)
    {
    }

    public NoxIntegrationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}