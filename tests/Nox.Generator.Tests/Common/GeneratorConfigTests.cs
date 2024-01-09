using Microsoft.AspNetCore.Http;
using Xunit;

namespace Nox.Generator.Tests.Common;

public class GeneratorConfigTests : IClassFixture<GeneratorFixture>
{
    private const string FilesPath = "files/yaml/common/";

    [Fact]
    public void WhenGenerateConfigWithApplication_ShouldGenerateServiceCollection()
    {
        var sources = new[]
        {
            $"./{FilesPath}generator.nox.yaml",
            $"./{FilesPath}app-builder.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(2)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Application.ServiceCollectionExtensions.g.cs");
    }
    [Fact]
    public void WhenGenerateConfigWithApplicationDto_ShouldNotGenerateServiceCollection()
    {
        
        var sources = new[]
        {
            $"./{FilesPath}applicationDto.generator.nox.yaml",
            $"./{FilesPath}app-builder.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(1)//generator.g.cs
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasNotGenerated("Application.ServiceCollectionExtensions.g.cs");
    }
}