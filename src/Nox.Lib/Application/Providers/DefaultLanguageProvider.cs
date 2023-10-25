using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Solution;

namespace Nox.Application.Providers;

public class DefaultLanguageProvider : HttpHeaderValueProvider, ILanguageProvider
{
    private readonly string _defaultLanguage;
    private readonly HashSet<string> _supportedLanguages;

    public DefaultLanguageProvider(
        NoxSolution solution,
        IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    {
        _defaultLanguage = solution.Application?.Localization?.DefaultCulture ?? "en-US"; // should we set the language or throw an exception?
        _supportedLanguages = solution.Application?.Localization?.SupportedCultures?.ToHashSet() ?? new HashSet<string>();
    }

    public override string HeaderName => "Accept-Language";

    public override string DefaultHeaderValue => _defaultLanguage;

    public string GetLanguage()
    {
        var language = GetHeaderValue();
        language = language.Split(',').Select(x => x.Trim()).First();

        return _supportedLanguages.Contains(language) ? language : _defaultLanguage;
    }
}