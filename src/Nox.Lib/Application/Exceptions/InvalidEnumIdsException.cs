using System.Runtime.Serialization;

namespace Nox.Application.Exceptions;

[Serializable]
public class InvalidEnumIdsException : Exception
{
    public InvalidEnumIdsException()
    {
    }

    public InvalidEnumIdsException(string message)
        : base(message)
    {
    }

    public InvalidEnumIdsException(string message, Exception inner)
        : base(message, inner)
    {
    }

    // Constructor needed for serialization.
    protected InvalidEnumIdsException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {        
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null)
            throw new ArgumentNullException(nameof(info));
        base.GetObjectData(info, context);
    }
}