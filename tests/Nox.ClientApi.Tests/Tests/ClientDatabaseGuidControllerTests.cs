using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Nox.Types;
using Microsoft.AspNetCore.Mvc;
using ClientApi.Infrastructure.Persistence;

namespace Nox.ClientApi.Tests.Tests
{
    [Collection("Sequential")]
    public class ClientDatabaseGuidControllerTests
    {
        [Theory, AutoMoqData]
        public async Task Post_ReturnsDatabaseGuidId(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = await apiFixture.ClientDatabaseGuidsController!.Post(
                new ClientDatabaseGuidCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>()
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientDatabaseGuidKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqData]
        public async Task Put_Number_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<ClientDatabaseGuidKeyDto>)await apiFixture.ClientDatabaseGuidsController!.Post(
                new ClientDatabaseGuidCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act 
            var putResult = await apiFixture.ClientDatabaseGuidsController!.Put(result.Entity.keyId,
                new ClientDatabaseGuidUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            var queryResult = await apiFixture.ClientDatabaseGuidsController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseGuidKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
        }

        [Theory, AutoMoqData]
        public async Task Patch_Name_ShouldUpdateNameOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<ClientDatabaseGuidKeyDto>)await apiFixture.ClientDatabaseGuidsController!.Post(
                new ClientDatabaseGuidCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act 
            var expectedName = apiFixture.Fixture.Create<string>();
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<ClientDatabaseGuidUpdateDto>();
            updatedProperties.TrySetPropertyValue("Name", expectedName);

            var patchResult = await apiFixture.ClientDatabaseGuidsController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.ClientDatabaseGuidsController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseGuidKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ToDto().Name.Should().Be(expectedName);
        }


        [Theory, AutoMoqData]
        public async Task Deleted_ShouldPerformHardDelete(ApiFixture apiFixture)
        {
            // Arrange  
            var result = (CreatedODataResult<ClientDatabaseGuidKeyDto>)await apiFixture.ClientDatabaseGuidsController!.Post(
                new ClientDatabaseGuidCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act
            await apiFixture.ClientDatabaseGuidsController.Delete(result.Entity.keyId);

            // Assert
            var queryResult = await apiFixture.ClientDatabaseGuidsController!.Get(result.Entity.keyId);

            (queryResult.Result as NotFoundResult)!.StatusCode.Should().Be(404);
            queryResult.Value.Should().BeNull();

            var context = apiFixture.ServiceProvider.GetService<ClientApiDbContext>()!;
            context.ClientDatabaseNumbers.Find(DatabaseNumber.FromDatabase(result.Entity.keyId)).Should().BeNull();
        }
    }
}
