using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Nox.Generator.Tests.Infrastructure.Persistence;

public class DatabaseServerTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public DatabaseServerTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_database_server_files()
    {
        var path = "files/yaml/infrastructure/";
        var additionalFiles = new List<AdditionalSourceText>
        {
            new AdditionalSourceText(File.ReadAllText($"./{path}generator.nox.yaml"), $"{path}/generator.nox.yaml"),
            new AdditionalSourceText(File.ReadAllText($"./{path}database-server.solution.nox.yaml"), $"{path}/database-server.solution.nox.yaml")
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
        Assert.Equal(7, generatedSources.Length);
        Assert.True(generatedSources.Any(s => s.HintName == "NoxWebApplicationExtensions.g.cs"), "NoxWebApplicationExtensions.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "Generator.g.cs"), "Generator.g.cs not generated");
        Assert.True(generatedSources.Any(s => s.HintName == "EntityBase.g.cs"), "EntityBase.g.cs not generated");

        var countryFileName = "Country.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == countryFileName), $"{countryFileName} not generated");
        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/Country.expected.g.cs"), generatedSources.First(s => s.HintName == countryFileName).SourceText.ToString());

        var dbContextFileName = "SampleWebAppDbContext.g.cs";
        Assert.True(generatedSources.Any(s => s.HintName == dbContextFileName), $"{dbContextFileName} not generated");
        Assert.Equal(File.ReadAllText("./ExpectedGeneratedFiles/SampleWebAppDbContext.expected.g.cs"), generatedSources.First(s => s.HintName == dbContextFileName).SourceText.ToString());
        //can further extend this test to verify contents of source files.
    }
}