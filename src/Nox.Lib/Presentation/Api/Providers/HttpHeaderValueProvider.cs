using Microsoft.AspNetCore.Http;

namespace Nox.Presentation.Api.Providers;

public abstract class HttpHeaderValueProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    protected HttpHeaderValueProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public abstract string HeaderName { get; }
    public abstract string DefaultHeaderValue { get; }

    public string GetHeaderValue()
    {
        var result = _httpContextAccessor.HttpContext?.Request.Headers[HeaderName].ToString();
        return string.IsNullOrWhiteSpace(result) ? DefaultHeaderValue : result;
    }
}