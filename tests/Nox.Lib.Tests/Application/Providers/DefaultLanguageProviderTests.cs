using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Nox.Application.Providers;
using Nox.Solution;

namespace Nox.Lib.Tests.Application.Providers;

public class DefaultLanguageProviderTests
{
    private readonly DefaultLanguageProvider _provider;

    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new();
    private readonly NoxSolution _noxSolution = new();

    public DefaultLanguageProviderTests()
    {
        var yamlName = "solution.solution.nox.yaml";
        var yamlContent = "{name: solution, application: {localization: {supportedCultures: [en-US, fr-FR], defaultCulture: en-US}}}";

        _noxSolution = new NoxSolutionBuilder()
            .UseYamlFilesAndContent(new Dictionary<string, Func<TextReader>>
            {
                [yamlName] = () => new StringReader(yamlContent)
            })
            .AllowMissingSolutionYaml()
            .Build();

        _provider = new DefaultLanguageProvider(
            _noxSolution,
            _httpContextAccessorMock.Object);
    }

    [Fact]
    public void HeaderName_ReturnsCorrectValue()
    {
        // Arrange
        var expected = "Accept-Language";

        // Act
        var actual = _provider.HeaderName;

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetLanguage_WhenHeaderIsNotSet_ReturnsDefaultLanguage()
    {
        // Arrange
        var expected = "en-US";

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("*")]
    [InlineData("en")]
    [InlineData("fr-CH")]
    [InlineData("fr-CH, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    public void GetLanguage_WhenHeaderIsSetWithUnsupportedLanguage_ReturnsDefaultValue(string value)
    {
        // Arrange
        var expected = "en-US";

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Add("Accept-Language", value);

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("fr-FR")]
    [InlineData("fr-FR, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    public void GetLanguage_WhenHeaderIsSet_ReturnsHeaderValue(string value)
    {
        // Arrange
        var expected = "fr-FR";

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Add("Accept-Language", value);

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().Be(expected);
    }
}
