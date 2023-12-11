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

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(14)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("CountryNameUpdatedEvent.g.cs")
            .AssertFileWasGenerated("Domain.Country.g.cs");
    }
}