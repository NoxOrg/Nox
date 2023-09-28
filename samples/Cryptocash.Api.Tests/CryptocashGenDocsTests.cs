using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;

namespace Cryptocash.Tests;

public class CryptocashGenDocsTests
{
    [Fact]
    public void Solution_Creates_Valid_Documentation()
    {
        var rootPath = "../../../../.nox";

        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile($"{rootPath}/design/cryptocash.solution.nox.yaml")
            .Build();

        var action = () => noxSolution.GenerateMarkdownReadme($"{rootPath}/docs");

        action.Should().NotThrow();
    }
}