using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace NoxSourceGeneratorTests.Domain;

public class DomainEventTests: IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public DomainEventTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact]
    public void Can_generate_a_domain_event_file()
    {
        var path = "files/yaml/domain/";
        var additionalFiles = new List<AdditionalSourceText>();
        additionalFiles.Add(new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"));
        additionalFiles.Add(new AdditionalSourceText(File.ReadAllText($"./{path}domain-events.solution.nox.yaml"), $"{path}/domain-events.solution.nox.yaml"));
        
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
        Assert.Equal(5, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "Generator.g.cs"));
        Assert.True(generatedSources.Any(s => s.HintName == "EntityBase.g.cs"));
        Assert.True(generatedSources.Any(s => s.HintName == "AuditableEntityBase.g.cs"));
        Assert.True(generatedSources.Any(s => s.HintName == "Country.g.cs"));
        Assert.True(generatedSources.Any(s => s.HintName == "CountryNameUpdatedEvent.g.cs"));
        //can further extend this test to verify contents of source files.
    }
}