using Microsoft.AspNetCore.OData.Results;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests;

namespace Nox.Tests.DatabaseIntegrationTests
{
    public class GenerateIntegrationModels
    {
        private const string BasePath = "../../../DatabaseIntegrationTests/Models/";

        // [Fact]
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

            var classNames = new[]
            {
                "AuditableEntityBase",
                "TestWebAppDbContext",
                "TestEntity",
                "SecondTestEntity",
                "TestEntityOneOrMany",
                "SecondTestEntityOneOrMany",
                "TestEntityForTypes",
                "TestEntityWithNuid",
                "TestEntityExactlyOne",
                "SecondTestEntityExactlyOne"
            };

            foreach (var className in classNames)
            {
                CreateClass(result, className);
            }

            Assert.True(true);
        }

        private static void CreateClass(GeneratorRunResult result, string filePath)
        {
            var singleResult = result.GeneratedSources.First(x => x.HintName.Contains(filePath));
            var fileContent = singleResult.SourceText.ToString();
            File.WriteAllText($"{BasePath}{filePath}.cs", fileContent);
        }
    }
}