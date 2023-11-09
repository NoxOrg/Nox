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

    [Fact]
    public void GetQueryParamValue_WhenQueryParamIsSetToEmptyString_ReturnsNull()
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
    [InlineData("en")]
    [InlineData("fr-CH")]
    public void GetQueryParamValue_WhenQueryParamIsSet_ReturnsValue(string value)
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
