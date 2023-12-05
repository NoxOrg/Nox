using Xunit;

namespace Nox.Generator.Tests.Common;

public class ApplicationExtensionTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _generatorFixture;

    public ApplicationExtensionTests(GeneratorFixture generatorFixture)
    {
        _generatorFixture = generatorFixture;
    }

    [Fact]
    public void Can_generate_application_extensions_file()
    {
        var path = "files/yaml/common/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}app-builder.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(2)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Application.ServiceCollectionExtensions.g.cs");
    }
}