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
            "GetCountriesByContinentQueryBase.g.cs",
            "Application.Dto.CountryDto.g.cs",
            "Application.Dto.CountryCreateDto.g.cs"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(17, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .Check("GetCountriesByContinentQueryBase.expected.g.cs", "GetCountriesByContinentQueryBase.g.cs")
            .Check("Application.Dto.CountryDto.expected.g.cs", "Application.Dto.CountryDto.g.cs")
            .Check("Dto.CountryCreateDto.expected.g.cs", "Application.Dto.CountryCreateDto.g.cs");
    }
}