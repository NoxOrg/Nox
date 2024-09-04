using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using Nox.Application.Dto;
using static MassTransit.ValidationResultExtensions;

namespace ClientApi.Tests.Tests.Controllers.Development
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests : NoxWebApiTestBase
    {
        public WorkplacesControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService, environment: Environments.Development)
        {
        }

        [Fact]
        public async Task Put_WithoutEtag_ShouldGetConflictError()
        {
            var nameFixture = _fixture.Create<string>();

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                // Name shouldn't change, description should
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = new Dictionary<string, IEnumerable<string>>();

            // Act
            var responseMessage = await PutAsync($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);
            var content = await responseMessage!.Content.ReadAsStringAsync();

            //Assert
            responseMessage
                .Should()
                .HaveStatusCode(HttpStatusCode.PreconditionRequired);

            content.Should()
                .Contain("ETag is empty. ETag should be provided via the If-Match HTTP Header.");

            headers = new()
            {
                { "If-Match", new List<string> { $"\"wrongETag\"" } }
            };

            responseMessage = await PutAsync($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);
            content = await responseMessage!.Content.ReadAsStringAsync();

            responseMessage
                .Should()
                .HaveStatusCode(HttpStatusCode.PreconditionFailed);

            content.Should()
                .Contain("ETag is not well-formed.");
        }
    }
}