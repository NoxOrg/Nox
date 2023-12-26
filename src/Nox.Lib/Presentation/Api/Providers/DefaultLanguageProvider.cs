﻿using Microsoft.Net.Http.Headers;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Abstractions.Extensions;

namespace Nox.Presentation.Api.Providers;

public class DefaultLanguageProvider : IHttpLanguageProvider
{
    private readonly Types.CultureCode _defaultLanguage;
    private readonly HashSet<string> _supportedLanguages;

    private readonly IHttpQueryParamValueProvider _queryParamProvider;
    private readonly IHttpHeaderValueProvider _headerValueProvider;

    public DefaultLanguageProvider(
        NoxSolution solution,
        IHttpQueryParamValueProvider queryParamProvider,
        IHttpHeaderValueProvider headerValueProvider)
    {
        _defaultLanguage = Types.CultureCode.From(solution.Application!.Localization!.DefaultCulture);
        _supportedLanguages = solution.Application?.Localization?.SupportedCultures?.Select(c=>c.ToDisplayName()).ToHashSet() ?? new HashSet<string>();

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
        return !string.IsNullOrEmpty(language) && _supportedLanguages.Contains(language) ? language : null;
    }

    private string? GetHeaderLanguage()
    {
        var language = _headerValueProvider.GetHeaderValue(HeaderNames.AcceptLanguage);
        return !string.IsNullOrEmpty(language) ? language.Split(',').Select(x => x.Trim().Split(';')[0]).FirstOrDefault(_supportedLanguages.Contains) : null;
    }
}