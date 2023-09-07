using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests 
    {
        private const string WorkplacesControllerName = "api/workplaces";
        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public WorkplacesControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        [Fact]
        public async Task Post_ReturnsDatabaseGuidId()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>()
            };

            // Act
            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<WorkplaceDto>()
                .Which.Id.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Put_Number_ShouldUpdate()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = _fixture.Create<string>(),
            };

            var postResult = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesControllerName, createDto);

            // Act
            var putResult = await _oDataFixture.PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{WorkplacesControllerName}/{postResult!.Id}", updateDto);

            //Assert
            putResult.Should().NotBeNull();
        }

        [Fact(Skip = "Fix issue with delta serialization")]
        public async Task Patch_Name_ShouldUpdateNameOnly()
        {
            // Arrange
            var expectedName = _fixture.Create<string>();

            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = expectedName
            };

            var postResult = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesControllerName, createDto);

            // Act

            var patchResult = await _oDataFixture.PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{WorkplacesControllerName}/{postResult!.Id}", updateDto);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult!.Name.Should().Be(expectedName);
        }

        [Fact]
        public async Task Deleted_ShouldPerformHardDelete()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesControllerName, createDto);

            // Act
            await _oDataFixture.DeleteAsync($"{WorkplacesControllerName}/{result!.Id}");
            var queryResult = await _oDataFixture.GetAsync($"{WorkplacesControllerName}/{result!.Id}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}