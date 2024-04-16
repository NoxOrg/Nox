using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Docs.Extensions;
using FluentAssertions;
using Scriban;
using Nox.Types;

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

        var entity = noxSolution.Domain!.Entities.First(x => x.Name == "Country");

        var enumerationAttributes = GetEnumerationAttributes(entity);
        var ownedEntitiesWithLocalizedAttributes = entity.OwnedRelationships
            .Select(x => new
            {
                IsWithMultiEntity = x.WithMultiEntity,
                OwnedEntity = x.Related.Entity,
                LocalizedAttributes = x.Related.Entity.GetLocalizedAttributes(),
            });

        var model = new Dictionary<string, object>
        {
            ["apiRoutePrefix"] = noxSolution.Presentation!.ApiConfiguration!.ApiRoutePrefix,
            ["entity"] = entity,
            ["enumerationAttributes"] = enumerationAttributes,
            ["ownedLocalizedRelationships"] = ownedEntitiesWithLocalizedAttributes,
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

    private static IEnumerable<object> GetEnumerationAttributes(Entity entity)
        => entity.Attributes
        .Where(attribute => attribute.Type == NoxType.Enumeration)
        .Select(attribute => new
        {
            Attribute = attribute,
            EntityNameForEnumeration = $"{entity.Name}{attribute.Name}Dto",
            EntityNameForLocalizedEnumeration = $"{entity.Name}{attribute.Name}LocalizedDto",
            IsLocalized = attribute.EnumerationTypeOptions?.IsLocalized == true,
            EntityDtoNameForUpsertLocalizedEnumeration = $"{entity.Name}{attribute.Name}UpsertLocalizedDto"
        });
}