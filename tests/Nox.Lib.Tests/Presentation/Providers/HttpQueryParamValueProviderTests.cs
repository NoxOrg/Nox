using Elastic.Apm.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Nox.Presentation.Api.Providers;
using YamlDotNet.Core.Tokens;

namespace Nox.Lib.Tests.Presentation.Providers;

public class HttpQueryParamValueProviderTests
{
    private readonly HttpQueryParamValueProvider _provider;

    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new();

    public HttpQueryParamValueProviderTests()
    {
        _provider = new HttpQueryParamValueProvider(_httpContextAccessorMock.Object);
    }

    [Fact]
    public void GetQueryParamValue_WhenQueryParamIsNotSet_ReturnsNull()
    {
        // Arrange
        // Act
        var actual = _provider.GetQueryParamValue("lang");

        // Assert
        actual.Should().BeNull();
    }

    [Theory]
    [InlineData("$lang")]
    [InlineData("language")]
    [InlineData("Accept-Language")]
    public void GetQueryParamValue_WhenUnsupportedQueryParamIsSet_ReturnsNull(string param)
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.QueryString = new QueryString($"?{param}=fr-FR");

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetQueryParamValue("lang");

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public void GetQueryParamValue_WhenQueryParamValueIsSetToEmptyString_ReturnsNull()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.QueryString = new QueryString($"?lang=");

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetQueryParamValue("lang");

        // Assert
        actual.Should().BeNull();
    }

    [Theory]
    [InlineData("lang")]
    [InlineData("Lang")]
    [InlineData("LANG")]
    [InlineData("LanG")]
    public void GetQueryParamValue_WhenCaseInsensitiveQueryParamIsSet_ReturnsValue(string param)
    {
        // Arrange
        var language = "fr-FR";

        var httpContext = new DefaultHttpContext();
        httpContext.Request.QueryString = new QueryString($"?{param}={language}");

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetQueryParamValue("lang");

        // Assert
        actual.Should().Be(language);
    }

    [Theory]
    [InlineData("en")]
    [InlineData("fr-CH")]
    public void GetQueryParamValue_WhenQueryParamValueIsSet_ReturnsValue(string value)
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.QueryString = new QueryString($"?lang={value}");

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetQueryParamValue("lang");

        // Assert
        actual.Should().Be(value);
    }
}
