using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nox.Localization.Extensions;
using System.Globalization;

namespace Nox.Localization.Tests;
public class NoxLocalizationTests
{

    [Fact]
    public void Localizer_Returns_Default_Value()
    {
        var en_GB_localizer = GetStringLocalizer("en-GB");

        en_GB_localizer!["Hello World!"].Value.Should().Be("Hello World!.en-GB");

        en_GB_localizer!["Bye {0}!", "World"].Value.Should().Be("Bye World!.en-GB"); ;

        var fr_FR_localizer = GetStringLocalizer("fr-FR");

        fr_FR_localizer!["Hello World!"].Value.Should().Be("Hello World!.fr-FR");

        fr_FR_localizer!["Bye {0}!", "Ricardo"].Value.Should().Be("Bye Ricardo!.fr-FR"); ;

    }

    private static IStringLocalizer GetStringLocalizer(string? culture = null)
    {
        // Optionally Override culture

        if(culture is not null) 
        { 
            CultureInfo.CurrentCulture = new CultureInfo(culture);
        }

        // Simulate app startup

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddNoxLocalization();

        var app = builder.Build();

        var factory = app.Services.GetService<IStringLocalizerFactory>();

        // Simulate DI creation

        return factory!.Create(typeof(NoxLocalizationTests)); ;
    }
}