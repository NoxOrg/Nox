using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types;
using Nox.ClientApi.Tests.Tests;
using FluentValidation.TestHelper;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class GetClientDatabaseNumberByIdQueryValidatorTests
    {
        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>        
        [Theory, AutoMoqData]        
        public async void Get_NumberWithKeyGreaterThen50_ShouldFailSecurityValidation(ApiFixture apiFixture)
        {
            // Arrange            
            

            // Act 
            Func<Task> taskResult = async () => { await apiFixture.ClientDatabaseNumbersController!.Get(51); };

            //Assert
            await taskResult.Should().ThrowAsync<TypeValidationException>();
        }

        /// <summary>
        /// Test a Query or Command Validation, that can be used for security checks
        /// </summary>        
        [Theory, AutoMoqData]
        public async void Get_AllNumber_ShouldReturnAllWithKeysLowerThen50(ApiFixture apiFixture)
        {
            // Arrange            
            for (int i = 0; i < 55; i++)
            {
                var postResult = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                             new ClientDatabaseNumberCreateDto
                             {
                                 Name = apiFixture.Fixture.Create<string>(),
                                 Number = 101
                             });
            }

            // Act 
            var result = await apiFixture.ClientDatabaseNumbersController!.Get();

            //Assert
            var executedQuery = result.ExtractResult().ToList();
            executedQuery!.Count.Should().Be(49);
        }
    }
}
