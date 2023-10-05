using Xunit;

namespace Nox.Generator.Tests.Presentation;

public class UiGeneratorTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public UiGeneratorTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_ui_files()
    {
        var path = "files/yaml/ui/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}dto.solution.nox.yaml"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(2)
            .AssertContent()
            .SourceContains("0.Generator.g.cs", "SUCCESS");
    }

    [Fact]
    public void Can_validate_generator_with_ui()
    {
        var path = "files/yaml/ui/";

        var sources = new[]
        {
            $"./{path}invalid.generator.nox.yaml",
            $"./{path}dto.solution.nox.yaml"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertContent()
            .SourceContains("0.Generator.g.cs", "Error");
    }
}