using FluentAssertions;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoFixture;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class GetCountryByIdQueryValidatorTests : NoxIntgrationTestBase
    {
        private const string CountryControllerName = "countries";

        public GetCountryByIdQueryValidatorTests(NoxTestApplicationFactory<StartupFixture> factory) : base(factory)
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
            for (int i = 0; i < 55; i++)
            {
                var countryDto = new CountryCreateDto
                {
                    Name = _objectFixture.Create<string>(),
                    Population = i * 1000000
                };
                await PostAsync(CountryControllerName, countryDto);
            }

            // Act
            var result = await GetAsync<IEnumerable<CountryDto>>(CountryControllerName);

            //Assert
            result!.Count().Should().Be(49);
        }
    }
}