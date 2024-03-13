using Xunit;

namespace Nox.Generator.Tests.Domain;

public class LocalizedEnumerationTests
{
    [Fact]
    public void Can_generate_domain_api_controller_files()
    {
        var path = "files/yaml/presentation/";

        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}controllers.solution.nox.yaml"
        };

        var filesShouldExist = new[]
        {
            "Presentation.Api.OData.CountriesController.Enumerations.g.cs",
            "Application.Queries.GetCountriesEnumerationsQuery.g.cs",
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(94, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Presentation.Api.OData.CountriesController.Enumerations.g.cs")
            .AssertFileWasGenerated( "Application.Queries.GetCountriesEnumerationsQuery.g.cs")
            ;

    
    }
}