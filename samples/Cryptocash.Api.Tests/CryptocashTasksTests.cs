using Nox.Generator.Tasks;

namespace Cryptocash.Tests;

public class CryptocashTasksTests
{
    [Fact]
    public void GeneratorTaskTest()
    {
#if DEBUG
        var outputFolder = Path.Combine("..", "..", "..", "..", "Cryptocash.Ui", "Nox.Generated");
        var designFolder = Path.Combine("..", "..", "..", "..", ".nox");
        var generatorYamlPath = Path.Combine("..", "..", "..", "..", "Cryptocash.Ui", "generator.nox.yaml");
        
        Directory.Delete(outputFolder, true);
        Directory.CreateDirectory(outputFolder);

        var noxYamls = Directory.GetFiles(designFolder, "*.yaml", SearchOption.AllDirectories).ToList();
        noxYamls.Add(generatorYamlPath);

        var fileGenerator = new NoxFileGenerator(
            noxYamls.Select(filePath => Path.GetFullPath(filePath)).ToList(), 
            Path.GetFullPath(outputFolder));
        fileGenerator.GenerateFiles();
#endif
    }

}