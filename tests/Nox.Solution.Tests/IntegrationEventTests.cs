using FluentAssertions;
using Nox.Solution.Exceptions;

namespace Nox.Solution.Tests;

public class IntegrationEventTests
{
    [Theory]
    [InlineData("missing-trait-integration-event.solution.nox.yaml")]
    public void When_missing_trait_integration_event_should_throw_exception(string fileName)
    {
        var solutionBuilder = new NoxSolutionBuilder().UseYamlFile($"./files/{fileName}");

        try
        {
            solutionBuilder.Build();
            throw new Exception("Previous code should throw.");
        }
        catch (NoxSolutionConfigurationException ex)
        {
            ex.Message.Should().Contain("Missing property [\"trait\"]");
        }
    }
}