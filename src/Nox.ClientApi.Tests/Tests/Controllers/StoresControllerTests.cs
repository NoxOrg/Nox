using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;
using System.Net;
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
                Address = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                VerifiedEmails = expectedEmail,
            };
            var postResult = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);
            // Act
            var response = await _oDataFixture.GetODataSimpleResponseAsync<StoreDto>($"{EntityUrl}/{postResult!.Id}");


            //Assert
            response.Should().NotBeNull();
            response!.VerifiedEmails.Should().BeEquivalentTo(expectedEmail);
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
                OwnershipId = createOwner.Id,
                Address = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
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
        public async Task Post_ReturnsId()
        {
            // Arrange
            var createDto = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                Address = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
            };

            // Act
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Deleted_ShouldPerformSoftDelete()
        {
            // Arrange
            var createDto = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                Address = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                VerifiedEmails = new EmailAddressCreateDto
                {
                    Email = "test@gmail.com",
                    IsVerified = false
                }
            };

            // Act
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);
            var headers = _oDataFixture.CreateEtagHeader(result?.Etag);

            await _oDataFixture.DeleteAsync($"{EntityUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await _oDataFixture.GetAsync($"{EntityUrl}/{result!.Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}