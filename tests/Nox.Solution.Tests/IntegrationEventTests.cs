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

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxYamlException>()
            .WithMessage("Missing property [\"trait\"] is required.*");
    }
}