using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;
using System.Net;
using Nox.Types;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests 
    {
        private const string StoresControllerName = "api/stores";

        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public StoresControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

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
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(StoresControllerName, createDto);

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
            };

            // Act
            var result = await _oDataFixture.PostAsync<StoreCreateDto, StoreDto>(StoresControllerName, createDto);
            var headers = _oDataFixture.CreateEtagHeader(result?.Etag);

            await _oDataFixture.DeleteAsync($"{StoresControllerName}/{result!.Id}", headers);

            // Assert
            var queryResult = await _oDataFixture.GetAsync($"{StoresControllerName}/{result!.Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}