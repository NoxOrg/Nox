using FluentAssertions;
using Moq;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public record TranslatedTextDto(string CultureCode, string Phrase);
    public class NoxTypeTranslatedTextFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeTranslatedTextFactory sut = new NoxTypeTranslatedTextFactory(noxSolution);
            var phrase = "Testa isto!";
            var cultureCode ="pt";
            var dto = new TranslatedTextDto(cultureCode, phrase);

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, dto);

            // Assert
            entity.Should().NotBeNull();
            entity!.Phrase.Should().Be(phrase);
            entity!.CultureCode.Should().Be(cultureCode);
        }
    }
}
