using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Moq;
using Nox.Presentation.Api.Providers;

namespace Nox.Lib.Tests.Presentation.Providers;

public class HttpHeaderValueProviderTests
{
    private readonly HttpHeaderValueProvider _provider;

    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new();

    public HttpHeaderValueProviderTests()
    {
        _provider = new HttpHeaderValueProvider(_httpContextAccessorMock.Object);
    }

    [Fact]
    public void GetHeaderValue_WhenHeaderIsNotSet_ReturnsNull()
    {
        // Arrange
        // Act
        var actual = _provider.GetHeaderValue(HeaderNames.AcceptLanguage);

        // Assert
        actual.Should().BeNull();
    }

    [Fact]
    public void GetHeaderValue_WhenHeaderIsSetToEmptyString_ReturnsNull()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Append(HeaderNames.AcceptLanguage, string.Empty);

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetHeaderValue(HeaderNames.AcceptLanguage);

        // Assert
        actual.Should().BeNull();
    }

    [Theory]
    [InlineData("*")]
    [InlineData("en")]
    [InlineData("fr-CH")]
    [InlineData("fr-CH, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5")]
    public void GetHeaderValue_WhenHeaderIsSet_ReturnsValue(string value)
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Append(HeaderNames.AcceptLanguage, value);

        _httpContextAccessorMock.SetupGet(x => x.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetHeaderValue(HeaderNames.AcceptLanguage);

        // Assert
        actual.Should().Be(value);
    }
}
