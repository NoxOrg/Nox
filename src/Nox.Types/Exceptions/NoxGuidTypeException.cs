using System;
using System.Runtime.Serialization;

namespace Nox.Types;

[Serializable]
public class NoxGuidTypeException : Exception
{
    public NoxGuidTypeException()
    { }

    public NoxGuidTypeException(string message)
        : base(message)
    { }

    public NoxGuidTypeException(string message, Exception innerException)
        : base(message, innerException)
    { }

    protected NoxGuidTypeException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }
}