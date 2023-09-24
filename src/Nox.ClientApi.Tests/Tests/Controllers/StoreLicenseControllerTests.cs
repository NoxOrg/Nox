﻿using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Types;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreLicenseControllerTests : NoxIntegrationTestBase
    {
        private const string EntityUrl = "api/storelicenses";

        public StoreLicenseControllerTests(NoxTestContainerService containerService) : base(containerService)
        {
        }

        #region Store Examples

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1
        [Fact]
        public async Task GetById_WithRelationshipSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            var createStoreDto = new StoreCreateDto
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
            var getStoreResult = await PostAsync<StoreCreateDto, StoreDto>("api/stores", createStoreDto);

            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(EntityUrl, createDto);

            await PostAsync($"{EntityUrl}/{postResult!.Id}/StoreWithLicense/{getStoreResult!.Id}/$ref");

            // Act
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{EntityUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreWithLicenseId.Should().Be(getStoreResult!.Id);
        }
        #endregion

        #region GET Entity By Key /api/{EntityPluralName}/{EntityKey} => api/storelicenses/1
        [Fact]
        public async Task GetById_WithRelationshipNotSet_ReturnsValidData()
        {
            var issuer = _fixture.Create<string>();
            // Arrange
            var createDto = new StoreLicenseCreateDto
            {
                Issuer = issuer,
            };
            var postResult = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(EntityUrl, createDto);

            // Act
            var response = await GetODataSimpleResponseAsync<StoreLicenseDto>($"{EntityUrl}/{postResult!.Id}");

            //Assert
            response.Should().NotBeNull();
            response!.Issuer.Should().BeEquivalentTo(issuer);
            response!.StoreWithLicenseId.Should().BeNull();
        }
        #endregion

        #endregion
    }
}