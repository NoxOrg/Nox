using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Types;

namespace Nox.Application.Providers;

public class DefaultUserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DefaultUserProvider(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Get the user name from the X-User-Name header
    /// </summary>
    /// <returns></returns>
    public string GetUser()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers["X-User-Name"].ToString()!;
        result = string.IsNullOrWhiteSpace(result) ? "N/A" : result;
        return result;
    }
}