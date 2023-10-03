using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultSystemProvider : ISystemProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DefaultSystemProvider(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Get the system name from the X-System-Name header
    /// </summary>
    /// <returns></returns>
    public string GetSystem()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers["X-System-Name"].ToString();
        result ??= string.Empty;
        return result;
    }
}