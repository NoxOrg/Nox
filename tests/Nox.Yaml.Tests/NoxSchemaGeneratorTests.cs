using Nox.Yaml.Schema;
using Nox.Yaml.Tests.TestDesigns.Nox.Models;


namespace Nox.Yaml.Tests;

public class NoxSchemaGeneratorTests
{

    [Fact]
    public void NoxSchemaGenerator_Generates_Cryptocash_Schemas()
    {
        // Arrange

        var path = "../../../TestDesigns/Nox/Schemas/";

        // Act

        NoxSchemaGenerator.GenerateJsonSchemas<NoxSolution>(path);

        // Assert

        File.Exists(Path.Combine(path, "solution.json"));

    }

}