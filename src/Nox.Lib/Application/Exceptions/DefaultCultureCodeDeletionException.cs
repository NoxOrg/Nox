using System.Runtime.Serialization;

namespace Nox.Application.Exceptions;

[Serializable]
public class DefaultCultureCodeDeletionException : Exception, ISerializable
{
    public DefaultCultureCodeDeletionException()
    {
    }

    public DefaultCultureCodeDeletionException(string message)
        : base(message)
    {
    }

    public DefaultCultureCodeDeletionException(string message, Exception inner)
        : base(message, inner)
    {
    }

    
    protected DefaultCultureCodeDeletionException(SerializationInfo info, StreamingContext context) 
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