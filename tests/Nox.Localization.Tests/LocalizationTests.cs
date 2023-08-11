using System.Globalization;
using System.Reflection;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nox.Localization.DbContext;
using Nox.Localization.Extensions;
using Nox.Solution;

namespace Nox.Localization.Tests;

public class LocalizationTests: IClassFixture<WebApplicationFixture>
{
    // IStringLocalizer _userModelLocalizer; // always in model db as seperate schema "l11n"
    // IStringLocalizer _appModelLocalizer; // db
    // IStringLocalizer _appUiLocalizer;  // static
    
    private readonly WebApplicationFixture _fixture;

    public LocalizationTests(WebApplicationFixture fixture)
    {
        _fixture = fixture;
    }

    
    
    [Fact]
    public void Localizer_Returns_Default_Value()
    {
        _fixture.SetCulture("en-GB");
        
        var factory = _fixture.FixtureWebApplication!.Services.GetRequiredService<IStringLocalizerFactory>();
        var enGbLocalizer = factory.Create(typeof(LocalizationTests));

        enGbLocalizer["Hello World!"].Value.Should().Be("Hello World!.en-GB");
        
        enGbLocalizer["Bye {0}!", "World"].Value.Should().Be("Bye World!.en-GB"); ;

        // var fr_FR_localizer = GetStringLocalizer("fr-FR");
        //
        // fr_FR_localizer!["Hello World!"].Value.Should().Be("Bonjour Monde!");
        //
        // fr_FR_localizer!["Bye {0}!", "Ricardo"].Value.Should().Be("Bye Ricardo!.fr-FR");

    }
}