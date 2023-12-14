using FluentAssertions;
using Nox.Docs.Extensions;
using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Tests.Extensions;

public class NoxSolutionCustomApiRoutesMarkdownExtensionsTests
{
    [Fact]
    public void Solution_Creates_Valid_CustomApiRoutes_Markdown()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./Files/Design/sample-for-custom-api-routes.solution.nox.yaml")
            .Build();

        // Act
        var actual = noxSolution.ToMarkdownCustomApiRoutes();

        // Assert
        var expected = new MarkdownFile
        {
            Name = "./CustomApiRoutes.md",
            Content = ReadMarkdownFile("CustomApiRoutes.md"),
        };

        actual.Should().BeEquivalentTo(expected);
    }

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}
