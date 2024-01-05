using Microsoft.Net.Http.Headers;
using Nox.Solution;
using Nox.Types;

namespace Nox.Presentation.Api.Providers;

internal sealed class DefaultLanguageProvider : IHttpLanguageProvider
{
    private readonly CultureCode _defaultLanguage;
    private readonly IHttpQueryParamValueProvider _queryParamProvider;
    private readonly IHttpHeaderValueProvider _headerValueProvider;

    private readonly Localization _localization;

    public DefaultLanguageProvider(
        NoxSolution solution,
        IHttpQueryParamValueProvider queryParamProvider,
        IHttpHeaderValueProvider headerValueProvider)
    {
        _defaultLanguage = CultureCode.From(solution.Application!.Localization!.DefaultCulture);
        _localization = solution.Application!.Localization!;
        _queryParamProvider = queryParamProvider;
        _headerValueProvider = headerValueProvider;
    }

    public Types.CultureCode GetLanguage()
    {
        var language = GetQueryParamLanguage() ?? GetHeaderLanguage() ?? _defaultLanguage.Value;
        return Types.CultureCode.From(language);
    }

    private string? GetQueryParamLanguage()
    {
        var language = _queryParamProvider.GetQueryParamValue(QueryParams.Language);
        return !string.IsNullOrEmpty(language) && _localization.SupportedCulturesDisplayNames.Contains(language) ? language : null;
    }

    private string? GetHeaderLanguage()
    {
        var language = _headerValueProvider.GetHeaderValue(HeaderNames.AcceptLanguage);
        return !string.IsNullOrEmpty(language) ? language.Split(',').Select(x => x.Trim().Split(';')[0]).FirstOrDefault(_localization.SupportedCulturesDisplayNames.Contains) : null;
    }
}