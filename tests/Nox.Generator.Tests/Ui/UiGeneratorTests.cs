using Xunit;

namespace Nox.Generator.Tests.Presentation;

public class UiGeneratorTests 
{
    private const string filesPath = "files/yaml/ui/";

    [Fact]
    public void Can_generate_ui_files()
    {
        var sources = new[]
        {
            $"./{filesPath}generator.nox.yaml",
            $"./{filesPath}dto.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertContent()
            .SourceContains("Generator.g.cs", "SUCCESS");
    }

    [Fact]
    public void Can_validate_generator_with_ui()
    {
        var sources = new[]
        {
            $"./{filesPath}invalid.generator.nox.yaml",
            $"./{filesPath}dto.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertContent()
            .SourceContains("Generator.g.cs", "Error");

        // This trick is necessary because broken configuration impacts on test Generated_Files_Should_Be_Compiled_Successfully
        // Seems that driver.RunGenerators() does not release generated resources on time.
        // Another fix is to set Thread.Sleep(2000) in test Generated_Files_Should_Be_Compiled_Successfully.
        GeneratorFixture.GenerateSourceCodeFor(new[] { $"./{filesPath}generator.nox.yaml" });
    }
}