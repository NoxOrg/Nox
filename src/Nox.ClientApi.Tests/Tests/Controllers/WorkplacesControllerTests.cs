using FluentAssertions;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests : NoxIntgrationTestBase
    {
        private const string WorkplacesControllerName = "workplaces";

        public WorkplacesControllerTests(NoxTestApplicationFactory<StartupFixture> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Post_ReturnsDatabaseGuidId()
        {
            // Arrange            
            var createDto = new WorkplaceCreateDto
            {
                Name = _objectFixture.Create<string>()
            };

            // Act 
            var result = await PostAsync<WorkplaceCreateDto, CreatedODataResult<WorkplaceKeyDto>>(WorkplacesControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Put_Number_ShouldUpdate()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _objectFixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = _objectFixture.Create<string>(),
            };

            var result = await PostAsync<WorkplaceCreateDto, CreatedODataResult<WorkplaceKeyDto>>(WorkplacesControllerName, createDto);

            // Act 
            var putResult = await PutAsync<WorkplaceUpdateDto,UpdatedODataResult<WorkplaceKeyDto>>($"{WorkplacesControllerName}/{result!.Entity.keyId}", updateDto);

            var queryResult = await GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.Entity.keyId}");

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
        }

        [Fact]
        public async Task Patch_Name_ShouldUpdateNameOnly()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _objectFixture.Create<string>(),
            };


            var result = await PostAsync<WorkplaceCreateDto, CreatedODataResult<WorkplaceKeyDto>>(WorkplacesControllerName, createDto);

            // Act 
            var expectedName = _objectFixture.Create<string>();
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<WorkplaceUpdateDto>();
            updatedProperties.TrySetPropertyValue("Name", expectedName);

            var patchResult = await PatchAsync<WorkplaceUpdateDto, UpdatedODataResult<WorkplaceKeyDto>>($"{WorkplacesControllerName}/{result!.Entity.keyId}", updatedProperties);
            var queryResult = await GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.Entity.keyId}");

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<WorkplaceKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.Name.Should().Be(expectedName);
        }


        [Fact]
        public async Task Deleted_ShouldPerformHardDelete()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _objectFixture.Create<string>(),
            };


            var result = await PostAsync<WorkplaceCreateDto, CreatedODataResult<WorkplaceKeyDto>>(WorkplacesControllerName, createDto);

            // Act
            await DeleteAsync($"{WorkplacesControllerName}/{result!.Entity.keyId}");
            var queryResult = await GetAsync($"{WorkplacesControllerName}/{result!.Entity.keyId}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
