using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeCultureCodeFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            var sut = new NoxTypeCultureCodeFactory(noxSolution);
            var cultureCode = "en-US";

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
            var sut = new NoxTypeCultureCodeFactory(noxSolution);
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
            var sut = new NoxTypeCultureCodeFactory(noxSolution);
            string? cultureCode = "English";

            // Act
            var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, cultureCode);

            // Assert
            action.Should().Throw<TypeValidationException>()
                .WithMessage("The Nox type validation failed with 1 error(s).")
                .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox CultureCode type with unsupported value 'English'.") });
        }
    }
}