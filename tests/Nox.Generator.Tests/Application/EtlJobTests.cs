using Xunit;

namespace Nox.Generator.Tests.Application;

public class EtlJobTests
{
    [Fact]
    public void Can_generate_a_job_for_an_integration()
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
            .AssertFileCount(27)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/Integration/Jobs")
            .AssertFileExistsAndContent("Job.expected.g.cs", "Application.Integration.Jobs.TestIntegrationJob.g.cs");
    }
}