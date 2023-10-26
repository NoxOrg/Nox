using AutoFixture;
using ClientApi.Application.Dto;
using ClientApi.Tests.Controllers;
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
        public StoresControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
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
            var postResult = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{postResult!.Id}");

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
            await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);

            // Act
            var response = await GetODataCollectionResponseAsync<IEnumerable<StoreDto>>($"{Endpoints.StoresUrl}");

            //Assert
            response!.Should().HaveCount(1);
            
            response!.ElementAt(0).OpeningDay.Should().BeCloseTo(expectedDate, TimeSpan.FromSeconds(1), 
                "Database doesn't store milliseconds in same resolution as .NET");
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
                // we are not allowing this for now, create a related entity
                //Ownership = createOwner
            };
            var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createStore);
            var owner = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, createOwner);
            await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/Ownership/{owner!.Id}/$ref");

            // Act
            const string oDataRequest = $"$expand={nameof(StoreDto.Ownership)}";
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?{oDataRequest}");

            //Assert
            response.Should().NotBeNull();
            response!.Ownership.Should().NotBeNull();
            response!.Ownership!.Name.Should().Be(ownerExpectedName);
        }

        #endregion GET Expand Relation /api/{EntityPluralName}/{EntityKey} => api/stores/1?$expand=Ownership

        #region POST Entity with RelationshipId /api/{EntityPluralName} => api/stores

        [Fact]
        public async Task Post_WithRelationshipId_CreatesRefToRelatedEntity()
        {
            // Arrange
            var store1 = await CreateStore();
            var licenseName = _fixture.Create<string>();
            var licenseCreateDto = new StoreLicenseCreateDto
            {
                Issuer = licenseName,
                StoreWithLicenseId = store1!.Id
            };
            var licensePostResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, licenseCreateDto);

            var storeCreateDto = new StoreCreateDto
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
                LicenseId = licensePostResponse!.Id
            };

            // Act
            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, storeCreateDto);

            const string oDataRequest = $"$expand={nameof(StoreDto.License)}";
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().NotBeEmpty();
            response.Should().NotBeNull();
            response!.License.Should().NotBeNull();
            response!.License!.Id.Should().Be(licensePostResponse!.Id);
            response!.License!.Issuer.Should().Be(licenseName);
        }

        #endregion POST Entity with RelationshipId /api/{EntityPluralName} => api/stores

        #region POST Entity with Invalid RelationshipId /api/{EntityPluralName} => api/stores

        [Fact]
        public async Task Post_WithInvalidRelationshipId_ThrowsException()
        {
            // Arrange
            var storeCreateDto = new StoreCreateDto
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
                LicenseId = _fixture.Create<int>()
            };

            // Act
            var result = await PostAsync(Endpoints.StoresUrl, storeCreateDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion POST Entity with Invalid RelationshipId /api/{EntityPluralName} => api/stores

        #region POST Entity with Deleted RelationshipId /api/{EntityPluralName} => api/stores

        [Fact]
        public async Task Post_WithDeletedRelationshipId_ShouldNotCreateRefToRelatedEntity()
        {
            // Arrange Create a Licence and Delete it
            var store1 = await CreateStore();
            var licenseName = _fixture.Create<string>();
            var licenseCreateDto = new StoreLicenseCreateDto
            {
                Issuer = licenseName,
                StoreWithLicenseId = store1!.Id
            };
            var licensePostResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, licenseCreateDto);

            var headers = CreateEtagHeader(licensePostResponse?.Etag);
            await DeleteAsync($"{Endpoints.StoreLicensesUrl}/{licensePostResponse!.Id}", headers);

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
                LicenseId = licensePostResponse!.Id
            };

            // Act
            var result = await PostAsync(Endpoints.StoresUrl, createDto);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion POST Entity with Deleted RelationshipId /api/{EntityPluralName} => api/stores

        #endregion Relationship Examples

        [Fact]
        public async Task Post_ReturnsId()
        {
            // Arrange
            // Acty
            StoreDto? result = await CreateStore();

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
            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            await DeleteAsync($"{Endpoints.StoresUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{Endpoints.StoresUrl}/{result!.Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private async Task<StoreDto?> CreateStore()
        {
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

            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);
            return result;
        }
    }
}