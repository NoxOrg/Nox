using Xunit;

namespace Nox.Generator.Tests.Domain;

public class QueryTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public QueryTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_domain_query_files()
    {
        var path = "files/yaml/domain/";

        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}query.solution.nox.yaml"
        };

        var filesShouldExist = new[]
        {
            "Application.Dto.CountryDto.g.cs",
            "Application.Dto.CountryCreateDto.g.cs",
            "Application.Dto.CountryUpdateDto.g.cs",
            "Application.Factories.CountryFactory.g.cs"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(8, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Dto.CountryCreateDto.expected.g.cs", "Application.Dto.CountryCreateDto.g.cs")
            .AssertFileExistsAndContent("Dto.CountryUpdateDto.expected.g.cs", "Application.Dto.CountryUpdateDto.g.cs")
            .AssertFileExistsAndContent("Application.Factories.CountryFactory.expected.g.cs", "Application.Factories.CountryFactory.g.cs");
    }
}