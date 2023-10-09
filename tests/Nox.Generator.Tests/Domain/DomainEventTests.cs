using Xunit;

namespace Nox.Generator.Tests.Domain;

public class DomainEventTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public DomainEventTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_domain_event_files()
    {
        var path = "files/yaml/domain/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}domain-events.solution.nox.yaml"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(15, "Domain.Country.g.cs", "CountryNameUpdatedEvent.g.cs")
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .Check("CountryNameUpdatedEvent.expected.g.cs", "CountryNameUpdatedEvent.g.cs");
    }
}