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
            .AssertFileCount(18)
            .AssertContent()
            .WithExpectedFilesFolder("./ExpectedGeneratedFiles")
            .AssertFileExistsAndContent("Application.Dto.FormulaDto.expected.g.cs", "Application.Dto.FormulaDto.g.cs")
            .AssertFileExistsAndContent("Application.Dto.FormulaCreateDto.expected.g.cs", "Application.Dto.FormulaCreateDto.g.cs");
    }
}