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
            .AssertFileWasGenerated("Application.Queries.GetCityTranslationsByIdQuery.g.cs")
            .AssertFileWasGenerated("Application.Queries.GetCityTranslationsQuery.g.cs");
    }
}