using FluentAssertions;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests;

public class DomainEventTests
{
    [Theory]
    [InlineData("duplicate-domain-event.solution.nox.yaml")]
    public void When_duplicate_event_name_should_throw_exception(string fileName)
    {
        var solutionBuilder = new NoxSolutionBuilder().WithFile($"./files/{fileName}");

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxYamlValidationException>();   
    }
}