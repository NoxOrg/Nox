using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ClientApi.Tests.Tests.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("StoreDescriptionsControllerTests")]
    public class StoreDescriptionsControllerTests : NoxIntegrationTestBase
    {
        private const string EntityPluralName = "storedescriptions";
        private const string EntityUrl = $"api/{EntityPluralName}";
        private const string StoresUrl = $"api/stores";

        public StoreDescriptionsControllerTests(NoxTestContainerService containerService) : base(containerService)
        {
        }

        #region KEY AS ENTITYID

        [Fact]
        public async Task Post_StoreDescriptionWithStoreId_Success()
        {
            // Arrange
            var storeDto = new StoreCreateDto
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

            var storeResponse = await PostAsync<StoreCreateDto, StoreDto>(StoresUrl, storeDto);

            var descriptionDto = new StoreDescriptionCreateDto
            {
                StoreId = storeResponse!.Id,
                Description = _fixture.Create<string>()
            };

            // Act
            var descriptionResponse = await PostAsync<StoreDescriptionCreateDto, StoreDescriptionDto>(EntityUrl, descriptionDto);

            //Assert
            descriptionResponse.Should().NotBeNull();
            descriptionResponse!.Id.Should().BeGreaterThan(0);
            descriptionResponse!.Description.Should().NotBeNullOrEmpty();
            descriptionResponse!.StoreId.Should().Be(storeResponse!.Id);
        }

        [Fact]
        public async Task Post_StoreDescriptionWithInvalidStoreId_Fails()
        {
            var descriptionDto = new StoreDescriptionCreateDto
            {
                StoreId = _fixture.Create<System.Guid>(),
                Description = _fixture.Create<string>()
            };

            // Act
            var result = await PostAsync(EntityUrl, descriptionDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #endregion
    }
}