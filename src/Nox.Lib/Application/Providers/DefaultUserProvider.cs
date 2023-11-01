using Microsoft.AspNetCore.Http;
using Nox.Abstractions;

namespace Nox.Application.Providers;

internal sealed class DefaultUserProvider : IUserProvider
{
    private const string UserNameHeader = "X-User-Name";
    private const string DefaultUserName = "N/A";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DefaultUserProvider(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Get the user name from the X-User-Name header
    /// </summary>
    /// <returns>Returns the user name or N/A if not found</returns>
    public string GetUser()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers[UserNameHeader].ToString();
        result = string.IsNullOrWhiteSpace(result) ? DefaultUserName : result;
        return result;
    }
}