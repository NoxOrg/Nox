using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Solution;
using System.Text.RegularExpressions;

namespace Nox.Application.Providers;

public class DefaultLanguageProvider : HttpHeaderValueProvider, ILanguageProvider
{
    private readonly string _defaultLanguage;
    private readonly HashSet<string> _supportedLanguages;

    private static readonly Regex AcceptLanguageHeaderRegex = new("^(?<lang>[a-z]{2}(?:\\-[A-Za-z]+){0,2})(?:\\,\\s*(?:\\*|[a-z]{2}(?:\\-[A-Za-z]+){0,2})\\;q\\=\\d+\\.\\d+)*$");

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

        var match = AcceptLanguageHeaderRegex.Match(language);
        if (match.Success) language = match.Groups["lang"].Value;

        return _supportedLanguages.Contains(language) ? language : _defaultLanguage;
    }
}