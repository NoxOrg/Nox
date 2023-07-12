using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests;

namespace Nox.Tests.DatabaseIntegrationTests
{
    public class GenerateIntegrationModels
    {
        [Fact]
        public void GenerateIntegrationTestModels()
        {
            var _fixture = new GeneratorFixture();

            var path = "DatabaseIntegrationTests/Design/";
            var additionalFiles = new List<AdditionalSourceText>
            {
                new AdditionalSourceText(File.ReadAllText($"./{path}test.solution.nox.yaml"), $"{path}/test.solution.nox.yaml"),
            };

            // trackIncrementalGeneratorSteps allows to report info about each step of the generator
            GeneratorDriver driver = CSharpGeneratorDriver.Create(
                generators: new[] { _fixture.TestGenerator },
                additionalTexts: additionalFiles,
                driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

            // Run the generator
            driver = driver.RunGenerators(_fixture.TestCompilation!);

            var result = driver.GetRunResult().Results[0];

            var auditableEntityFileName = "AuditableEntityBase";
            var basePath = "../../../DatabaseIntegrationTests/Models/";
            var singleResult = result.GeneratedSources.First(x => x.HintName.Contains(auditableEntityFileName));
            var fileContent = singleResult.SourceText.ToString();
            File.WriteAllText($"{basePath}{auditableEntityFileName}.cs", fileContent);

            var testDatabaseWebAppContextFileName = "TestDatabaseWebAppDbContext";
            singleResult = result.GeneratedSources.First(x => x.HintName.Contains(testDatabaseWebAppContextFileName));
            fileContent = singleResult.SourceText.ToString();
            File.WriteAllText($"{basePath}{testDatabaseWebAppContextFileName}.cs", fileContent);

            var testEntityFileName = "TestEntity";
            singleResult = result.GeneratedSources.First(x => x.HintName.Contains(testEntityFileName));
            fileContent = singleResult.SourceText.ToString();
            File.WriteAllText($"{basePath}{testEntityFileName}.cs", fileContent);

            Assert.True(true);
        }
    }
}
