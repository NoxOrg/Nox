using Xunit;

namespace Nox.Generator.Tests.Application;

public class EtlEventTests
{
    [Fact]
    public void Can_generate_integration_etl_event_and_payload_files()
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
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/Integration/Events")
            .AssertFileExistsAndContent("EtlEvents.CreatedEventDto.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordCreatedDto.g.cs")
            .AssertFileExistsAndContent("EtlEvents.CreatedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordCreatedEvent.g.cs")
            .AssertFileExistsAndContent("EtlEvents.UpdatedEventDto.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordUpdatedDto.g.cs")
            .AssertFileExistsAndContent("EtlEvents.UpdatedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordUpdatedEvent.g.cs")
            .AssertFileExistsAndContent("EtlEvents.CompletedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationExecuteCompletedEvent.g.cs");
    }
}