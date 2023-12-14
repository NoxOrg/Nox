using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("CountryQualityOfLifeIndexControllerTests")]
    public class CountryQualityOfLifeIndexControllerTests : NoxWebApiTestBase
    {
        public CountryQualityOfLifeIndexControllerTests(ITestOutputHelper testOutput, TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        #region KEY AS ENTITYID

        [Fact]
        public async Task Post_CountryQualityOfLifeIndex_Success()
        {
            // Arrange
            var countryDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 1_000_000
            };

            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryDto);

            var indexDto = new CountryQualityOfLifeIndexCreateDto
            {
                CountryId = countryResponse!.Id,
                IndexRating = _fixture.Create<int>()
            };

            // Act
            var indexResponse = await PostAsync<CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexDto>(Endpoints.CountryQualityOfLifeIndicesUrl, indexDto);

            //Assert
            indexResponse.Should().NotBeNull();
            indexResponse!.Id.Should().BeGreaterThan(0);
            indexResponse!.IndexRating.Should().BeGreaterThan(0);
            indexResponse!.CountryId.Should().Be(countryResponse!.Id);
        }

        [Fact]
        public async Task Post_IndexWithInvalidCountryId_Fails()
        {
            var indexDto = new CountryQualityOfLifeIndexCreateDto
            {
                CountryId = _fixture.Create<long>(),
                IndexRating = _fixture.Create<int>()
            };

            // Act
            var result = await PostAsync(Endpoints.CountryQualityOfLifeIndicesUrl, indexDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #endregion KEY AS ENTITYID
    }
}