using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Nox.ClientApi.Tests.Tests
{
    [Collection("Sequential")]
    public class ClientDatabaseNumbersControllerTests
    {
        [Theory, AutoMoqData]
        public async void Post_ReturnsDatabaseNumberId(ApiFixture apiFixture)
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
        public async void Patch_Number_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 50;
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Number = 1
                });

            // Act 
            var putResult = await apiFixture.ClientDatabaseNumbersController!.Put(result.Entity.keyId,
                new ClientDatabaseNumberUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Number = expectedNumber
                });
            var queryResult  = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ToDto().Number.Should().Be(expectedNumber);
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
