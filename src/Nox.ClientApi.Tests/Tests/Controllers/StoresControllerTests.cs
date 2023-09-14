using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests : NoxIntegrationTestBase
    {
        private const string StoresControllerName = "api/stores";

        public StoresControllerTests(NoxTestContainerService containerService) : base(containerService)
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
            var result = await PostAsync<StoreCreateDto, StoreDto>(StoresControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().Be(expectedId);
        }
    }
}