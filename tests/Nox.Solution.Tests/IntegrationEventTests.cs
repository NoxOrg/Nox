using FluentAssertions;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests;

public class IntegrationEventTests
{
    [Theory]
    [InlineData("missing-domaincontext-integration-event.solution.nox.yaml")]
    public void WhenMissingDomainContext_ShouldThrowException(string fileName)
    {
        var solutionBuilder = new NoxSolutionBuilder().WithFile($"./files/{fileName}");

        var exception = solutionBuilder
                  .Invoking(solution => solution.Build())
                  .Should().Throw<NoxYamlValidationException>()
                  .Which;

        exception.Errors.Count
            .Should().Be(1);

        exception.Errors[0].ErrorMessage
            .Should().Match("Missing property [\"domainContext\"] is required.*");
    }
}