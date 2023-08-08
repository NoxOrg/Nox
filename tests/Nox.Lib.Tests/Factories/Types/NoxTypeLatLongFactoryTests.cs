using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public record LatLongDto(System.Double Latitude, System.Double Longitude);

    public class NoxTypeLatLongFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange            
            NoxTypeLatLongFactory sut = new NoxTypeLatLongFactory(noxSolution);
            var latitude = 85;
            var longitude = 5d;
            var dto = new LatLongDto(latitude, longitude);

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, dto);

            // Assert
            entity.Should().NotBeNull();
            entity!.Latitude.Should().Be(latitude);
            entity!.Longitude.Should().Be(longitude);
        }
    }
}
