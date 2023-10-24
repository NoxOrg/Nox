using Microsoft.AspNetCore.Http;
using Nox.Abstractions;
using Nox.Solution;

namespace Nox.Application.Providers;

public class DefaultLanguageProvider : HttpHeaderValueProvider, ILanguageProvider
{
    private readonly string _defaultLanguage;

    public DefaultLanguageProvider(
        NoxSolution solution,
        IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    {
        _defaultLanguage = solution.Application?.Localization?.DefaultCulture ?? "en-US"; // should we set the language or throw an exception?
    }

    public override string HeaderName => "Accept-Language";

    public override string DefaultHeaderValue => _defaultLanguage;

    public string GetLanguage() => GetHeaderValue(); // should we validate the returned language?
}