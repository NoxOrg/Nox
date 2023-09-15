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
            .UseYamlFile("./Files/Design/sample-for-domain-events.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownEntityDomainEvents();

        // Assert
        var expected = new[]
        {
            new EntityMarkdownFile
            {
                Name = "./domainEvents/ContinentDomainEvents.md",
                Content = ReadMarkdownFile("ContinentDomainEvents.md"),
                EntityName = "Continent",
            },
            new EntityMarkdownFile
            {
                Name = "./domainEvents/CountryDomainEvents.md",
                Content = ReadMarkdownFile("CountryDomainEvents.md"),
                EntityName = "Country",
            },
            new EntityMarkdownFile
            {
                Name = "./domainEvents/CountryLocalNamesDomainEvents.md",
                Content = ReadMarkdownFile("CountryLocalNamesDomainEvents.md"),
                EntityName = "CountryLocalNames",
            },
        };

        actual.Should().BeEquivalentTo(expected);
    }

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
