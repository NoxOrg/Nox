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
            "Infrastructure.Persistence.SampleWebAppDbContext.g.cs"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(17, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .Check("Country.expected.g.cs", "Domain.Country.g.cs")
            .Check("SampleWebAppDbContext.expected.g.cs", "Infrastructure.Persistence.SampleWebAppDbContext.g.cs");
    }
}