using Xunit;

namespace Nox.Generator.Tests.Domain;

public class QueryTests
{    

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
            .AssertFileCount(8)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Application.Dto.CountryCreateDto.g.cs")
            .AssertFileWasGenerated("Application.Dto.CountryUpdateDto.g.cs");
    }
}