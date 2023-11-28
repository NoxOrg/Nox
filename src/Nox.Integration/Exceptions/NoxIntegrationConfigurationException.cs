using System;

namespace Nox.Integration.Exceptions;

[Serializable]
public class NoxIntegrationConfigurationException : Exception
{
    public NoxIntegrationConfigurationException(string message) : base(message)
    {
    }

    public NoxIntegrationConfigurationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}