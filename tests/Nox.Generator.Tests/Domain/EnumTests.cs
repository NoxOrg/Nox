using Xunit;

namespace Nox.Generator.Tests.Domain;

public class EnumTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public EnumTests(GeneratorFixture fixture)
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
            $"./{path}enums.solution.nox.yaml"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(12, "Domain.CountryEnums.g.cs")
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Domain.CountryEnums.expected.g.cs", "Domain.CountryEnums.g.cs");
    }
}
