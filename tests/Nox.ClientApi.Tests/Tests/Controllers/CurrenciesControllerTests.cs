using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CurrenciesControllerTests : NoxWebApiTestBase
    {


        public CurrenciesControllerTests(
            ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService
            //For development purposes
            //TestDatabaseInstanceService containerService
            )
            : base(testOutput, containerService)
        {
        }

        #region RELATIONSHIP

        [Fact(Skip="We not are allowing to call related neither $ref end points, there are only hidden from swagger.")]
        public async Task CanManageReferenceTo_StoreLicenseDefault_NotFound()
        {
            //Arrange
            var store = await CreateStore();
            var storeLicenseResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, new StoreLicenseCreateDto
            {
                Issuer = _fixture.Create<string>(),
                StoreId = store!.Id,
            });
            var currencyResponse = await PostAsync<CurrencyCreateDto, CurrencyDto>(Endpoints.CurrenciesUrl, new CurrencyCreateDto
            {
                Id = "USD",
                Name = "US dollar"
            });

            //Act
            var postRefResponse = await PostAsync($"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault/{storeLicenseResponse!.Id}/$ref", new CurrencyCreateDto());
            var getRefResponse = await GetAsync($"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault/$ref");
            var deleteRefResponse = await DeleteAsync($"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault/{storeLicenseResponse!.Id}/$ref", false);
            var deleteAllRefResponse = await DeleteAsync($"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault/$ref", false);
            var postToStoreLicenseDefaultResponse = await PostAsync($"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault", new StoreLicenseCreateDto());

            //Assert
            postRefResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            getRefResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            deleteRefResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            deleteAllRefResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
            postToStoreLicenseDefaultResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion

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
                     null!,
                     "EC1A 1BB",
                     CountryCode.GB),
                Location = new LatLongDto(51.3728033, -0.5389749),
            };

            return await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto)!;
        }
    }
}