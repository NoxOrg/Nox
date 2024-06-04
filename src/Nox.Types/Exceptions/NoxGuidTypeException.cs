using System;
using System.Runtime.Serialization;

namespace Nox.Types;

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
}