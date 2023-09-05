using Nox.Solution;
using Nox.Docs.Extensions;

namespace Cryptocash.Api.Tests;

public class CryptocashGenDocsTests
{
    [Fact]
    public void Solution_Creates_Valid_Documentation()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("../../../../.nox/design/cryptocash.solution.nox.yaml")
            .Build();

        var docs = noxSolution.ToMarkdownReadme();

        File.WriteAllText("../../../../README.md", docs);
    }
}