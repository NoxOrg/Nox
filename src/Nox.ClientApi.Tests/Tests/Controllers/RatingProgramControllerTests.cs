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
    public class RatingProgramControllerTests : NoxIntegrationTestBase
    {
        private const string EntityPluralName = "ratingprograms";
        private const string EntityUrl = $"api/{EntityPluralName}";
        private const string StoresUrl = $"api/stores";

        public RatingProgramControllerTests(NoxTestContainerService containerService) : base(containerService)
        {
        }

        #region KEY AS ENTITYID

        [Fact]
        public async Task Post_RatingProgramWithStoreId_Success()
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

            var ratingDto = new RatingProgramCreateDto
            {
                StoreId = storeResponse!.Id,
                Name = _fixture.Create<string>()
            };

            // Act
            var ratingResponse = await PostAsync<RatingProgramCreateDto, RatingProgramDto>(EntityUrl, ratingDto);

            //Assert
            ratingResponse.Should().NotBeNull();
            ratingResponse!.Id.Should().BeGreaterThan(0);
            ratingResponse!.Name.Should().NotBeNullOrEmpty();
            ratingResponse!.StoreId.Should().Be(storeResponse!.Id);
        }

        [Fact]
        public async Task Post_RatingProgramWithInvalidStoreId_Fails()
        {
            var ratingDto = new RatingProgramCreateDto
            {
                StoreId = _fixture.Create<System.Guid>(),
                Name = _fixture.Create<string>()
            };

            // Act
            var result = await PostAsync(EntityUrl, ratingDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #endregion
    }
}