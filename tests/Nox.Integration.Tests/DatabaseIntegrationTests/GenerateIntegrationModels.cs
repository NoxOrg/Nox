using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests;

namespace Nox.Integration.Tests.DatabaseIntegrationTests
{
    public class GenerateIntegrationModels
    {
        private const string BasePath = "../../../DatabaseIntegrationTests/Models/";

        //[Fact]
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
                "Infrastructure.Persistence.TestWebAppDbContext",
                "Domain.TestEntityZeroOrOne",
                "Domain.SecondTestEntityZeroOrOne",
                "Domain.ThirdTestEntityZeroOrOne",
                "Domain.TestEntityOneOrMany",
                "Domain.SecondTestEntityOneOrMany",
                "Domain.ThirdTestEntityOneOrMany",
                "Domain.TestEntityForTypes",
                "Domain.TestEntityForUniqueConstraints",
                "Domain.TestEntityWithNuid",
                "Domain.TestEntityExactlyOne",
                "Domain.SecondTestEntityExactlyOne",
                "Domain.ThirdTestEntityExactlyOne",
                "Domain.TestEntityZeroOrMany",
                "Domain.SecondTestEntityZeroOrMany",
                "Domain.ThirdTestEntityZeroOrMany",
                "Domain.TestEntityZeroOrOneToZeroOrMany",
                "Domain.TestEntityZeroOrManyToZeroOrOne",
                "Domain.TestEntityExactlyOneToOneOrMany",
                "Domain.TestEntityOneOrManyToExactlyOne",
                "Domain.TestEntityExactlyOneToZeroOrMany",
                "Domain.TestEntityZeroOrManyToExactlyOne",
                "Domain.TestEntityOneOrManyToZeroOrMany",
                "Domain.TestEntityZeroOrManyToOneOrMany",
                "Domain.TestEntityZeroOrOneToOneOrMany",
                "Domain.TestEntityOneOrManyToZeroOrOne",
                "Domain.TestEntityZeroOrOneToExactlyOne",
                "Domain.TestEntityExactlyOneToZeroOrOne",
                "Domain.TestEntityOwnedRelationshipExactlyOne",
                "Domain.SecondTestEntityOwnedRelationshipExactlyOne",
                "Domain.TestEntityOwnedRelationshipZeroOrOne",
                "Domain.SecondTestEntityOwnedRelationshipZeroOrOne",
                "Domain.TestEntityOwnedRelationshipOneOrMany",
                "Domain.SecondTestEntityOwnedRelationshipOneOrMany",
                "Domain.TestEntityOwnedRelationshipZeroOrMany",
                "Domain.SecondTestEntityOwnedRelationshipZeroOrMany",
                "Domain.TestEntityTwoRelationshipsOneToOne",
                "Domain.SecondTestEntityTwoRelationshipsOneToOne",
                "Domain.TestEntityTwoRelationshipsManyToMany",
                "Domain.SecondTestEntityTwoRelationshipsManyToMany",
                "Domain.TestEntityTwoRelationshipsOneToMany",
                "Domain.SecondTestEntityTwoRelationshipsOneToMany",
                "Domain.Meta.TestEntityForTypes",
                "0.Generator",
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