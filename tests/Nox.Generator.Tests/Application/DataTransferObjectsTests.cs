using Xunit;

namespace Nox.Generator.Tests.Application;

public class DataTransferObjectsTests : IClassFixture<GeneratorFixture>
{
    private readonly GeneratorFixture _generatorFixture;

    public DataTransferObjectsTests(GeneratorFixture generatorFixture)
    {
        _generatorFixture = generatorFixture;
    }

    [Fact]
    public void Can_generate_a_dto_file()
    {
        var path = "files/yaml/application/";

        var sources = new[]
        {
            $"./{path}generator.nox.yaml",
            $"./{path}dto.solution.nox.yaml"
        };

        // Assert the driver doesn't recompute the output
        GeneratorFixture.GenerateSourceCodeFor(sources)
            .AssertOutputResult()
            .AssertFileCount(19)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileWasGenerated("Application.Dto.FormulaDto.g.cs")
            .AssertFileWasGenerated("Application.Dto.FormulaCreateDto.g.cs");
    }
}