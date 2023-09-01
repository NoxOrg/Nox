using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.OData.Results;
using Nox.ClientApp.Tests.FixtureConfig;
using Nox.Types;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class GetCountryByIdQueryValidatorTests
    {
        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>        
        [Theory, AutoMoqData]        
        public async void Get_CountriesWithKeyGreaterThen50_ShouldFailSecurityValidation(ApiFixture apiFixture)
        {
            // Arrange            
            

            // Act 
            Func<Task> taskResult = async () => { await apiFixture.CountriesController!.Get(51); };

            //Assert
            await taskResult.Should().ThrowAsync<TypeValidationException>();
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>        
        [Theory, AutoMoqData]
        public async void Get_AllCountries_ShouldReturnAllWithKeysLowerThen50(ApiFixture apiFixture)
        {
            // Arrange            
            for (int i = 0; i < 55; i++)
            {
                var postResult = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                             new CountryCreateDto
                             {
                                 Name = apiFixture.Fixture.Create<string>(),
                                 Population = apiFixture.Fixture.Create<int>()
                             });
            }

            // Act 
            var result = await apiFixture.CountriesController!.Get();

            //Assert
            var executedQuery = result.ExtractResult().ToList();
            executedQuery!.Count.Should().Be(49);
        }
    }
}
