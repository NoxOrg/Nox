using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests 
    {
        private const string StoresControllerName = "api/stores";

        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public StoresControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
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
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreKeyDto>(StoresControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreKeyDto>()
                .Which.keyId.Should().Be(expectedId);
        }
    }
}