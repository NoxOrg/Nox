using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeCountryNumberFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeCountryNumberFactory sut = new NoxTypeCountryNumberFactory(noxSolution);
            short value = 004;

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

            // Assert
            entity.Should().NotBeNull();
            entity!.Value.Should().Be(value);
        }

        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeCountryNumberFactory sut = new NoxTypeCountryNumberFactory(noxSolution);
            short value = 001;

            // Act
            // Assert
            sut.Invoking(y => y.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value))
                .Should().Throw<Nox.Types.TypeValidationException>()
                .WithMessage("The Nox type validation failed with 1 error(s).");
        }
    }
}
