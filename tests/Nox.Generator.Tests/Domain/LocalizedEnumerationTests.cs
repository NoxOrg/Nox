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
            .AssertFileCount(59, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Presentation.Api.OData.CountriesController.Enumerations.Expected.g.cs", "Presentation.Api.OData.CountriesController.Enumerations.g.cs")
            .AssertFileExistsAndContent("Application.Queries.GetCountriesEnumerationsQuery.Expected.g.cs", "Application.Queries.GetCountriesEnumerationsQuery.g.cs")
            ;

    
    }
}