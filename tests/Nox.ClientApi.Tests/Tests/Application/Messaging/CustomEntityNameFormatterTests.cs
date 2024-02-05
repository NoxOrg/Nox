using FluentAssertions;

using Nox.Infrastructure.Messaging;

namespace ClientApi.Tests.Application.Messaging;

public class CustomEntityNameFormatterTests
{
    [Fact]
    public void WhenNonProdEnvironment_ShouldUseEnvironmentInEntityName()
    {
        // Arrange
        var formatter = new CustomEntityNameFormatter("Nox", "Cryptocash", Environments.Development);

        // Act
        var result = formatter.FormatEntityName<CloudEventMessage<ClientApi.Application.IntegrationEvents.CountryCreated>>();

        // Assert
        result.Should().Be("development.Nox.Cryptocash.Country");
    }

    [Fact]
    public void WhenProdEnvironment_ShouldNotUseEnvironmentInEntityName()
    {
        // Arrange
        var formatter = new CustomEntityNameFormatter("Nox", "Cryptocash", Environments.Production);

        // Act
        var result = formatter.FormatEntityName<CloudEventMessage<ClientApi.Application.IntegrationEvents.CountryCreated>>();

        // Assert
        result.Should().Be("Nox.Cryptocash.Country");
    }
}
