using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator;
using Xunit;

namespace NoxSourceGeneratorTests;

public class ApplicationGeneratorTests: IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public ApplicationGeneratorTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact]
    public void Can_generate_a_dto_file()
    {
        var additionalFiles = new List<AdditionalSourceText>();
        additionalFiles.Add(new AdditionalSourceText(File.ReadAllText("./files/yaml/application/generator.nox.yaml"), "files/yaml/application/generator.nox.yaml"));
        additionalFiles.Add(new AdditionalSourceText(File.ReadAllText("./files/yaml/application/dto.solution.nox.yaml"), "files/yaml/application/dto.solution.nox.yaml"));
        
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
        Assert.Equal(2, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "Generator.g.cs"));
        Assert.True(generatedSources.Any(s => s.HintName == "CountryDto.g.cs"));
        //can further extend this test to verify contents of source files.
    }
}