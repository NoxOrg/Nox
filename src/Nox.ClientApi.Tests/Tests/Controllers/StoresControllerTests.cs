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

        #region GET Expand Relation /api/{EntityPluralName}/{EntityKey} => api/stores/1?$expand=StoreOwner

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
                //StoreOwner = createOwner
            };
            var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createStore);
            var owner = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, createOwner);
            await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/StoreOwner/{owner!.Id}/$ref");

            // Act
            const string oDataRequest = $"$expand={nameof(StoreDto.StoreOwner)}";
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?{oDataRequest}");

            //Assert
            response.Should().NotBeNull();
            response!.StoreOwner.Should().NotBeNull();
            response!.StoreOwner!.Name.Should().Be(ownerExpectedName);
        }

        #endregion GET Expand Relation /api/{EntityPluralName}/{EntityKey} => api/stores/1?$expand=StoreOwner

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
                StoreId = store1!.Id
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
                StoreLicenseId = licensePostResponse!.Id
            };

            // Act
            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, storeCreateDto);

            const string oDataRequest = $"$expand={nameof(StoreDto.StoreLicense)}";
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().NotBeEmpty();
            response.Should().NotBeNull();
            response!.StoreLicense.Should().NotBeNull();
            response!.StoreLicense!.Id.Should().Be(licensePostResponse!.Id);
            response!.StoreLicense!.Issuer.Should().Be(licenseName);
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
                StoreLicenseId = _fixture.Create<int>()
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
                StoreId = store1!.Id
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
                StoreLicenseId = licensePostResponse!.Id
            };

            // Act
            var result = await PostAsync(Endpoints.StoresUrl, createDto);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion POST Entity with Deleted RelationshipId /api/{EntityPluralName} => api/stores

        [Fact]
        public async Task CanNotNavigateTo_VerifiedEmails()
        {
            //Arrange
            var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
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
                Location = new LatLongDto(51.3728033, -0.5389749)
            });

            //Act
            var postVerifiedEmailsResponse = await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/VerifiedEmails", new EmailAddressCreateDto());
            var getVerifiedEmailsResponse = await GetAsync($"{Endpoints.StoresUrl}/{store!.Id}/VerifiedEmails");
            var putVerifiedEmailsResponse = await PutAsync($"{Endpoints.StoresUrl}/{store!.Id}/VerifiedEmails", new EmailAddressCreateDto(), false);
            var patchVerifiedEmailsResponse = await PatchAsync($"{Endpoints.StoresUrl}/{store!.Id}/VerifiedEmails", new EmailAddressCreateDto(), new Dictionary<string, IEnumerable<string>>(), false);
            var deleteVerifiedEmailsResponse = await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}/VerifiedEmails", false);

            //Assert
            postVerifiedEmailsResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            getVerifiedEmailsResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            putVerifiedEmailsResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            patchVerifiedEmailsResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            deleteVerifiedEmailsResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion Relationship Examples       

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


        [Fact]
        public async Task WhenPostWithoutId_GeneratesId()
        {
            // Arrange
            // Act
            StoreDto? result = await CreateStore();

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task WhenPostWitId_UsesPostId()
        {
            // Arrange
            var expectedId = System.Guid.NewGuid();
            // Act
            StoreDto? result = await CreateStore(expectedId);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreDto>()
                .Which.Id.Should().Be(expectedId);
        }
        
        [Fact]
        public async Task WhenGetStatuses_ReturnsStatuses()
        {
            // Arrange
            // Act
            var result = await GetAsync<List<StoreStatusDto>>($"{Endpoints.StoresUrl}/Statuses");

            //Assert
            result.Should().NotBeNull();
            
        }

        private async Task<StoreDto?> CreateStore()
        {
            return await CreateStore(System.Guid.Empty);
        }

        private async Task<StoreDto?> CreateStore(System.Guid id)
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

            if (System.Guid.Empty != id)
                createDto.Id = id;

            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);
            return result;
        }
    }
}