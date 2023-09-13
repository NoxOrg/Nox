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

        #region Store Examples

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

        #endregion

        #region Relationship Examples
        #region GET Expand Relation /api/{EntityPluralName}/{EntityKey} => api/stores/1?$expand=Ownership
        [Fact]
        public async Task Get_StoreOwnerOdataQuery_ReturnOwner()
        {
            var ownerExpectedName = _fixture.Create<string>();
            // Arrange
            var createOwner = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = ownerExpectedName,
                
            };
            var storeOwner = await _oDataFixture.PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersControllerTests.EntityUrl, createOwner);
            var createStore = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                OwnershipId = createOwner.Id
            };
            var store = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createStore);

            // Act
            const string oDataRequest = $"$expand={nameof(StoreDto.Ownership)}";
            var response = await _oDataFixture.GetODataSimpleResponseAsync<StoreDto>($"{EntityUrl}/{store!.Id}?{oDataRequest}");


            //Assert
            response.Should().NotBeNull();            
            // TODO uncomment when we are able to create a relation
            //response!.OwnerRel.Should().NotBeNull();
            //response.OwnerRel!.Name.Should().Be(ownerExpectedName);
        }
        #endregion
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