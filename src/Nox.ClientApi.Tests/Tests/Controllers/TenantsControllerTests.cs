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

        #region Many to Many Relations

        [Fact]
        public async Task WhenCreateTenantWithMultipleWorkplaces_RelationNeedsToBeCreated()
        {
            // Arrange
            var workplaceId1 = (await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var workplaceId2 = (await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            // Act
            var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>(), WorkplacesId = new() { workplaceId1, workplaceId2 } });

            var getTenantResponse = await GetODataSimpleResponseAsync<TenantDto>($"{Endpoints.TenantsUrl}/{tenantResponse!.Id}?$expand={nameof(TenantDto.Workplaces)}");

            // Assert
            getTenantResponse.Should().NotBeNull();
            getTenantResponse!.Workplaces.Should().HaveCount(2);
            getTenantResponse!.Workplaces.Should().Contain(t => t.Id == workplaceId1);
            getTenantResponse!.Workplaces.Should().Contain(t => t.Id == workplaceId2);
        }

        [Fact]
        public async Task WhenAddingWorkplaceRelationToTenants_RelationNeedsToBeCreated()
        {
            // Arrange
            var tenantId1 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var tenantId2 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var workplaceId = (await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            // Act
            await PostAsync($"{Endpoints.TenantsUrl}/{tenantId1}/Workplaces/{workplaceId}/$ref");
            await PostAsync($"{Endpoints.TenantsUrl}/{tenantId2}/Workplaces/{workplaceId}/$ref");

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceId}?$expand={nameof(WorkplaceDto.Tenants)}");

            // Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Tenants.Should().HaveCount(2);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId1);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId2);
        }

        #endregion Many to Many Relations
    }
}
