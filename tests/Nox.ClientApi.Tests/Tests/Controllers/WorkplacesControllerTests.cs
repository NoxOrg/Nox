using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Nox.Types;
using Microsoft.AspNetCore.Mvc;
using ClientApi.Infrastructure.Persistence;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests
    {
        [Theory, AutoMoqData]
        public async Task Post_ReturnsDatabaseGuidId(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = await apiFixture.WorkplacesController!.Post(
                new WorkplaceCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>()
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().NotBeEmpty();
        }

        [Theory, AutoMoqData]
        public async Task Put_Number_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<WorkplaceKeyDto>)await apiFixture.WorkplacesController!.Post(
                new WorkplaceCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act 
            var putResult = await apiFixture.WorkplacesController!.Put(result.Entity.keyId,
                new WorkplaceUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            var queryResult = await apiFixture.WorkplacesController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
        }

        [Theory, AutoMoqData]
        public async Task Patch_Name_ShouldUpdateNameOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<WorkplaceKeyDto>)await apiFixture.WorkplacesController!.Post(
                new WorkplaceCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act 
            var expectedName = apiFixture.Fixture.Create<string>();
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<WorkplaceUpdateDto>();
            updatedProperties.TrySetPropertyValue("Name", expectedName);

            var patchResult = await apiFixture.WorkplacesController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.WorkplacesController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }


        [Theory, AutoMoqData]
        public async Task Deleted_ShouldPerformHardDelete(ApiFixture apiFixture)
        {
            // Arrange  
            var result = (CreatedODataResult<WorkplaceKeyDto>)await apiFixture.WorkplacesController!.Post(
                new WorkplaceCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act
            await apiFixture.WorkplacesController.Delete(result.Entity.keyId);

            // Assert
            var queryResult = await apiFixture.WorkplacesController!.Get(result.Entity.keyId);

            (queryResult.Result as NotFoundResult)!.StatusCode.Should().Be(404);
            queryResult.Value.Should().BeNull();

            var context = apiFixture.ServiceProvider.GetService<ClientApiDbContext>()!;
            context.Workplaces.Find(DatabaseGuid.FromDatabase(result.Entity.keyId)).Should().BeNull();
        }
    }
}
