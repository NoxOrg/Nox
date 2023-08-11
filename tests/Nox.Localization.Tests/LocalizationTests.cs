using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

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
        var localizer = factory.Create(typeof(LocalizationTests));
        
        localizer["Hello World!"].Value.Should().Be("Hello World!");
        
        localizer["Bye {0}!", "World"].Value.Should().Be("Bye World!");

        _fixture.SetCulture("fr-FR");
        
        localizer!["Hello World!"].Value.Should().Be("Bonjour Monde!");
        
        localizer!["Bye {0}!", "World"].Value.Should().Be("au revoir World!");

    }
}