using FluentAssertions;
using Microsoft.Net.Http.Headers;
using Moq;
using Nox.Presentation.Api.Providers;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Presentation.Providers;

public class DefaultLanguageProviderTests
{
    private readonly DefaultLanguageProvider _provider;

    private readonly NoxSolution _noxSolution = new();
    private readonly Mock<IHttpHeaderValueProvider> _headerProviderMock = new();
    private readonly Mock<IHttpQueryParamValueProvider> _queryParamProviderMock = new();

    public DefaultLanguageProviderTests()
    {
        var yamlName = "solution.solution.nox.yaml";
        var yamlContent = "{name: solution, application: {localization: {supportedCultures: [en-US, fr-FR], defaultCulture: en-US}}}";

        _noxSolution = new NoxSolutionBuilder()
            .WithYamlFilesAndContent(new Dictionary<string, Func<TextReader>>
            {
                [yamlName] = () => new StringReader(yamlContent)
            })
            .AllowMissingSolutionYaml()
            .Build();

        _provider = new DefaultLanguageProvider(
            _noxSolution,
            _queryParamProviderMock.Object,
            _headerProviderMock.Object);
    }

    [Fact]
    public void Constructor_WithDefaultSolution_DoesNotThrowException()
    {
        var action = () => new DefaultLanguageProvider(new NoxSolution(), _queryParamProviderMock.Object, _headerProviderMock.Object);

        action.Should().NotThrow();
    }

    [Fact]
    public void GetLanguage_WhenNeitherQueryParamNorHeaderIsSet_ReturnsDefaultLanguage()
    {
        // Arrange
        var expected = "en-US";

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData("fr-FR")]
    [InlineData("fr-FR, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-CH, fr-FR;q=0.9, en-US;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-FR;q=0.9, en-US;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-CH, fr;q=0.9, en;q=0.8, fr-FR;q=0.7, *;q=0.5")]
    public void GetLanguage_WhenQueryParamIsNotSetAndHeaderIsSetWithSupportedValue_ReturnsHeaderValue(string headerValue)
    {
        // Arrange
        _headerProviderMock.Setup(x => x.GetHeaderValue(HeaderNames.AcceptLanguage)).Returns(headerValue);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().BeEquivalentTo(CultureCode.From("fr-FR"));
    }

    [Theory]
    [InlineData("*")]
    [InlineData("en")]
    [InlineData("fr-CH")]
    [InlineData("fr-CH, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    public void GetLanguage_WhenQueryParamIsNotSetAndHeaderIsSetWithUnsupportedValue_ReturnsDefaultValue(string headerValue)
    {        
        // Arrange
        _headerProviderMock.Setup(x => x.GetHeaderValue(HeaderNames.AcceptLanguage)).Returns(headerValue);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().BeEquivalentTo(CultureCode.From("en-US"));
    }

    [Theory]
    [InlineData("fr-FR")]
    [InlineData("fr-FR, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-CH, fr-FR;q=0.9, en-US;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-FR;q=0.9, en-US;q=0.8, de;q=0.7, *;q=0.5")]
    [InlineData("fr-CH, fr;q=0.9, en;q=0.8, fr-FR;q=0.7, *;q=0.5")]
    public void GetLanguage_WhenQueryParamIsSetWithUnsupportedValueAndHeaderIsSetWithSupportedValue_ReturnsHeaderValue(string headerValue)
    {
        // Arrange
        _queryParamProviderMock.Setup(x => x.GetQueryParamValue("lang")).Returns("zh-TW");
        _headerProviderMock.Setup(x => x.GetHeaderValue(HeaderNames.AcceptLanguage)).Returns(headerValue);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().BeEquivalentTo(CultureCode.From("fr-FR"));
    }

    [Fact]
    public void GetLanguage_WhenQueryParamAndHeaderAreSetWithUnsupportedValue_ReturnsDefaultValue()
    {        
        // Arrange
        _queryParamProviderMock.Setup(x => x.GetQueryParamValue("lang")).Returns("zh-TW");
        _headerProviderMock.Setup(x => x.GetHeaderValue(HeaderNames.AcceptLanguage)).Returns("es-MX");

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().BeEquivalentTo(CultureCode.From("en-US"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("es-MX")]
    [InlineData("en-US")]
    public void GetLanguage_WhenQueryParamIsSetWithSupportedValue_ReturnsQueryParamValue(string? headerValue)
    {
        // Arrange
        _queryParamProviderMock.Setup(x => x.GetQueryParamValue("lang")).Returns("fr-FR");
        _headerProviderMock.Setup(x => x.GetHeaderValue(HeaderNames.AcceptLanguage)).Returns(headerValue);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().BeEquivalentTo(CultureCode.From("fr-FR"));
    }
}
