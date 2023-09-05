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
            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

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
                Name = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = _fixture.Create<string>(),
            };

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);
            var etag = await GetEtagAsync(result);
            var headers = _oDataFixture.CreateEtagHeader(etag);

            // Act
            await _oDataFixture.PutAsync<WorkplaceUpdateDto>($"{WorkplacesControllerName}/{result!.keyId}", updateDto, headers);
            var queryResult = await _oDataFixture.GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.keyId}");

            //Assert
            queryResult.Should().NotBeNull();
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

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);

            // Act

            await _oDataFixture.PatchAsync($"{WorkplacesControllerName}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{result!.keyId}");

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
                Name = _fixture.Create<string>(),
            };

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(WorkplacesControllerName, createDto);
            var etag = await GetEtagAsync(result);
            var headers = _oDataFixture.CreateEtagHeader(etag);

            // Act
            await _oDataFixture.DeleteAsync($"{WorkplacesControllerName}/{result!.keyId}", headers);
            
            var queryResult = await _oDataFixture.GetAsync($"{WorkplacesControllerName}/{result!.keyId}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        private async Task<System.Guid?> GetEtagAsync(WorkplaceKeyDto? keyDto)
        {
            if (keyDto == null)
                return null;

            var result = await _oDataFixture.GetAsync<WorkplaceDto>($"{WorkplacesControllerName}/{keyDto!.keyId}");
            return result?.Etag;
        }
    }
}