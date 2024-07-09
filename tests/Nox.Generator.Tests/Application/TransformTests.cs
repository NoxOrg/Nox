using FluentAssertions;
using Nox.Yaml.Exceptions;
using Xunit;

namespace Nox.Generator.Tests.Application;

public class TransformTests
{
    private const string YamlPath = "files/yaml/application/"; 
    
    [Fact]
    public void Can_generate_files_for_a_transform()
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
            .AssertFileExistsAndContent("TransformBase.expected.g.cs", "Application.Integration.Transform.TestIntegrationTransformBase.g.cs")
            .AssertFileExistsAndContent("SourceDto.expected.g.cs", "Application.Integration.Transform.TestIntegrationSourceDto.g.cs")
            .AssertFileExistsAndContent("TargetDto.expected.g.cs", "Application.Integration.Transform.TestIntegrationTargetDto.g.cs");
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
            .AssertFileCount(11)
            .AssertContent()
            .SourceContains("Generator.g.cs", "Mapping from Integer to DateTime is not allowed in a Nox integration mapping!");
    }

    [Fact]
    public void Can_generate_json_sample_files()
    {
        var sourcePaths = new[]
        {
            $"./{YamlPath}generator.nox.yaml",
            $"./{YamlPath}json-map-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(26)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/Integration/Transform")
            .AssertFileExistsAndContent("JsonTransformBase.expected.g.cs", "Application.Integration.Transform.JsonToTableTransformBase.g.cs")
            .AssertFileExistsAndContent("JsonSourceDto.expected.g.cs", "Application.Integration.Transform.JsonToTableSourceDto.g.cs")
            .AssertFileExistsAndContent("JsonTargetDto.expected.g.cs", "Application.Integration.Transform.JsonToTableTargetDto.g.cs");
    }
}
