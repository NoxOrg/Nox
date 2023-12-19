using Microsoft.AspNetCore.Http;
using Nox.Infrastructure;
using Nox.Solution;
using System.Net;
using System.Reflection;

namespace Nox.Middlewares;

internal record ServiceVersion(string Service, string Client, string Nox);

internal sealed class VersionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly NoxSolution _noxSolution;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly string _noxVersion = Assembly.GetExecutingAssembly().GetName().Version!.ToString();

    public VersionMiddleware(RequestDelegate next, NoxSolution noxSolution, INoxClientAssemblyProvider clientAssemblyProvider)
    {
        ArgumentNullException.ThrowIfNull(nameof(next));
        _next = next;
        _noxSolution = noxSolution;
        _clientAssemblyProvider = clientAssemblyProvider;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }
        var headers = httpContext.Response.Headers;
        headers.CacheControl = "no-store, no-cache";
        headers.Pragma = "no-cache";
        headers.Expires = "Thu, 01 Jan 1970 00:00:00 GMT";

        httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(new ServiceVersion(
            _noxSolution.Version,
            _clientAssemblyProvider.ClientAssembly.GetName().Version!.ToString(),
            _noxVersion));
    }
}
