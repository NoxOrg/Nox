using Xunit;

namespace Nox.Generator.Tests.Application;

public class EtlDtoTests
{
    private const string YamlPath = "files/yaml/application/"; 
    
    [Fact]
    public void Can_Generate_dtos_for_entity_target()
    {
        var sourcePaths = new[]
        {
            $"./{YamlPath}generator.nox.yaml",
            $"./{YamlPath}entity-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(27)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/Integration/Dto")
            .AssertFileExistsAndContent("EntitySourceDto.expected.g.cs", "Application.Integration.Transform.TestIntegrationSourceDto.g.cs")
            .AssertFileExistsAndContent("EntityTargetDto.expected.g.cs", "Application.Integration.Transform.TestIntegrationTargetDto.g.cs");
    }
}