using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class GetCountryByIdQueryValidatorTests : NoxIntegrationTestBase
    {
        private const string CountryControllerName = "countries";
        private readonly Fixture _fixture = new();

        public GetCountryByIdQueryValidatorTests(NoxTestApplicationFactory<StartupFixture> appFactory) : base(appFactory)
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

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
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
            var result = await GetAsync<IEnumerable<CountryDto>>(CountryControllerName);

            //Assert
            result!.Count().Should().Be(expectedCount);
        }
    }
}