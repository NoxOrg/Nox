using Xunit;

namespace Nox.Generator.Tests.Domain;

public class LocalizedEntitiesTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public LocalizedEntitiesTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_localized_entity_files()
    {
        var path = "files/yaml/domain/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}domain-events.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(14, "Domain.CountryLocalized.g.cs", "Application.Dto.CountryLocalizedDto.g.cs")
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Domain.CountryLocalized.g.cs")
            .AssertFileWasGenerated("Application.Dto.CountryLocalizedUpsertDto.g.cs")
            .AssertFileWasGenerated("Application.Dto.CountryLocalizedDto.g.cs")
            .AssertFileWasGenerated("Application.Factories.CountryLocalizedFactory.g.cs");
    }
}