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
        
        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(11)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Domain.Country.g.cs")
            .AssertFileWasGenerated("Infrastructure.Persistence.AppDbContext.g.cs");
    }
}