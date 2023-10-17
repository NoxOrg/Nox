using AutoFixture;
using ClientApi.Application.Dto;
using ClientApi.Tests.Controllers;
using FluentAssertions;
using Nox.Types;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreLicenseControllerTests : NoxWebApiTestBase
    {


        public StoreLicenseControllerTests(
            ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        #region Store Examples

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        [Fact]
        public async Task GetById_WithRelationshipSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            var store = await CreateStore();
            var store2 = await CreateStore();

            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
                StoreWithLicenseId = store.Id,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, createDto);

                        // Act
            await PostAsync($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}/StoreWithLicense/{store2!.Id}/$ref");
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreWithLicenseId.Should().Be(store2!.Id);
        }

        #endregion GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        [Fact]
        public async Task GetById_WithRelationshipNotSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            StoreDto? store = await CreateStore();

            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
                StoreWithLicenseId = store!.Id,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{Endpoints.StoreLicensesUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreWithLicenseId.Should().Be(store.Id);
        }

        #endregion GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1

        #endregion Store Examples

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

            return await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto)!;
        }
    }
}