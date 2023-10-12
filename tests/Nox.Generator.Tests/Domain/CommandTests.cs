using Xunit;

namespace Nox.Generator.Tests.Domain;

public class CommandTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _fixture;

    public CommandTests(GeneratorFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Can_generate_domain_command_files()
    {
        var path = "files/yaml/domain/";
        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}command.solution.nox.yaml"
        };

        var filesShouldExist = new[]
        {
            "Domain.Country.g.cs",
            //"DtoDynamic.UpdatePopulationStatistics.g.cs",
            //"UpdatePopulationStatisticsCommandHandlerBase.g.cs"
        };

        _fixture
            .GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileExistence(8, filesShouldExist)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles/");
    }
}