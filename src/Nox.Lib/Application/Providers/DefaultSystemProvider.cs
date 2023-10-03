using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultSystemProvider : ISystemProvider
{
    private const string SystemNameHeader = "X-System-Name";
    private const string DefaultSystemName = "N/A";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DefaultSystemProvider(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Get the system name from the X-System-Name header
    /// </summary>
    /// <returns></returns>
    public string GetSystem()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers[SystemNameHeader].ToString();
        result ??= DefaultSystemName;
        return result;
    }
}