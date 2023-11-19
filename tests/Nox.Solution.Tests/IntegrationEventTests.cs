using FluentAssertions;
using Nox.Solution.Exceptions;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests;

public class IntegrationEventTests
{
    [Theory]
    [InlineData("missing-trait-integration-event.solution.nox.yaml")]
    public void When_missing_trait_integration_event_should_throw_exception(string fileName)
    {
        var solutionBuilder = new NoxSolutionBuilder().WithFile($"./files/{fileName}");

        var exception = solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxYamlValidationException>()
            .Which;

        exception.Errors.Count
            .Should().Be(1);

        exception.Errors.First().ErrorMessage
            .Should().Match("Missing property [\"trait\"] is required.*");

    }
}