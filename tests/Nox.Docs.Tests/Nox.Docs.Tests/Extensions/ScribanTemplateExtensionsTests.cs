using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;
using Scriban;

namespace Nox.Docs.Tests;

public class ScribanTemplateExtensionsTests
{
    [Fact]
    public void Resource_Reads_Valid_Scriban_Template_File()
    {
        // Arrange
        // Act
        var actual = "Nox.Docs.Templates.EntityEndpoints.template.md".ReadScribanTemplate();

        // Assert
        var expected = Template.Parse(ReadMarkdownFile("EntityEndpoints.template.md"));

        actual.Page.ToString().Should().Be(expected.Page.ToString());
    }

    [Fact]
    public void Solution_Renders_Valid_Scriban_Template()
    {
        // Arrange
        var noxSolution = new NoxSolutionBuilder()
            .WithFile("./Files/Design/sample-for-endpoints.solution.nox.yaml")
            .Build();

        var model = new Dictionary<string, object>
        {
            ["entity"] = noxSolution.Domain!.Entities.First(x => x.Name == "Country"),
        };

        var template = "Nox.Docs.Templates.EntityEndpoints.template.md".ReadScribanTemplate();

        // Act
        var actual = template.RenderScribanTemplate(model);

        // Assert
        var expected = ReadMarkdownFile("CountryEndpoints.md");

        actual.Should().BeEquivalentTo(expected);
    }

    private static string ReadMarkdownFile(string name)
        => File.ReadAllText($"./Files/Markdown/{name}");
}