using Nox.Solution;
using Nox.Docs.Extensions;

namespace Cryptocash.Api.Tests;

public class CryptocashApiMermaidTests
{
    [Fact]
    public void Solution_Creates_Valid_Mermaid_Erd()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("../../../../Cryptocash.Api/.nox/design/cryptocashapi.solution.nox.yaml")
            .Build();

        var mermaidText = noxSolution.ToMermaidErd();

        Assert.False(String.IsNullOrWhiteSpace(mermaidText));
    }
}