using System.Runtime.Serialization;

namespace Nox.PackageManager.Exceptions;

[Serializable]
public class NoxPackageManagerException : Exception
{
    public NoxPackageManagerException()
    {
    }

    public NoxPackageManagerException(string? message)
        : base(message)
    {
    }

    public NoxPackageManagerException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected NoxPackageManagerException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}