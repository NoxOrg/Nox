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
            .AssertContent()
            .SourceContains("Generator.g.cs", "SUCCESS");
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
            .SourceContains("Generator.g.cs", "Error");

        // This trick is necessary because broken configuration impacts on test Generated_Files_Should_Be_Compiled_Successfully
        // Seems that driver.RunGenerators() does not release generated resources on time.
        // Another fix is to set Thread.Sleep(2000) in test Generated_Files_Should_Be_Compiled_Successfully.
        _fixture
            .GenerateSourceCodeFor(new[] { $"./{path}generator.nox.yaml" });
    }
}