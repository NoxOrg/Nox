using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeCurrencyCode3FactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            var sut = new NoxTypeCurrencyCode3Factory(noxSolution);
            var cultureCode = "USD";

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, cultureCode);

            // Assert
            entity.Should().NotBeNull();
            entity!.Value.Should().Be(cultureCode);
        }

        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_WhenValueIsNull_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            var sut = new NoxTypeCurrencyCode3Factory(noxSolution);
            string? cultureCode = null;

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, cultureCode);

            // Assert
            entity.Should().BeNull();
        }

        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_WhenValueIsInvalid_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            var sut = new NoxTypeCurrencyCode3Factory(noxSolution);
            string? cultureCode = "AAA";

            // Act
            var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, cultureCode);

            // Assert
            action.Should().Throw<TypeValidationException>()
                .WithMessage("The Nox type validation failed with 1 error(s).")
                .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox CurrencyCode3 type with unsupported value 'AAA'.") });
        }
    }
}
