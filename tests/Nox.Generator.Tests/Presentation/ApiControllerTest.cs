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

        var contentCheckerFlow = GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(87, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles");

        CheckController("CountriesController", contentCheckerFlow);
        CheckController("CompoundKeysEntitiesController", contentCheckerFlow);
        CheckController("CitiesController", contentCheckerFlow, true);
    }

    private static void CheckController(string controllerName, IGeneratorContentTestFlow contentCheckerFlow, bool hasTranslations = false)
    {
        var controllerFileName = $"Presentation.Api.OData.{controllerName}.g.cs";
        var controllerEntityFileName = $"Presentation.Api.OData.{controllerName}.Entity.g.cs";
        var controllerCustomQueriesFileName = $"Presentation.Api.OData.{controllerName}.CustomQueries.g.cs";
        var controllerCustomCommandsFileName = $"Presentation.Api.OData.{controllerName}.CustomCommands.g.cs";
        var controllerRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.Relationships.g.cs";
        var controllerOwnedRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.OwnedRelationships.g.cs";
        var controllerTranslationsFileName = $"Presentation.Api.OData.{controllerName}.Translations.g.cs";

        contentCheckerFlow.AssertFileWasGenerated(controllerFileName);
        contentCheckerFlow.AssertFileWasGenerated(controllerEntityFileName);
        contentCheckerFlow.AssertFileWasGenerated(controllerCustomQueriesFileName);
        contentCheckerFlow.AssertFileWasGenerated(controllerCustomCommandsFileName);
        contentCheckerFlow.AssertFileWasGenerated(controllerRelationshipsFileName);
        contentCheckerFlow.AssertFileWasGenerated(controllerOwnedRelationshipsFileName);
        if (hasTranslations)
        {
            contentCheckerFlow.AssertFileWasGenerated(controllerTranslationsFileName);
        }

    }
}