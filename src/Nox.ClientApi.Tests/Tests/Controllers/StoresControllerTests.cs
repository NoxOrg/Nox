using FluentAssertions;
using ClientApi.Application.Dto;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests : NoxIntegrationTestBase
    {
        private const string StoresControllerName = "api/stores";

        public StoresControllerTests(NoxTestApplicationFactory<StartupFixture> appFactory) : base(appFactory)
        {
        }

        [Fact]
        public async Task Post_ReturnsNuidId()
        {
            // Arrange
            string name = "MySpecialName";
            uint expectedId = 2519540169u;

            var createDto = new StoreCreateDto
            {
                Name = name,
                // TODO make email mandatory
                //EmailAddress = new EmailAddressUpdateDto()
            };

            // Act
            var result = await PostAsync<StoreCreateDto, StoreKeyDto>(StoresControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreKeyDto>()
                .Which.keyId.Should().Be(expectedId);
        }
    }
}