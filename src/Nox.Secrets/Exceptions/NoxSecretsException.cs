namespace Nox.Secrets.Exceptions;

[Serializable]
public class NoxSecretsException : Exception
{
    public NoxSecretsException()
    {
    }

    public NoxSecretsException(string message)
        : base(message)
    {
    }

    public NoxSecretsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}