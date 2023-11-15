namespace Nox.Presentation.Api.Providers;

public interface IHttpHeaderValueProvider
{
    string? GetHeaderValue(string key);
}