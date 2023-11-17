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

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxYamlException>()
            .WithMessage("Missing property [\"domaincontext\"] is required.*");
    }
}