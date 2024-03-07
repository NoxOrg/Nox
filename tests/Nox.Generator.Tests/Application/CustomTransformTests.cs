using Xunit;

namespace Nox.Generator.Tests.Application;

public class CustomTransformTests
{
    [Fact]
    public void Can_generate_a_custom_transform_handler_file()
    {
        var path = "files/yaml/application/";

        var sourcePaths = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}custom-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(24)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Application.Integration.CustomTransform.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationTransformBase.g.cs");
    }
}
