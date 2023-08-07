using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nox.Generator.Tests.Domain;

public class DomainEventTests: IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public DomainEventTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact]
    public void Can_generate_domain_event_files()
    {
        var path = "files/yaml/domain/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new AdditionalSourceText(File.ReadAllText($"./{path}domain-events.solution.nox.yaml"), $"{path}/domain-events.solution.nox.yaml")
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
        Assert.Equal(12, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "NoxWebApplicationExtensions.g.cs"), "NoxWebApplicationExtensions.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "Generator.g.cs"), "Generator.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "Entities.Country.g.cs"), "Country.g.cs not generated");

        var queryFileName = "CountryNameUpdatedEvent.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == queryFileName), $"{queryFileName} not generated");
        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/CountryNameUpdatedEvent.expected.g.cs"), generatedSources.First(s => s.HintName == queryFileName).SourceText.ToString());
        //can further extend this test to verify contents of source files.
    }
}