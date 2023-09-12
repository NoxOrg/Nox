using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;
using Nox.Types;
using System.Runtime.ConstrainedExecution;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests 
    {
        private const string EntityUrl = "api/stores";

        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public StoresControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        #region GET Entity By Key (Returns by default owned entitites) /api/{EntityPluralName}/{EntityKey} => api/stores/1
        [Fact]
        public async Task GetById_ReturnsOwnedEntitites()
        {
            // Arrange
            var expectedEmail = new EmailAddressCreateDto() { Email = "test@gmail.com", IsVerified = false };
            var createDto = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                EmailAddress = expectedEmail,
            };
            var postResult = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);
            // Act
            var response = await _oDataFixture.GetODataSimpleResponseAsync<StoreDto>($"{EntityUrl}/{postResult!.Id}");


            //Assert
            response.Should().NotBeNull();
            response!.EmailAddress.Should().BeEquivalentTo(expectedEmail);  
        }
        #endregion

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
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().Be(expectedId);
        }


    }
}