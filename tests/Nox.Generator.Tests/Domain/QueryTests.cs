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

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(9)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Application.Dto.CountryCreateDto.g.cs")
            .AssertFileWasGenerated("Application.Dto.CountryUpdateDto.g.cs")
            .AssertFileWasGenerated("Application.Factories.CountryFactory.g.cs");
    }
}