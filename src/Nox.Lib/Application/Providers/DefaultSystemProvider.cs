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
    public string GetSystem() => (_httpContextAccessor.HttpContext?.Request.Headers["X-System-Name"] ?? "N/A")!;
}