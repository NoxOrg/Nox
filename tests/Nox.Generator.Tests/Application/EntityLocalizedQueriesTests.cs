using Xunit;

namespace Nox.Generator.Tests.Application;

public class EntityLocalizedQueriesTests
{

  
    [Fact]
    public void Can_generate_localized_entity_translations_queries()
    {
        var path = "files/yaml/presentation/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}controllers.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Application.Queries.GetCityTranslationsByIdQuery.expected.g.cs", "Application.Queries.GetCityTranslationsByIdQuery.g.cs")
            .AssertFileExistsAndContent("Application.Queries.GetCityTranslationsQuery.expected.g.cs", "Application.Queries.GetCityTranslationsQuery.g.cs");
    }
}