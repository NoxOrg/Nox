﻿using FluentAssertions;
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
        public GetCountryByIdQueryValidatorTests(
            ITestOutputHelper testOutputHelper,
            TestDatabaseContainerService containerService)
            : base(testOutputHelper, containerService)
        {
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>
        [Fact]
        public async Task Get_CountriesWithKeyGreaterThen300_ShouldFailSecurityValidation()
        {
            // Act
            var result = await GetAsync($"{Endpoints.CountriesUrl}/301");
            var response = await result.Content.ReadFromJsonAsync<ApplicationErrorCodeResponse>();
            // Assert
            result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response!.Error.Code.Should().Be("bad_request");
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>
        [Fact]
        public async Task Get_AllCountries_ShouldReturnAllWithKeysLowerThen300()
        {
            // Arrange
            const int expectedCount = 58;
            const int totalCountryCount = 65;

            for (int i = 0; i < totalCountryCount; i++)
            {
                var countryDto = new CountryCreateDto
                {
                    Name = _fixture.Create<string>(),
                    Population = i * 1000000
                };
                await PostAsync(Endpoints.CountriesUrl, countryDto);
            }

            // Act
            var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>(Endpoints.CountriesUrl);

            //Assert
            result!.Should().HaveCount(expectedCount);
        }
    }
}