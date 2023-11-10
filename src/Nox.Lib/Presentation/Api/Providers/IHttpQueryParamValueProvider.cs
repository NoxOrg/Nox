namespace Nox.Presentation.Api.Providers;

public interface IHttpQueryParamValueProvider
{
    string? GetQueryParamValue(string key);
}