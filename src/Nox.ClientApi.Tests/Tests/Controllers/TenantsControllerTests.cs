using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ClientApi.Tests.Controllers
{
    [Collection("Sequential")]
    public class TenantsControllerTests : NoxWebApiTestBase
    {
        public TenantsControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }
            [Fact]
        public async Task Post_ToEntityWithNuid_NuidIsCreated()
        {
            // Arrange
            var createDto = new TenantCreateDto
            {
                Name = "IWG plc"
            };

            // Act
            var result = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<TenantDto>()
                .Which.Id.Should().Be(3547564728); // We can pre compute the expected nuid
        }

        [Fact]
        public async Task Put_Name_ShouldFailWithNuidException()
        {
            // Arrange
            var createDto = new TenantCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var updateDto = new TenantUpdateDto
            {
                Name = _fixture.Create<string>(),
            };

            var postResult = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl, createDto);

            var headers = CreateEtagHeader(postResult?.Etag);

            // Act
            var putResult = await PutAsync<TenantUpdateDto>($"{Endpoints.TenantsUrl}/{postResult!.Id}", updateDto, headers, false);

            //Assert
            var errorMessage = await putResult!.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Immutable nuid property Id value is different since it has been initialized");
            putResult.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
