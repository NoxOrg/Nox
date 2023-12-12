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
            $"./{path}custom-integration.solution.nox.yaml"
        };
        
        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(16)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Application.Integration.EtlEvents.CreatedEventDto.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordCreatedDto.g.cs")
            .AssertFileExistsAndContent("Application.Integration.EtlEvents.CreatedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestEntityRecordCreatedEvent.g.cs")
            .AssertFileExistsAndContent("Application.Integration.EtlEvents.UpdatedEventDto.expected.g.cs", "Application.Integration.EtlEvents.TestIntegrationRecordUpdatedDto.g.cs")
            .AssertFileExistsAndContent("Application.Integration.EtlEvents.UpdatedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestEntityRecordUpdatedEvent.g.cs")
            .AssertFileExistsAndContent("Application.Integration.EtlEvents.CompletedEvent.expected.g.cs", "Application.Integration.EtlEvents.TestEntityExecuteCompletedEvent.g.cs");
    }
}