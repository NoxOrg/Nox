using System.Runtime.Serialization;

namespace Nox.Types.EntityFramework.Exceptions;

[Serializable]
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

    protected NoxEntityFrameworkException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}