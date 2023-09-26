using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using FluentAssertions.Common;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests : NoxWebApiTestBase
    {
        private const string EntityUrl = "api/stores";

        public StoresControllerTests(ITestOutputHelper testOutput,
            NoxTestContainerService containerService)
            : base(testOutput, containerService)
        {
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
            var postResult = await PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{EntityUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.VerifiedEmails.Should().BeEquivalentTo(expectedEmail);
            response!.OpeningDay.Should().BeNull();
        }

        #endregion GET Entity By Key (Returns by default owned entitites) /api/{EntityPluralName}/{EntityKey} => api/stores/1

        #region GET Entities (Properly deserializes opening day field) /api/{EntityPluralName} => api/stores

        [Fact]
        public async Task GetById_WithDateFieldSet_ReturnsDateFieldValue()
        {
            // Arrange
            var expectedDate = System.DateTime.Now.ToDateTimeOffset();
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
                VerifiedEmails = new EmailAddressCreateDto() { Email = "test@gmail.com", IsVerified = false },
                OpeningDay = expectedDate
            };
            await PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);

            // Act
            var response = await GetODataCollectionResponseAsync<IEnumerable<StoreDto>>($"{EntityUrl}");

            //Assert
            response!.Should().HaveCount(1);
            response!.ElementAt(0).OpeningDay.Should().Be(expectedDate);
        }

        #endregion GET Entities (Properly deserializes opening day field) /api/{EntityPluralName} => api/stores

        #endregion Store Examples

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
                TemporaryOwnerName = _fixture.Create<string>()
            };
            var createStore = new StoreCreateDto
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
                Ownership = createOwner
            };
            var store = await PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createStore);

            // Act
            const string oDataRequest = $"$expand={nameof(StoreDto.Ownership)}";
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{EntityUrl}/{store!.Id}?{oDataRequest}");

            //Assert
            response.Should().NotBeNull();
            response!.Ownership.Should().NotBeNull();
            response!.Ownership!.Name.Should().Be(ownerExpectedName);
        }

        #endregion GET Expand Relation /api/{EntityPluralName}/{EntityKey} => api/stores/1?$expand=Ownership

        #endregion Relationship Examples

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
            var result = await PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);

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
            var result = await PostAsync<StoreCreateDto, StoreDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            await DeleteAsync($"{EntityUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{EntityUrl}/{result!.Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}