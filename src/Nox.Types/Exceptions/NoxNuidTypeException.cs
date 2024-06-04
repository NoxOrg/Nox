using System;
using System.Runtime.Serialization;

namespace Nox.Types;

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
}