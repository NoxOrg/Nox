using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using FluentAssertions.Common;
using Nox.Application.Dto;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests : NoxWebApiTestBase
    {
        private readonly EndPointsFixture _endPointFixture;
        public StoresControllerTests(ITestOutputHelper testOutput,

            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
            //TODO receive it on the constructor
            _endPointFixture = new EndPointsFixture(nameof(ClientApi.Domain.Store));
        }

        #region Store Examples

        #region GET Entity By Key (Returns by default owned entitites) /api/{EntityPluralName}/{EntityKey} => api/stores/1

        [Fact]
        public async Task GetById_ReturnsOwnedEntitites()
        {
            // Arrange
            var expectedEmail = new EmailAddressUpsertDto() { Email = "test@gmail.com", IsVerified = false };
            var createDto = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                Address = new StreetAddressDto(
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                EmailAddress = expectedEmail,
            };
            var postResult = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.EmailAddress.Should().BeEquivalentTo(expectedEmail);
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
                    null!,
                    "3000 Hillswood Business Park",
                    null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                EmailAddress = new EmailAddressUpsertDto() { Email = "test@gmail.com", IsVerified = false },
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
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
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
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
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
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                StoreLicenseId = _fixture.Create<int>()
            };

            // Act
            var result = await PostAsync(Endpoints.StoresUrl, storeCreateDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveStatusCode(HttpStatusCode.NotFound);
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

            var headers = CreateEtagHeader(licensePostResponse!.Etag);
            await DeleteAsync($"{Endpoints.StoreLicensesUrl}/{licensePostResponse!.Id}", headers);

            var createDto = new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                Address = new StreetAddressDto(
                    null!,
                    "3000 Hillswood Business Park",
                    null!,
                    null!,
                    null!,
                    null!,
                    null!,
                    null!,
                    null!,
                    "GIR0AA",
                    CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                StoreLicenseId = licensePostResponse!.Id
            };

            // Act
            var result = await PostAsync(Endpoints.StoresUrl, createDto);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().HaveStatusCode(HttpStatusCode.NotFound);
        }

        #endregion POST Entity with Deleted RelationshipId /api/{EntityPluralName} => api/stores

        #region  PUT Update ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/stores/1/clients/$ref
        /// <summary>
        /// Update references in a ManyToManyRelationship
        /// </summary>
        /// <returns></returns>
        [Fact()]        
        public async Task Put_UpdateRefStoreToClients_InManyToManyRelationship_Success()
        {
            // Arrange
            var store = await CreateStore();
            var clientId = System.Guid.NewGuid();
            await PostAsync<ClientCreateDto, ClientDto>(Endpoints.ClientsUrl, new ClientCreateDto() { Name = "client",Id = clientId });

            // Act
            var headers = CreateEtagHeader(store!.Etag);

            await PutAsync(
                _endPointFixture
                .EndPointForEntity
                .WithEntityKey(store!.Id)
                .WithRelatedEntity(nameof(ClientApi.Domain.Client))
                .WithRefs()
                .BuildUrl(),
                new ReferencesDto<System.Guid>
                {
                    References = new List<System.Guid> { clientId }
                },
                headers);

            const string oDataRequest = $"$expand={nameof(StoreDto.Clients)}";
            var getStoreResponse = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{store!.Id}?{oDataRequest}");

            //Assert
            getStoreResponse.Should().NotBeNull();            
            getStoreResponse!.Clients.Should().NotBeNull();
            getStoreResponse!.Clients!.Should().HaveCount(1);
            getStoreResponse!.Clients!.First().Id.Should().Be(clientId);
        }
        #endregion

        #region PATCH related entity /api/{EntityPluralName}/{EntityKey}/{NavigationName} => /api/stores/1/storeowner
        [Fact]
        public async Task WhenPatchRelatedStoreOwner_ShouldSucceed()
        {
            // Arrange
            var ownerExpectedName = _fixture.Create<string>();
            var storeResponse = await CreateStore();
            var ownerResponse = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                TemporaryOwnerName = _fixture.Create<string>()
            });
            await PostAsync($"{Endpoints.StoresUrl}/{storeResponse!.Id}/{nameof(StoreDto.StoreOwner)}/{ownerResponse!.Id}/$ref");
            var getOwnedResponse = await GetODataSimpleResponseAsync<StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{ownerResponse!.Id}");

            // Act
            var headers = CreateEtagHeader(getOwnedResponse!.Etag);
            var patchResponse = await PatchAsync<StoreOwnerPartialUpdateDto, StoreOwnerDto>(
                $"{Endpoints.StoresUrl}/{storeResponse!.Id}/{nameof(StoreDto.StoreOwner)}",
                new StoreOwnerPartialUpdateDto
                {
                    Name = ownerExpectedName
                },
                headers);

            const string oDataRequest = $"$expand={nameof(StoreDto.StoreOwner)}";
            var getStoreResponse = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{storeResponse!.Id}?{oDataRequest}");

            //Assert
            patchResponse.Should().NotBeNull();

            getStoreResponse.Should().NotBeNull();
            getStoreResponse!.StoreOwner.Should().NotBeNull();
            getStoreResponse!.StoreOwner!.Name.Should().Be(ownerExpectedName);
        }
        #endregion

        [Fact]
        public async Task CanNotNavigateTo_EmailAddress()
        {
            //Arrange
            var store = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
            {
                Name = _fixture.Create<string>(),
                Address = new StreetAddressDto(
                    null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749)
            });

            //Act
            var postEmailAddressResponse = await PostAsync($"{Endpoints.StoresUrl}/{store!.Id}/EmailAddress", new EmailAddressUpsertDto());
            var getEmailAddressResponse = await GetAsync($"{Endpoints.StoresUrl}/{store!.Id}/EmailAddress");
            var putEmailAddressResponse = await PutAsync($"{Endpoints.StoresUrl}/{store!.Id}/EmailAddress", new EmailAddressUpsertDto(), false);
            var patchEmailAddressResponse = await PatchAsync($"{Endpoints.StoresUrl}/{store!.Id}/EmailAddress", new EmailAddressUpsertDto(), new Dictionary<string, IEnumerable<string>>(), false);
            var deleteEmailAddressResponse = await DeleteAsync($"{Endpoints.StoresUrl}/{store!.Id}/EmailAddress", false);

            //Assert
            postEmailAddressResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            getEmailAddressResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            putEmailAddressResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            patchEmailAddressResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            deleteEmailAddressResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
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
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
                EmailAddress = new EmailAddressUpsertDto
                {
                    Email = "test@gmail.com",
                    IsVerified = false
                }
            };

            // Act
            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);
            var headers = CreateEtagHeader(result!.Etag);

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
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                    null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "GIR0AA",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
            };

            if (System.Guid.Empty != id)
                createDto.Id = id;

            var result = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto);
            return result;
        }
    }
}