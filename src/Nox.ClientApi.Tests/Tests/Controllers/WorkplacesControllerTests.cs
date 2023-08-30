using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests : NoxIntgrationTestBase
    {
        private const string WorkplacesControllerName = "api/workplaces";

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
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<WorkplaceKeyDto>()
                .Which.keyId.Should().NotBeEmpty();
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

            var result = await PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

            // Act
            await PutAsync<WorkplaceUpdateDto>($"{WorkplacesControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.keyId}");

            //Assert
            queryResult.Should().NotBeNull();
        }

        [Fact]
        public async Task Patch_Name_ShouldUpdateNameOnly()
        {
            // Arrange
            var expectedName = _objectFixture.Create<string>();

            var createDto = new WorkplaceCreateDto
            {
                Name = _objectFixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = expectedName
            };

            var result = await PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

            // Act

            await PatchAsync($"{WorkplacesControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.keyId}");

            //Assert
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

            var result = await PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

            // Act
            await DeleteAsync($"{WorkplacesControllerName}/{result!.keyId}");
            var queryResult = await GetAsync($"{WorkplacesControllerName}/{result!.keyId}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}