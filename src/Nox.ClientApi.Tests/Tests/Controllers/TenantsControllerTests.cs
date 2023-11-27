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
        public async Task CreateTenant_ToEntityWithNuid_NuidIsCreated()
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
        public async Task UpdateTenantName_ShouldFailWithNuidException()
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
            putResult!.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #region Owned Entities

        #region Localizations

        [Fact]
        public async Task CreateTenant_WhenProvidingTenantBrandDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var enTenant = new TenantCreateDto
            {
                Name = "IWG plc",
                TenantBrands = new List<TenantBrandUpsertDto>
                {
                    new()
                    {
                        Name = "Regus",
                        Description = "Regus is part of a collective of global and regional workspace brands that form the IWG network.",
                    },
                },
            };

            // Act
            var postResult = await CreateTenantAsync(enTenant);

            var enResult = await GetTenantByIdAsync(postResult!.Id, language: "en-US");

            // Assert
            enResult.Should().NotBeNull();
            enResult!.Id.Should().Be(postResult.Id);
            enResult.Name.Should().Be(enTenant.Name);
            enResult.TenantBrands[0].Name.Should().Be(enTenant.TenantBrands[0].Name);
            enResult.TenantBrands[0].Description.Should().Be(enTenant.TenantBrands[0].Description);
        }

        [Fact]
        public async Task CreateTenant_WhenProvidingTenantBrandNotDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var frTenant = new TenantCreateDto
            {
                Name = "IWG plc",
                TenantBrands = new List<TenantBrandUpsertDto>
                {
                    new()
                    {
                        Name = "Regus",
                        Description = "Regus fait partie d’un collectif de marques mondiales et régionales d’espaces de travail qui forment le réseau IWG.",
                    },
                },
            };

            // Act
            var postResult = await CreateTenantAsync(frTenant);

            var frResult = await GetTenantByIdAsync(postResult!.Id, language: "fr-FR");

            // Assert
            frResult.Should().NotBeNull();
            frResult!.Id.Should().Be(postResult.Id);
            frResult.Name.Should().Be(frTenant.Name);
            frResult.TenantBrands[0].Name.Should().Be(frTenant.TenantBrands[0].Name);
            frResult.TenantBrands[0].Description.Should().Be(frTenant.TenantBrands[0].Description);
        }

        [Fact]
        public async Task CreateTenantAndUpdateTenantBrands_WithTenantBrandDescription_CreatesCorrectLocalizations()
        {
            // Arrange
            var tenantId = (await CreateTenantAsync(new TenantCreateDto { Name = "IWG plc" }))!.Id;

            var enTenantBrand = new TenantBrandUpsertDto
            {
                Name = "Regus",
                Description = "Regus is part of a collective of global and regional workspace brands that form the IWG network.",
            };

            var frTenantBrand = new TenantBrandUpsertDto
            {
                Name = "Regus",
                Description = "Regus fait partie d’un collectif de marques mondiales et régionales d’espaces de travail qui forment le réseau IWG.",
            };

            var deTenantBrand = new TenantBrandUpsertDto
            {
                Name = "Regus",
                Description = "Regus ist Teil eines Kollektivs globaler und regionaler Arbeitsplatzmarken, die das IWG-Netzwerk bilden.",
            };

            // Act
            var postResult = await CreateTenantBrandAsync(tenantId, enTenantBrand, language: "en-US");
            _ = await UpdateTenantBrandAsync(tenantId, postResult!.Id, frTenantBrand, language: "fr-FR");
            _ = await PartiallyUpdateTenantBrandAsync(tenantId, postResult!.Id, deTenantBrand, language: "de-DE");

            var enResult = await GetTenantByIdAsync(tenantId, language: "en-US");
            var frResult = await GetTenantByIdAsync(tenantId, language: "fr-FR");
            var deResult = await GetTenantByIdAsync(tenantId, language: "de-DE");
            var itResult = await GetTenantByIdAsync(tenantId, language: "it-IT");

            // Assert
            enResult.Should().NotBeNull();
            enResult!.TenantBrands[0].Description.Should().Be(enTenantBrand.Description);

            frResult.Should().NotBeNull();
            frResult!.TenantBrands[0].Description.Should().Be(frTenantBrand.Description);

            deResult.Should().NotBeNull();
            deResult!.TenantBrands[0].Description.Should().Be(deTenantBrand.Description);

            itResult.Should().NotBeNull();
            itResult!.TenantBrands[0].Description.Should().Be("[" + enTenantBrand.Description + "]");
        }

        #endregion Localizations

        #endregion Owned Entities

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

        #region Utils

        private async Task<TenantDto?> CreateTenantAsync(TenantCreateDto tenant, string? language = null)
            => await PostAsync<TenantCreateDto, TenantDto>($"{Endpoints.TenantsUrl}{CreateLangParam(language)}", tenant);

        private async Task<TenantDto?> GetTenantByIdAsync(uint id, string? language = null)
            => await GetODataSimpleResponseAsync<TenantDto>($"{Endpoints.TenantsUrl}/{id}{CreateLangParam(language)}");

        private async Task<TenantBrandDto?> CreateTenantBrandAsync(uint tenantId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PostAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private async Task<TenantBrandDto?> UpdateTenantBrandAsync(uint tenantId, long tenantBrandId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PutAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands/{tenantBrandId}{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private async Task<TenantBrandDto?> PartiallyUpdateTenantBrandAsync(uint tenantId, long tenantBrandId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PatchAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands/{tenantBrandId}{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private static string CreateLangParam(string? language = null)
            => string.IsNullOrWhiteSpace(language) ? string.Empty : $"?lang={language}";

        #endregion
    }
}
