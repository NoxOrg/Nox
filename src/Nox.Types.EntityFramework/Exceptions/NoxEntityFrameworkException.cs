using System.Runtime.Serialization;

namespace Nox.Types.EntityFramework.Exceptions;

public class NoxEntityFrameworkException : Exception
{
    public NoxEntityFrameworkException()
    {
    }

    public NoxEntityFrameworkException(string message) : base(message)
    {
    }

    public NoxEntityFrameworkException(string message, Exception inner) : base(message, inner)
    {
    }
}