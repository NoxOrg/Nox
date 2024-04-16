using Xunit;

namespace Nox.Generator.Tests.Application;

public class CustomTransformTests
{
    [Fact]
    public void Can_generate_files_for_a_mapping_transform()
    {
        var path = "files/yaml/application/";

        var sourcePaths = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}custom-map-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(26)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Application.Integration.CustomMapTransformBase.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationTransformBase.g.cs")
            .AssertFileExistsAndContent("Application.Integration.CustomMapTransformSourceDto.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationSourceDto.g.cs")
            .AssertFileExistsAndContent("Application.Integration.CustomMapTransformTargetDto.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationTargetDto.g.cs");
    }
}
