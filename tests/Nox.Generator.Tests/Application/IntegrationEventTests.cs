using Xunit;

namespace Nox.Generator.Tests.Application;

public class IntegrationEventTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _generatorFixture;

    public IntegrationEventTests(GeneratorFixture generatorFixture)
    {
        _generatorFixture = generatorFixture;
    }

    [Fact]
    public void Can_generate_a_domain_event_file()
    {
        var path = "files/yaml/application/";

        var sourcePaths = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}integration-events.solution.nox.yaml"
        };
        // Assert the driver doesn't recompute the output
        _generatorFixture.GenerateSourceCodeFor(sourcePaths)
            .AssertOutputResult()
            .AssertFileCount(5)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("CountryNameChangedAppEvent.expected.g.cs", "Application.IntegrationEvents.CountryNameChangedAppEvent.g.cs")
            .AssertFileExistsAndContent("CountryLocalNamesAddedEvent.expected.g.cs", "Application.IntegrationEvents.CountryLocalNamesAddedEvent.g.cs")
            .AssertFileExistsAndContent("CountryCurrenciesAddedEvent.expected.g.cs", "Application.IntegrationEvents.CountryCurrenciesAddedEvent.g.cs");
    }
}