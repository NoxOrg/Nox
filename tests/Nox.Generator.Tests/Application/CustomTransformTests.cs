using FluentAssertions;
using Nox.Yaml.Exceptions;
using Xunit;

namespace Nox.Generator.Tests.Application;

public class CustomTransformTests
{
    private const string YamlPath = "files/yaml/application/"; 
    
    [Fact]
    public void Can_generate_files_for_a_mapping_transform()
    {
        var sourcePaths = new[]
        {
            $"./{YamlPath}generator.nox.yaml",
            $"./{YamlPath}custom-map-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(27)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/Integration/Transform")
            .AssertFileExistsAndContent("TransformBase.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationTransformBase.g.cs")
            .AssertFileExistsAndContent("SourceDto.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationSourceDto.g.cs")
            .AssertFileExistsAndContent("TargetDto.expected.g.cs", "Application.Integration.CustomTransform.TestIntegrationTargetDto.g.cs");
    }
    
    [Fact]
    public void WhenAMappingIsInvalid_ShouldIncludeException()
    {
        var sourcePaths = new[]
        {
            $"./{YamlPath}generator.nox.yaml",
            $"./{YamlPath}invalid-map-integration.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(6)
            .AssertContent()
            .SourceContains("Generator.g.cs", "Mapping from Integer to DateTime is not allowed in a Nox integration mapping!");
    }
}
