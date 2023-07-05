namespace Nox.DatabaseProvider;

[Serializable]
public class NoxDatabaseProviderException : Exception
{
    public NoxDatabaseProviderException()
    {
    }

    public NoxDatabaseProviderException(string message)
        : base(message)
    {
    }

    public NoxDatabaseProviderException(string message, Exception inner)
        : base(message, inner)
    {
    }
}