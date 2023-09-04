using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests;

namespace Nox.Integration.Tests.DatabaseIntegrationTests
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
                "TestWebAppDbContext",
                "Entities.TestEntityZeroOrOne",
                "Entities.SecondTestEntityZeroOrOne",
                "Entities.ThirdTestEntityZeroOrOne",
                "Entities.TestEntityOneOrMany",
                "Entities.SecondTestEntityOneOrMany",
                "Entities.ThirdTestEntityOneOrMany",
                "Entities.TestEntityForTypes",
                "Entities.TestEntityForUniqueConstraints",
                "Entities.TestEntityWithNuid",
                "Entities.TestEntityExactlyOne",
                "Entities.SecondTestEntityExactlyOne",
                "Entities.ThirdTestEntityExactlyOne",
                "Entities.TestEntityZeroOrMany",
                "Entities.SecondTestEntityZeroOrMany",
                "Entities.ThirdTestEntityZeroOrMany",
                "Entities.TestEntityZeroOrOneToZeroOrMany",
                "Entities.TestEntityZeroOrManyToZeroOrOne",
                "Entities.TestEntityExactlyOneToOneOrMany",
                "Entities.TestEntityOneOrManyToExactlyOne",
                "Entities.TestEntityExactlyOneToZeroOrMany",
                "Entities.TestEntityZeroOrManyToExactlyOne",
                "Entities.TestEntityOneOrManyToZeroOrMany",
                "Entities.TestEntityZeroOrManyToOneOrMany",
                "Entities.TestEntityZeroOrOneToOneOrMany",
                "Entities.TestEntityOneOrManyToZeroOrOne",
                "Entities.TestEntityZeroOrOneToExactlyOne",
                "Entities.TestEntityExactlyOneToZeroOrOne",
                "Entities.TestEntityOwnedRelationshipExactlyOne",
                "Entities.SecondTestEntityOwnedRelationshipExactlyOne",
                "Entities.TestEntityOwnedRelationshipZeroOrOne",
                "Entities.SecondTestEntityOwnedRelationshipZeroOrOne",
                "Entities.TestEntityOwnedRelationshipOneOrMany",
                "Entities.SecondTestEntityOwnedRelationshipOneOrMany",
                "Entities.TestEntityOwnedRelationshipZeroOrMany",
                "Entities.SecondTestEntityOwnedRelationshipZeroOrMany",
            };

            foreach (var className in classNames)
            {
                CreateClass(result, className);
            }

            Assert.True(true);
        }

        private static void CreateClass(GeneratorRunResult result, string filePath)
        {
            var singleResult = result.GeneratedSources.First(x => x.HintName.Equals($"{filePath}.g.cs"));
            var fileContent = singleResult.SourceText.ToString();
            File.WriteAllText($"{BasePath}{filePath}.cs", fileContent);
        }
    }
}