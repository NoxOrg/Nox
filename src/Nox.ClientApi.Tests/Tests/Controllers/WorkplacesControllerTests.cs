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
        private const string EntityPluralName = "workplaces";
        private const string EntityUrl = $"api/{EntityPluralName}";

        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public WorkplacesControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        [Fact]
        public async Task Post_ToEntityWithNuid_NuidIsCreated()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Portugal"
            };

            // Act
            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(EntityUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<WorkplaceKeyDto>()
                .Which.keyId.Should().Be(3891835289); // We can pre compute the expected nuid
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

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(EntityUrl, createDto);

            // Act
            await _oDataFixture.PutAsync<WorkplaceUpdateDto>($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<WorkplaceDto>($"{EntityUrl}/{result!.keyId}");

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

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(EntityUrl, createDto);

            // Act

            await _oDataFixture.PatchAsync($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<WorkplaceDto>($"{EntityUrl}/{result!.keyId}");

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

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceKeyDto>(EntityUrl, createDto);

            // Act
            await _oDataFixture.DeleteAsync($"{EntityUrl}/{result!.keyId}");
            var queryResult = await _oDataFixture.GetAsync($"{EntityUrl}/{result!.keyId}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}