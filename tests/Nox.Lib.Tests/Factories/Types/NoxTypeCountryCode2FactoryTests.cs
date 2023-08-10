using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeCountryCode2FactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeCountryCode2Factory sut = new NoxTypeCountryCode2Factory(noxSolution);
            string countryCode = "PT";

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, countryCode);

            // Assert
            entity.Should().NotBeNull();
            entity!.Value.Should().Be(countryCode);
        }
    }
}
