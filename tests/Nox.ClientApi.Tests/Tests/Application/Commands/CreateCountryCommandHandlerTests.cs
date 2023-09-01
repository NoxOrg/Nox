using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.OData.Results;
using Nox.ClientApp.Tests.FixtureConfig;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CreateCountryCommandHandlerTests
    {
        /// <summary>
        /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
        /// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
        /// </summary>        
        [Theory, AutoMoqData]        
        public async void Put_PopulationNegative_ShouldUpdateTo0(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 0;

            // Act 
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
               new CountryCreateDto
               {
                   Name = apiFixture.Fixture.Create<string>(),
                   Population = -1
               });

            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            
            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Population.Should().Be(expectedNumber);
        }

        /// <summary>
        /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
        /// Example to Ensure or validate invariants for an entity
        /// </summary>        
        [Theory, AutoMoqData]
        public async void Put_Name_ShouldEnsureTitelize(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedName = "Portugal";

            // Act 
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
               new CountryCreateDto
               {
                   Name = "portugal",
               });

            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }
    }
}
