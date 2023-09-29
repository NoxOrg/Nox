using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nox.Generator.Tests.Common;

public class ApplicationExtensionTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public ApplicationExtensionTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_application_extensions_file()
    {
        var path = "files/yaml/common/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new(File.ReadAllText($"./{path}app-builder.solution.nox.yaml"), $"{path}/app-builder.solution.nox.yaml")
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
        Assert.Equal(2, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "0.Generator.g.cs"), "Generator not generated");

        var extensionsFilename = "Application.NoxWebApplicationExtensions.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == extensionsFilename), $"{extensionsFilename} not generated");

        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/NoxWebApplicationExtensions.expected.g.cs"), generatedSources.First(s => s.HintName == extensionsFilename).SourceText.ToString());
        //can further extend this test to verify contents of source files.
    }
}