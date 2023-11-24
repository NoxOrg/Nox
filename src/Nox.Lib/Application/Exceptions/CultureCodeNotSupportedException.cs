using System.Runtime.Serialization;

namespace Nox.Application.Exceptions;

[Serializable]
public class CultureCodeNotSupportedException : Exception
{
    public CultureCodeNotSupportedException()
    {
    }

    public CultureCodeNotSupportedException(string message)
        : base(message)
    {
    }

    public CultureCodeNotSupportedException(string message, Exception inner)
        : base(message, inner)
    {
    }

    // Constructor needed for serialization.
    protected CultureCodeNotSupportedException(SerializationInfo info, StreamingContext context) 
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