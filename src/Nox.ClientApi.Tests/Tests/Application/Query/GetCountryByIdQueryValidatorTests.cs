using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class GetCountryByIdQueryValidatorTests : NoxWebApiTestBase
    {
        private const string CountryControllerName = "api/countries";

        public GetCountryByIdQueryValidatorTests(
            ITestOutputHelper testOutputHelper,
            NoxTestContainerService containerService)
            : base(testOutputHelper, containerService, true)
        {
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>
        [Fact]
        public async Task Get_CountriesWithKeyGreaterThen50_ShouldFailSecurityValidation()
        {
            // Act
            var result = await GetAsync($"{CountryControllerName}/51");
            var response = await result.Content.ReadFromJsonAsync<SimpleResponse>();
            // Assert
            response!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response!.Message.Should().Contain("No permissions for keys greater then 50");
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>
        [Fact]
        public async Task Get_AllCountries_ShouldReturnAllWithKeysLowerThen50()
        {
            // Arrange
            const int expectedCount = 49;
            const int totalCountryCount = 55;

            for (int i = 0; i < totalCountryCount; i++)
            {
                var countryDto = new CountryCreateDto
                {
                    Name = _fixture.Create<string>(),
                    Population = i * 1000000
                };
                await PostAsync(CountryControllerName, countryDto);
            }

            // Act
            var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>(CountryControllerName);

            //Assert
            result!.Should().HaveCount(expectedCount);
        }
    }
}