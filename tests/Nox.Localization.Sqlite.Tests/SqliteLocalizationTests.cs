using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Nox.Localization.Sqlite.Tests;

public class SqliteLocalizationTests: IClassFixture<WebApplicationFixture>
{
    // IStringLocalizer _userModelLocalizer; // always in model db as seperate schema "l11n"
    // IStringLocalizer _appModelLocalizer; // db
    // IStringLocalizer _appUiLocalizer;  // static
    
    private readonly WebApplicationFixture _fixture;
    
    public SqliteLocalizationTests(WebApplicationFixture fixture)
    {
        _fixture = fixture;
        _fixture.InitDatabase();
    }
    
#if DEBUG
    [Fact]
#else
    [Fact (Skip = "Only available in local tests, github does not like an in memory sqlite database")]
#endif      
    public void Localizer_Returns_Default_Value()
    {
        _fixture.SetCulture("en-GB");
        
        var factory = _fixture.FixtureWebApplication!.Services.GetRequiredService<IStringLocalizerFactory>();
        var localizer = factory.Create(typeof(SqliteLocalizationTests));
        
        localizer["Hello World!"].Value.Should().Be("Hello World!");
        
        localizer["Bye {0}!", "World"].Value.Should().Be("Bye World!");

        _fixture.SetCulture("fr-FR");
        
        localizer!["Hello World!"].Value.Should().Be("Bonjour Monde!");
        
        localizer!["Bye {0}!", "World"].Value.Should().Be("au revoir World!");

    }

    public void Temp()
    {
        // var defaultCultureName = dollar.getLocalizedValue("Name");
        // var enUsCultureName = dollar.getLocalizedValue("Name", "en-US");
        // var frFrCultureName = dollar.getLocalizedValue("Name", "fr-FR"); // must find fr-FR or fall back to fr or fall back to default-culture
        //
        // dollar.setLocalizedValue("Name", "fr-FR", "bonjour");
        
        //if culture id default store in entity field and translations table
        //


    }
}