using System.Globalization;
using System.Reflection;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Nox.Localization.Extensions;

namespace Nox.Localization.Tests;

public class LocalizationTests
{
    // IStringLocalizer _userModelLocalizer; // always in model db as seperate schema "l11n"
    // IStringLocalizer _appModelLocalizer; // db
    // IStringLocalizer _appUiLocalizer;  // static

    [Fact]
    public void Localizer_Returns_Default_Value()
    {
        // var en_GB_localizer = GetStringLocalizer("en-GB");
        //
        // en_GB_localizer!["Hello World!"].Value.Should().Be("Hello World!.en-GB");
        //
        // en_GB_localizer!["Bye {0}!", "World"].Value.Should().Be("Bye World!.en-GB"); ;
        //
        // var fr_FR_localizer = GetStringLocalizer("fr-FR");
        //
        // fr_FR_localizer!["Hello World!"].Value.Should().Be("Bonjour Monde!");
        //
        // fr_FR_localizer!["Bye {0}!", "Ricardo"].Value.Should().Be("Bye Ricardo!.fr-FR");

    }

    private static IStringLocalizer GetStringLocalizer(string? culture = null)
    {
        // Optionally Override culture

        if (culture is not null)
        {
            CultureInfo.CurrentCulture = new CultureInfo(culture); // http request or message header
        }

        // Simulate app startup

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddNoxLib(configure =>
        {
            configure.WithClientAssembly(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddNoxLocalization();

        builder.Services.AddDbContext<TestDbContext>(options =>
        {
            options.UseSqlite("Data Source=localization.db");
        });

        var app = builder.Build();

        app.UseNox();

        var factory = app.Services.GetRequiredService<IStringLocalizerFactory>();

        // Simulate DI creation

        return factory.Create(typeof(LocalizationTests)); ;
    }
}