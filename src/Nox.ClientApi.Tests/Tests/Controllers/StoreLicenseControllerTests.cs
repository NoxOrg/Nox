using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreLicenseControllerTests : NoxWebApiTestBase
    {


        public StoreLicenseControllerTests(
            ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService
            //For development purposes
            //TestDatabaseInstanceService containerService
            )
            : base(testOutput, containerService)
        {
        }

        #region RELATIONSHIPS

        #region POST

        #region POST Create ref to related entities /api/{EntityPluralName}/{EntityKey} => api/storeLicenses/1/DefaultCurrency/USD

        [Fact]
        public async Task Post_RefToCurrency_Succes()
        {
            //Arrange
            var usdCurrency = await PostAsync<CurrencyCreateDto, CurrencyDto>(Endpoints.CurrenciesUrl, new CurrencyCreateDto { Id = "USD" });
            var eurCurrency = await PostAsync<CurrencyCreateDto, CurrencyDto>(Endpoints.CurrenciesUrl, new CurrencyCreateDto { Id = "EUR" });
            var store = await CreateStoreAsync();
            var storeLicenseReponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new StoreLicenseCreateDto { 
                    Issuer = _fixture.Create<string>(),
                    StoreId = store!.Id
                });

            //Act
            await PostAsync($"{Endpoints.StoreLicensesUrl}/{storeLicenseReponse!.Id}/DefaultCurrency/{usdCurrency!.Id}/$ref");
            await PostAsync($"{Endpoints.StoreLicensesUrl}/{storeLicenseReponse!.Id}/SoldInCurrency/{eurCurrency!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(StoreLicenseDto.DefaultCurrency)},{nameof(StoreLicenseDto.SoldInCurrency)}";
            var getStoreLicenseResponse = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{storeLicenseReponse!.Id}?{oDataRequest}");

            //Assert
            getStoreLicenseResponse.Should().NotBeNull();
            getStoreLicenseResponse!.DefaultCurrencyId.Should().Be(usdCurrency!.Id);
            getStoreLicenseResponse!.DefaultCurrency.Should().NotBeNull();
            getStoreLicenseResponse!.DefaultCurrency!.Id.Should().Be(usdCurrency!.Id);
            getStoreLicenseResponse!.SoldInCurrencyId.Should().Be(eurCurrency!.Id);
            getStoreLicenseResponse!.SoldInCurrency.Should().NotBeNull();
            getStoreLicenseResponse!.SoldInCurrency!.Id.Should().Be(eurCurrency!.Id);
        }

        #endregion

        #endregion

        #region PUT

        #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/storeLicenses/1

        [Fact(Skip = "NOX-237")]
        public async Task Put_UpdateRelatedStore_Success()
        {
            //Arrange
            var store1 = await CreateStoreAsync();
            var store2 = await CreateStoreAsync();
            var storeLicenseResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new StoreLicenseCreateDto
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store1!.Id,
                });

            //Act
            var headers = CreateEtagHeader(storeLicenseResponse!.Etag);
            await PutAsync<StoreLicenseUpdateDto, StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{storeLicenseResponse!.Id}",
                new StoreLicenseUpdateDto
                {
                    Issuer = storeLicenseResponse!.Issuer,
                    //StoreId = store2!.Id
                },
                headers);

            var getStoreLicenseResponse = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{storeLicenseResponse!.Id}");

            //Assert
            getStoreLicenseResponse.Should().NotBeNull();
            getStoreLicenseResponse!.StoreId.Should().Be(store2!.Id);
        }

        [Fact(Skip = "NOX-237")]
        public async Task Put_UpdateRelatedStoreToEmpty_Fail()
        {
            //Arrange
            var store1 = await CreateStoreAsync();
            var storeLicenseResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new StoreLicenseCreateDto
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store1!.Id,
                });

            //Act
            var headers = CreateEtagHeader(storeLicenseResponse!.Etag);
            var putStoreLicenseResponse = await PutAsync($"{Endpoints.StoreLicensesUrl}/{storeLicenseResponse!.Id}",
                new StoreLicenseUpdateDto
                {
                    Issuer = storeLicenseResponse!.Issuer
                },
                headers,
                false);

            //Assert
            putStoreLicenseResponse.Should().NotBeNull();
            putStoreLicenseResponse.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion

        #endregion

        #endregion

        #region Store Examples

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        [Fact]
        public async Task GetById_WithRelationshipSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            var store = await CreateStoreAsync();
            var store2 = await CreateStoreAsync();

            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
                StoreId = store!.Id,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, createDto);

            // Act
            await PostAsync($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}/store/{store2!.Id}/$ref");
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreId.Should().Be(store2!.Id);
        }

        #endregion GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        [Fact]
        public async Task GetById_WithRelationshipNotSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            StoreDto? store = await CreateStoreAsync();

            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
                StoreId = store!.Id,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreId.Should().Be(store.Id);
        }

        #endregion GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        #endregion Store Examples

        [Fact]
        public async Task WhenStoreLicenceCreated_ShouldGenerateAutoNumberExternalId()
        {
            //Arrange
            var store1 = await CreateStoreAsync();
            var store2 = await CreateStoreAsync();

            // Act
            var storeLicenseResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new StoreLicenseCreateDto
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store1!.Id,
                });

            var storeLicenseResponse2 = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new StoreLicenseCreateDto
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store2!.Id,
                });

            //Assert
            storeLicenseResponse.Should().NotBeNull();
            storeLicenseResponse!.ExternalId.Should().Be(3000000);

            storeLicenseResponse2.Should().NotBeNull();
            storeLicenseResponse2!.ExternalId.Should().Be(3000000 + 10);
        }

        [Fact]
        public async Task WhenStoreLicenceCreated_AutoNumberExternalIdIsSystemGenerated()
        {
            //Arrange
            var store = await CreateStoreAsync();
            var storeLicenseCreateResponse = await PostAsync<object, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store!.Id,
                    ExternalId = 123456
                });

            // Act
            //Assert
            storeLicenseCreateResponse.Should().NotBeNull();
            storeLicenseCreateResponse!.ExternalId.Should().Be(3000000);
        }

        [Fact(Skip = "NOX-237")]
        public async Task WhenStoreLicenceUpdated_AutoNumberExternalIdIsNotUpdated()
        {
            //Arrange
            var store = await CreateStoreAsync();
            var storeLicenseCreateResponse = await PostAsync<object, StoreLicenseDto>(Endpoints.StoreLicensesUrl,
                new
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store!.Id,
                });
            var externalId = storeLicenseCreateResponse!.ExternalId;

            // Act
            var headers = CreateEtagHeader(storeLicenseCreateResponse!.Etag);
            var storeLicenseUpdateResponse = await PutAsync<object, StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{storeLicenseCreateResponse!.Id}",
                new
                {
                    Issuer = _fixture.Create<string>(),
                    StoreId = store!.Id,
                    ExternalId = 123456
                }, 
                headers);

            //Assert
            storeLicenseUpdateResponse.Should().NotBeNull();
            storeLicenseUpdateResponse!.ExternalId.Should().Be(externalId);
        }

        private async Task<StoreDto?> CreateStoreAsync()
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