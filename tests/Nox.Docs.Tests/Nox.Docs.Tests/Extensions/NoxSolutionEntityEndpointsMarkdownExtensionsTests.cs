using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionEntityEndpointsMarkdownExtensionsTests
{
    [Fact]
    public void Solution_Creates_Valid_EntityEndpoints_Markdown()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("./Files/Design/sample-for-endpoints.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownEntityEndpoints();

        // Assert
        var expected = new[]
        {
            CreateMarkdownFile("People"),
            CreateMarkdownFile("Country"),
            CreateMarkdownFile("Continent"),
        };

        actual.Should().BeEquivalentTo(expected);
    }

    private static EntityMarkdownFile CreateMarkdownFile(string entity)
        => new()
        {
            Name = $"./endpoints/{entity}Endpoints.md",
            Content = ReadMarkdownFile($"{entity}Endpoints.md"),
            EntityName = entity,
        };

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
