
using System.Net;

namespace ClientApi.Tests.Tests.Models;

public class SimpleResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = default!;
}