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

    public DefaultLanguageProviderTests()
    {
        _provider = new DefaultLanguageProvider(
            new NoxSolution(),
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

    [Fact]
    public void GetLanguage_WhenHeaderIsSet_ReturnsHeaderValue()
    {
        // Arrange
        var expected = "fr-FR";

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Add("Accept-Language", expected);

        _httpContextAccessorMock.SetupGet(accessor => accessor.HttpContext).Returns(httpContext);

        // Act
        var actual = _provider.GetLanguage();

        // Assert
        actual.Should().Be(expected);
    }
}
