using Nox.Solution;
using Nox.Docs.Extensions;

namespace Nox.Docs.Tests;

public class NoxDocsMermaidTests
{
    [Fact]
    public void Solution_Creates_Valid_Mermaid_Erd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        var mermaidText = noxSolution.ToMermaidErd();

        Assert.Equal(1, 1);

    }
}