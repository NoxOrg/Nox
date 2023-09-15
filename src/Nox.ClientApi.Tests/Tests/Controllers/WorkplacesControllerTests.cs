using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;

namespace ClientApi.Tests.Tests.Controllers
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

        #region RELATIONSHIPS

        #region POST

        #region POST Entity With Related Entity /api/{EntityPluralName} => api/workplaces
        [Fact]
        public async Task Post_WithSingleRelatedEntity_Success()
        {
            // Arrange
            var expectedCountryName = _fixture.Create<string>();
            var dto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                BelongsToCountry = new CountryCreateDto()
                {
                    Name = expectedCountryName
                }
            };
            // Act
            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(EntityUrl, dto);
            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            var getCountryResponse = await _oDataFixture.GetODataSimpleResponseAsync<WorkplaceDto>($"{EntityUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.BelongsToCountry.Should().NotBeNull();
            getCountryResponse!.BelongsToCountry!.Name.Should().Be(expectedCountryName);
        }
        #endregion

        #endregion

        #endregion

        [Fact]
        public async Task Post_ToEntityWithNuid_NuidIsCreated()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Portugal"
            };

            // Act
            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(EntityUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<WorkplaceDto>()
                .Which.Id.Should().Be(3891835289); // We can pre compute the expected nuid
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

            var postResult = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(EntityUrl, createDto);

            var headers = _oDataFixture.CreateEtagHeader(postResult?.Etag);

            // Act
            var putResult = await _oDataFixture.PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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

            var postResult = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(EntityUrl, createDto);

            // Act

            var patchResult = await _oDataFixture.PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{EntityUrl}/{postResult!.Id}", updateDto);

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

            var result = await _oDataFixture.PostAsync<WorkplaceCreateDto, WorkplaceDto>(EntityUrl, createDto);
            var headers = _oDataFixture.CreateEtagHeader(result?.Etag);

            // Act
            await _oDataFixture.DeleteAsync($"{EntityUrl}/{result!.Id}", headers);
            var queryResult = await _oDataFixture.GetAsync($"{EntityUrl}/{result!.Id}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}