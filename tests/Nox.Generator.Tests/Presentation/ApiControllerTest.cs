using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new AdditionalSourceText(File.ReadAllText($"./{path}controllers.solution.nox.yaml"), $"{path}/controllers.solution.nox.yaml"),
        };

        // trackIncrementalGeneratorSteps allows to report info about each step of the generator
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            generators: new[] { _fixture.TestGenerator },
            additionalTexts: additionalFiles,
            driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

        // Run the generator
        driver = driver.RunGenerators(_fixture.TestCompilation!);

        // Assert the driver doesn't recompute the output
        var result = driver.GetRunResult().Results.Single();
        var allOutputs = result.TrackedOutputSteps.SelectMany(outputStep => outputStep.Value).SelectMany(output => output.Outputs);
        Assert.NotNull(allOutputs);
        Assert.Single(allOutputs);

        var generatedSources = result.GeneratedSources;
        Assert.Equal(54, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "Application.ServiceCollectionExtensions.g.cs"), "ServiceCollectionExtensions.g.cs not generated");

        // Check base files
        Assert.True(generatedSources.Any(s => s.HintName == "0.Generator.g.cs"), "Generator.g.cs not generated");

        // check entities/queries/commands
        Assert.True(generatedSources.Any(s => s.HintName == "Domain.Country.g.cs"), "Country.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "Meta.CountryMetadata.g.cs"), "Country.Meta.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "DtoDynamic.UpdatePopulationStatistics.g.cs"), "UpdatePopulationStatistics.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "UpdatePopulationStatisticsCommandHandlerBase.g.cs"), "UpdatePopulationStatisticsCommandHandlerBase.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "DtoDynamic.CountryInfo.g.cs"), "CountryInfo.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "GetCountriesByContinentQueryBase.g.cs"), "GetCountriesByContinentQuery.g.cs not generated");

        // check controllers
        CheckController("CountriesController", generatedSources);
        CheckController("CompoundKeysEntitiesController", generatedSources);

        //can further extend this test to verify contents of source files.
    }

    private void CheckController(string controllerName, ImmutableArray<GeneratedSourceResult> generatedSources)
    {
        var controllerFileName = $"Presentation.Api.OData.{controllerName}.g.cs";
        var controllerEntityFileName = $"Presentation.Api.OData.{controllerName}.Entity.g.cs";
        var controllerCustomQueriesFileName = $"Presentation.Api.OData.{controllerName}.CustomQueries.g.cs";
        var controllerCustomCommandsFileName = $"Presentation.Api.OData.{controllerName}.CustomCommands.g.cs";
        var controllerRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.Relationships.g.cs";
        var controllerOwnedRelationshipsFileName = $"Presentation.Api.OData.{controllerName}.OwnedRelationships.g.cs";

        Assert.True(generatedSources.Any(s => s.HintName == controllerFileName), $"{controllerFileName} not generated");
        Assert.True(generatedSources.Any(s => s.HintName == controllerEntityFileName), $"{controllerEntityFileName} not generated");
        Assert.True(generatedSources.Any(s => s.HintName == controllerCustomQueriesFileName), $"{controllerCustomQueriesFileName} not generated");
        Assert.True(generatedSources.Any(s => s.HintName == controllerCustomCommandsFileName), $"{controllerCustomCommandsFileName} not generated");
        Assert.True(generatedSources.Any(s => s.HintName == controllerRelationshipsFileName), $"{controllerRelationshipsFileName} not generated");
        Assert.True(generatedSources.Any(s => s.HintName == controllerOwnedRelationshipsFileName), $"{controllerOwnedRelationshipsFileName} not generated");

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerFileName}"),
            generatedSources.First(s => s.HintName == controllerFileName).SourceText.ToString());

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerEntityFileName}"),
            generatedSources.First(s => s.HintName == controllerEntityFileName).SourceText.ToString());

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerCustomQueriesFileName}"),
            generatedSources.First(s => s.HintName == controllerCustomQueriesFileName).SourceText.ToString());

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerCustomCommandsFileName}"),
            generatedSources.First(s => s.HintName == controllerCustomCommandsFileName).SourceText.ToString());

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerRelationshipsFileName}"),
            generatedSources.First(s => s.HintName == controllerRelationshipsFileName).SourceText.ToString());

        Assert.Equal(File.ReadAllText($"./ExpectedGeneratedFiles/{controllerOwnedRelationshipsFileName}"),
            generatedSources.First(s => s.HintName == controllerOwnedRelationshipsFileName).SourceText.ToString());

    }
}