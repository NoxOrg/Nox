using Microsoft.AspNetCore.Http;

namespace Nox.Presentation.Api.Providers;

public class HttpQueryParamValueProvider : IHttpQueryParamValueProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpQueryParamValueProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetQueryParamValue(string key)
    {
        var result = _httpContextAccessor.HttpContext?.Request.Query[key].ToString();
        return string.IsNullOrWhiteSpace(result) ? null : result;
    }
}