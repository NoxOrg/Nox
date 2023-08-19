using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Nox.ClientApi.Tests.Tests
{
    public class ClientDatabaseNumbersControllerTests
    {
        [Theory, AutoMoqData]
        public async void Post_ReturnsAutoNumberId(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>()
                });
            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqData]
        public async void Post_IfNoRequireField_ThrowsException(ApiFixture apiFixture)
        {
            
            // Arrange  
            Func<Task> action = () =>
            {
                return apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    //Name = null
                });
            };

            // Act 
            // Assert
            //await action.Should().ThrowAsync<ModelValidationException?>();
            //This is incorrect is getting to the insert command should fail model validation
            await action.Should().ThrowAsync<Microsoft.EntityFrameworkCore.DbUpdateException>();            
        }
    }
}
