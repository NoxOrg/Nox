using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Nox.Solution;
using Nox.Types;

namespace Nox.Presentation.Api.Providers;

public class DefaultLanguageProvider : HttpHeaderValueProvider, IHttpLanguageProvider
{
    private readonly CultureCode _defaultLanguage;
    private readonly HashSet<string> _supportedLanguages;

    public DefaultLanguageProvider(
        NoxSolution solution,
        IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    {
        _defaultLanguage = CultureCode.From(solution.Application!.Localization!.DefaultCulture);
        _supportedLanguages = solution.Application?.Localization?.SupportedCultures?.ToHashSet() ?? new HashSet<string>();
    }

    public override string HeaderName => HeaderNames.AcceptLanguage;

    public override string DefaultHeaderValue => _defaultLanguage.Value;

    public CultureCode GetLanguage()
    {
        var language = GetHeaderValue();
        language = language.Split(',').Select(x => x.Trim().Split(';')[0]).FirstOrDefault(_supportedLanguages.Contains);

        return string.IsNullOrEmpty(language) ? _defaultLanguage : CultureCode.From(language);
    }
}