namespace Nox.Infrastructure.Persistence;

[Serializable]
public class TypeNotFoundException : Exception
{
    public TypeNotFoundException(string typeName)
        : base($"Could not resolve type for {typeName}.")
    {
        
    }

    protected TypeNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) 
    { 
    }
}
