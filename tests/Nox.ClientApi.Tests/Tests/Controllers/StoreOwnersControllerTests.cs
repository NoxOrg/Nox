using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using Nox.Types;
using Xunit.Abstractions;
using ClientApi.Domain;
using ClientApi.Tests.Tests.Models;
using Nox.Exceptions;
using System.Text.Json;

namespace ClientApi.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreOwnersControllerTests : NoxWebApiTestBase
    {
        public StoreOwnersControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        #region RELATIONSHIPS

        #region PUT

        #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/storeowners/1

        [Fact(Skip = "NOX-237")]
        public async Task Put_UpdateStores_Success()
        {
            // Arrange
            var storeOwnerResponse = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl,
                new StoreOwnerCreateDto
                {
                    Id = "001",
                    Name = _fixture.Create<string>(),
                    TemporaryOwnerName = _fixture.Create<string>()
                });
            var store1 = await CreateStore();
            var store2 = await CreateStore();
            var store3 = await CreateStore();
            var store4 = await CreateStore();
            var store5 = await CreateStore();

            await PostAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}/stores/{store1!.Id}/$ref");
            await PostAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}/stores/{store2!.Id}/$ref");
            await PostAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}/stores/{store3!.Id}/$ref");

            // Act
            var getStoreOwnerResponse = await GetODataSimpleResponseAsync<StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}");

            var headers = CreateEtagHeader(getStoreOwnerResponse!.Etag);
            await PutAsync<StoreOwnerUpdateDto, StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}",
                new StoreOwnerUpdateDto
                {
                    Name = storeOwnerResponse!.Name,
                    TemporaryOwnerName = storeOwnerResponse!.TemporaryOwnerName,
                    //StoresId = new List<System.Guid>
                    //{
                    //    store3!.Id,
                    //    store4!.Id,
                    //    store5!.Id
                    //}
                },
                headers);

            const string oDataRequest = $"$expand={nameof(StoreOwnerDto.Stores)}";
            getStoreOwnerResponse = await GetODataSimpleResponseAsync<StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}?{oDataRequest}");

            // Assert
            getStoreOwnerResponse.Should().NotBeNull();
            getStoreOwnerResponse!.Stores.Should().NotBeNull();
            getStoreOwnerResponse!.Stores!.Should().HaveCount(3);
            getStoreOwnerResponse!.Stores!.Should().Contain(w => w.Id.Equals(store3!.Id));
            getStoreOwnerResponse!.Stores!.Should().Contain(w => w.Id.Equals(store4!.Id));
            getStoreOwnerResponse!.Stores!.Should().Contain(w => w.Id.Equals(store5!.Id));
            getStoreOwnerResponse!.Stores!.Should().NotContain(w => w.Id.Equals(store1!.Id));
            getStoreOwnerResponse!.Stores!.Should().NotContain(w => w.Id.Equals(store2!.Id));
        }

        [Fact(Skip = "NOX-237")]
        public async Task Put_UpdateStores_FromListToEmpty_ShouldFail()
        {
            // Arrange
            var storeOwnerResponse = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl,
                new StoreOwnerCreateDto
                {
                    Id = "001",
                    Name = _fixture.Create<string>(),
                    TemporaryOwnerName = _fixture.Create<string>()
                });
            var store1 = await CreateStore();
            var store2 = await CreateStore();

            await PostAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}/stores/{store1!.Id}/$ref");
            await PostAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}/stores/{store2!.Id}/$ref");

            // Act
            var getStoreOwnerResponse = await GetODataSimpleResponseAsync<StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}");

            var headers = CreateEtagHeader(getStoreOwnerResponse!.Etag);
            var putStoreOwnersResponse = await PutAsync($"{Endpoints.StoreOwnersUrl}/{storeOwnerResponse!.Id}",
                new StoreOwnerUpdateDto
                {
                    Name = storeOwnerResponse!.Name,
                    TemporaryOwnerName = storeOwnerResponse!.TemporaryOwnerName
                },
                headers,
                false);

            // Assert
            putStoreOwnersResponse.Should().NotBeNull();
            putStoreOwnersResponse.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion

        #endregion

        #endregion

        [Fact]
        public async Task Post_WhenNullId_ReturnsBadRequest()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_WhenInvalidId_ReturnsBadRequestError()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "1",//min is 3 characters
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            // Assert
            // represent a nox type exception
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var content = await result.Content.ReadAsStringAsync();
            var applicationError = DeserializeResponse<ApplicationErrorCodeResponse<List<AttributeNoxTypeValidationException>>>(content);
            applicationError!.Error.Details.Should().HaveCount(1);
            applicationError!.Error.Details.First().AttributeName.Should().Be("Id");
        }

        [Fact]
        public async Task Post_WhenValidId_ReturnCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "001",
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_VatNumberIsCreated()
        {
            // Arrange
            var expectedVatNumber = "515714941";
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                VatNumber = new VatNumberDto(expectedVatNumber, Nox.Types.CountryCode.PT)
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreOwnerDto>();
            result!.VatNumber!.Number.Should().Be(expectedVatNumber);
        }

        [Fact]
        public async Task Post_StreetAddressAllFieldsSet_IsCreated()
        {
            // Arrange
            var expectedStreetAddressDto = new StreetAddressDto(
                 "3000",
                "Hillswood Business Park",
                null!,
                "Hillswood Drive",
                "Lyne",
                null!,
                "England",
                "Surrey",
                "KT16 0RS",
                CountryCode.GB);

            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = expectedStreetAddressDto,
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerDto>();
            result!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
        }

        [Fact]
        public async Task Post_StreetAddressOnlyRequiredFieldsSet_IsCreated()
        {
            // Arrange
            var expectedStreetAddressDto = new StreetAddressDto(
                 null!,
                 "3000 Hillswood Business Park",
                 null!,
                 null!,
                 null!,
                 null!,
                 null!,
                 null!,
                 "KT16 0RS",
                 CountryCode.GB);

            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = expectedStreetAddressDto,
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerDto>();
            result!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
        }

        [Fact]
        public async Task Post_StreetAddressAddressLine1NotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "KT16 0RS",
                     CountryCode.GB),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_StreetAddressPostalCodeNotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     CountryCode.GB),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_StreetAddressCountryIdNotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                     null!,
                     "3000 Hillswood Business Park",
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     null!,
                     "KT16 0RS",
                    (CountryCode)0),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task Post_With_Headers_Should_Have_Proper_Audit_Values()
        {
            Dictionary<string, IEnumerable<string>> headers = new();
            headers.Add("X-System-Name", new[] { "Test System" });
            headers.Add("X-User-Name", new[] { "Test User" });
            var id = Text.From("007");
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = id.Value,
                Name = "Test Store Owner"
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto,StoreOwnerDto> (Endpoints.StoreOwnersUrl, createDto, headers);

            //Assert
            result.Should().NotBeNull();

            var entity =  GetEntityByFilter<StoreOwner>(s=>s.Id == id);
            entity.Should().NotBeNull();
            entity!.CreatedBy.Should().Be("Test User");
            entity.CreatedVia.Should().Be("Test System");

        }
        
        [Fact]
        public async Task Post_Without_Headers_Should_Have_Default_Audit_Values()
        {
            var id = Text.From("008");
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = id.Value,
                Name = "Test Store Owner"
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto,StoreOwnerDto> (Endpoints.StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();

            var entity =  GetEntityByFilter<StoreOwner>(s=>s.Id == id);
            entity.Should().NotBeNull();
            entity!.CreatedBy.Should().Be("N/A");
            entity.CreatedVia.Should().Be("N/A");

        }

        private async Task<StoreDto?> CreateStore()
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
                     "KT16 0RS",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
            };

            return await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto)!;
        }
    }
}