using System.Runtime.Serialization;

namespace Nox.Application.Exceptions;

[Serializable]
public class CultureCodeMismatchException : Exception
{
    public CultureCodeMismatchException()
    {
    }

    public CultureCodeMismatchException(string message)
        : base(message)
    {
    }

    public CultureCodeMismatchException(string message, Exception inner)
        : base(message, inner)
    {
    }

    // Constructor needed for serialization.
    protected CultureCodeMismatchException(SerializationInfo info, StreamingContext context) 
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