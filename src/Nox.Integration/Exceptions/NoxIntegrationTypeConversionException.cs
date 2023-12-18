namespace Nox.Integration.Exceptions;

[Serializable]
public class NoxIntegrationTypeConversionException : Exception
{
    public NoxIntegrationTypeConversionException(string message) : base(message)
    {
    }

    public NoxIntegrationTypeConversionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}