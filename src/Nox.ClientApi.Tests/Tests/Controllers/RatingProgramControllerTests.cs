using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("StoreDescriptionsControllerTests")]
    public class RatingProgramControllerTests : NoxWebApiTestBase
    {
        public RatingProgramControllerTests(ITestOutputHelper testOutput, TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
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

            var storeResponse = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, storeDto);

            var ratingDto = new RatingProgramCreateDto
            {
                StoreId = storeResponse!.Id,
                Name = _fixture.Create<string>()
            };

            // Act
            var ratingResponse = await PostAsync<RatingProgramCreateDto, RatingProgramDto>(Endpoints.RatingProgramsUrl, ratingDto);

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
            var result = await PostAsync(Endpoints.RatingProgramsUrl, ratingDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #endregion KEY AS ENTITYID
    }
}