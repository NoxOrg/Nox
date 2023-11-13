using Microsoft.AspNetCore.Http;

namespace Nox.Presentation.Api.Providers;

public class HttpHeaderValueProvider : IHttpHeaderValueProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpHeaderValueProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetHeaderValue(string key)
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers[key].ToString();
        return string.IsNullOrWhiteSpace(result) ? null : result;
    }
}