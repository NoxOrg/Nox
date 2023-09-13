using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Solution;

namespace Nox.Docs.Tests;

public class NoxDocsEntityEndpointsTests
{
    [Fact]
    public void Solution_Creates_Valid_EntityEndpoint_Markdown()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        var docs = noxSolution.ToMarkdownEntityEndpoints();

        docs.Should().NotBeEmpty();
    }
}
