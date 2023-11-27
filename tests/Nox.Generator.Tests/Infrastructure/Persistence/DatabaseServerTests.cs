using Xunit;

namespace Nox.Generator.Tests.Infrastructure.Persistence;

public class DatabaseServerTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public DatabaseServerTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_database_server_files()
    {
        var path = "files/yaml/infrastructure/";

        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}database-server.solution.nox.yaml"
        };

        var filesShouldExist = new[]
        {
            "Domain.Country.g.cs",
            "Infrastructure.Persistence.AppDbContext.g.cs"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(10, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Country.expected.g.cs", "Domain.Country.g.cs");
    }

    [Fact]
    public void Must_generate_db_context_even_if_no_entities_defined()
    {
        var path = "files/yaml/infrastructure/";

        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}empty-domain.solution.nox.yaml"
        };

        var filesShouldExist = new[]
        {
            "Infrastructure.Persistence.AppDbContext.g.cs"
        };

        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(3, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("AppDbContext.minimal.expected.g.cs", "Infrastructure.Persistence.AppDbContext.g.cs")
            .AssertFileExistsAndContent("DtoDbContext.minimal.expected.g.cs", "Infrastructure.Persistence.DtoDbContext.g.cs");
    }
}