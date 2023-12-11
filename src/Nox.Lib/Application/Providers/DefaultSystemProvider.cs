using Microsoft.AspNetCore.Http;
using Nox.Abstractions;

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
    /// <returns>Returns the system name or N/A if not found</returns>
    public string GetSystem()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers[SystemNameHeader].ToString();
        result = string.IsNullOrWhiteSpace(result) ? DefaultSystemName : result;
        return result;
    }
}