using System.Net;

namespace Nox.Exceptions;

[Serializable]
public class DatabaseSaveException : Exception, IApplicationException
{
    public DatabaseSaveException() { }

    public DatabaseSaveException(string message)
        : base(message)
    {
    }

    public DatabaseSaveException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public HttpStatusCode? StatusCode => HttpStatusCode.InternalServerError;

    public string ErrorCode => "no_records_were_saved";

    public object? ErrorDetails => throw new NotImplementedException();
}