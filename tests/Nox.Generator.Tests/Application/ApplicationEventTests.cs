using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nox.Generator.Tests.Application;

public class ApplicationEventTests: IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public ApplicationEventTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact]
    public void Can_generate_a_domain_event_file()
    {
        var path = "files/yaml/application/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new AdditionalSourceText(File.ReadAllText($"./{path}app-event.solution.nox.yaml"), $"{path}/app-event.solution.nox.yaml")
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
        Assert.Equal(3, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "Application.ServiceCollectionExtensions.g.cs"), "NoxWebApplicationExtensions.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "0.Generator.g.cs"), "Generator not generated");

        var countryNameChangedAppEvent = "CountryNameChangedAppEvent.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == countryNameChangedAppEvent), $"{countryNameChangedAppEvent} not generated");
        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/CountryNameChangedAppEvent.expected.g.cs"), generatedSources.First(s => s.HintName == countryNameChangedAppEvent).SourceText.ToString());
        //can further extend this test to verify contents of source files.
    }
}