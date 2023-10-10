using System.Net;

namespace Nox.Types;

public interface INoxHttpException
{
    HttpStatusCode StatusCode { get; }
}