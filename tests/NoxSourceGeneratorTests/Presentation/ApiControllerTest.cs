using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace NoxSourceGeneratorTests.Domain;

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
        Assert.Equal(9, generatedSources.Length);
        
        // Check base files
        Assert.True(generatedSources.Any(s => s.HintName == "Generator.g.cs"), "Generator.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "EntityBase.g.cs"), "EntityBase.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "AuditableEntityBase.g.cs"), "AuditableEntityBase.g.cs not generated");
        
        // check entities/queries/commands
        Assert.True(generatedSources.Any(s => s.HintName == "Country.g.cs"), "Country.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "UpdatePopulationStatistics.g.cs"), "UpdatePopulationStatistics.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "UpdatePopulationStatisticsCommandHandlerBase.g.cs"), "UpdatePopulationStatisticsCommandHandlerBase.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "CountryInfo.g.cs"), "CountryInfo.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "GetCountriesByContinentQuery.g.cs"), "GetCountriesByContinentQuery.g.cs not generated");
        
        // check controllers
        Assert.True(generatedSources.Any(s => s.HintName == "CountriesApiController.g.cs"), "CountriesApiController.g.cs not generated");
        //can further extend this test to verify contents of source files.
    }
}
