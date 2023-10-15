using Nox.Generator.Tests.Flows;
using Xunit;

namespace Nox.Generator.Tests.Presentation;

public class ApiControllerTest : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public ApiControllerTest(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

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
            "Domain.Country.g.cs",
            "Meta.CountryMetadata.g.cs",
            //"UpdatePopulationStatisticsCommandHandlerBase.g.cs",
            //"GetCountriesByContinentQueryBase.g.cs"
        };

        var contentCheckerFlow = _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(54, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles");

        // check controllers
        CheckController("CountriesController", contentCheckerFlow);
        CheckController("CompoundKeysEntitiesController", contentCheckerFlow);
    }

    private void CheckController(string controllerName, IGeneratorContentTestFlow contentCheckerFlow)
    {
        var controllerFileName = $"Presentation.Api.OData.{controllerName}.g.cs";
        var controllerEntityFileName = $"Presentation.Api.OData.{controllerName}.Entity.g.cs";
        var controllerCustomQueriesFileName = $"Presentation.Api.OData.{controllerName}.CustomQueries.g.cs";
        var controllerCustomCommandsFileName = $"Presentation.Api.OData.{controllerName}.CustomCommands.g.cs";
        var controllerRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.Relationships.g.cs";
        var controllerOwnedRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.OwnedRelationships.g.cs";

        contentCheckerFlow.Check(controllerFileName, controllerFileName);
        contentCheckerFlow.Check(controllerEntityFileName, controllerEntityFileName);
        contentCheckerFlow.Check(controllerCustomQueriesFileName, controllerCustomQueriesFileName);
        contentCheckerFlow.Check(controllerCustomCommandsFileName, controllerCustomCommandsFileName);
        contentCheckerFlow.Check(controllerRelationshipsFileName, controllerRelationshipsFileName);
        contentCheckerFlow.Check(controllerOwnedRelationshipsFileName, controllerOwnedRelationshipsFileName);
    }
}