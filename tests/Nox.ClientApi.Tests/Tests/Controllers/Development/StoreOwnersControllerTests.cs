using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using Nox.Types;
using Xunit.Abstractions;
using ClientApi.Domain;
using ClientApi.Tests.Tests.Models;
using Nox.Exceptions;
using System.Text.Json;

namespace ClientApi.Tests.Controllers.Development
{
    [Collection("Sequential")]
    public class StoreOwnersControllerTests : NoxWebApiTestBase
    {
        public StoreOwnersControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService, environment: Environments.Development)
        {
        }

        [Fact]
        public async Task Post_WhenInvalidId_ReturnsBadRequestError()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "1",//min is 3 characters
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await PostAsync(Endpoints.StoreOwnersUrl, createDto);

            // Assert
            // represent a nox type exception
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var content = await result.Content.ReadAsStringAsync();
            var applicationError = DeserializeResponse<ApplicationErrorCodeResponse<List<AttributeNoxTypeValidationException>>>(content);
            applicationError!.Error.Details.Should().HaveCount(1);
            applicationError!.Error.Details[0].AttributeName.Should().Be("Id");
        }
    }
}