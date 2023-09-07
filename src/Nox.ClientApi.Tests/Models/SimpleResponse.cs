
using System.Net;

namespace Nox.ClientApi.Tests.Models;

public class SimpleResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = default!;
}