using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nox.Generator.Tests.Domain;

public class CommandTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public CommandTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }    
    
    [Fact]
    public void Can_generate_domain_command_files()
    {
        var path = "files/yaml/domain/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new AdditionalSourceText(File.ReadAllText($"./{path}command.solution.nox.yaml"), $"{path}/command.solution.nox.yaml")
        };

        // trackIncrementalGeneratorSteps allows to report info about each step of the generator
        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            generators: new [] { _fixture.TestGenerator },
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
        Assert.Equal(16, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "Application.NoxWebApplicationExtensions.g.cs"), "NoxWebApplicationExtensions.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "0.Generator.g.cs"), "Generator.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "Domain.Country.g.cs"), "Country.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "DtoDynamic.UpdatePopulationStatistics.g.cs"), "UpdatePopulationStatistics.g.cs not generated");

        var queryFileName = "UpdatePopulationStatisticsCommandHandlerBase.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == queryFileName), $"{queryFileName} not generated");
        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/UpdatePopulationStatisticsCommandHandlerBase.expected.g.cs"), generatedSources.First(s => s.HintName == queryFileName).SourceText.ToString());
        //can further extend this test to verify contents of source files.
    }
}