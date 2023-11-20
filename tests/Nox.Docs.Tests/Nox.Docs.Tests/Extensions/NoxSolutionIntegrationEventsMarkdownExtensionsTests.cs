using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionIntegrationEventsMarkdownExtensionsTests
{
    [Fact]
    public void Solution_Creates_Valid_IntegrationEvents_Markdown()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./Files/Design/sample-for-integration-events.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownIntegrationEvents();

        // Assert
        var expected = new MarkdownFile
        {
            Name = "./IntegrationEvents.md",
            Content = ReadMarkdownFile("IntegrationEvents.md"),
        };

        actual.Should().BeEquivalentTo(expected);
    }

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
