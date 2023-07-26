using System;
using System.Runtime.Serialization;

namespace Nox.Types;

[Serializable]
public class NoxNuidTypeException : Exception
{
    public NoxNuidTypeException()
    { }

    public NoxNuidTypeException(string message)
        : base(message)
    { }

    public NoxNuidTypeException(string message, Exception innerException)
        : base(message, innerException)
    { }

    protected NoxNuidTypeException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base(serializationInfo, streamingContext)
    {
    }
}