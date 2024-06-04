namespace Nox.Infrastructure.Persistence;

public class TypeNotFoundException : Exception
{
    public TypeNotFoundException(string typeName)
        : base($"Could not resolve type for {typeName}.")
    {

    }
}
