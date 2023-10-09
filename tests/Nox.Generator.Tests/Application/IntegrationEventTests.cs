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
            .AssertFileExistence(5)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .Check("CountryNameChangedAppEvent.expected.g.cs", "Application.IntegrationEvent.CountryNameChangedAppEvent.g.cs")
            .Check("CountryLocalNamesAddedEvent.expected.g.cs", "Application.IntegrationEvent.CountryLocalNamesAddedEvent.g.cs")
            .Check("CountryCurrenciesAddedEvent.expected.g.cs", "Application.IntegrationEvent.CountryCurrenciesAddedEvent.g.cs");
    }
}