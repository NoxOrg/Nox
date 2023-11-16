using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionEntityDomainEventsMarkdownExtensionsTests
{
    [Fact]
    public void Solution_Creates_Valid_DomainEvents_Markdown()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./Files/Design/sample-for-domain-events.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownEntityDomainEvents()
            .OrderBy(m => m.Name);

        // Assert
        var expected = new[]
        {
            CreateMarkdownFile("CountryLocalNames"),
            CreateMarkdownFile("Country"),
            CreateMarkdownFile("Continent"),
        }
        .OrderBy(m => m.Name);

        actual.Should().BeEquivalentTo(expected);
    }

    private static EntityMarkdownFile CreateMarkdownFile(string entity)
        => new()
        {
            Name = $"./domainEvents/{entity}DomainEvents.md",
            Content = ReadMarkdownFile($"{entity}DomainEvents.md"),
            EntityName = entity,
        };

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
