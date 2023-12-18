using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using Xunit.Abstractions;

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

            var headers = CreateEtagHeader(postResult!.Etag);

            // Act
            var putResult = await PutAsync<TenantUpdateDto>($"{Endpoints.TenantsUrl}/{postResult!.Id}", updateDto, headers, false);

            //Assert            
            putResult!.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        #region Enums

        [Fact]
        public async Task CreateTenant_WithStatusId_ReturnsStatusIdAndName()
        {
            // Arrange
            var createDto = new TenantCreateDto
            {
                Name = "IWG plc",
                Status = 1,
            };

            // Act
            var result = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result!.Status.Should().Be(1);
            result!.StatusName.Should().Be("Active");
        }

        #endregion

        #region Owned Entities

        #region Localizations

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
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

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
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
            var postResult = await CreateTenantAsync(frTenant, language: "fr-FR");

            var frResult = await GetTenantByIdAsync(postResult!.Id, language: "fr-FR");

            // Assert
            frResult.Should().NotBeNull();
            frResult!.Id.Should().Be(postResult.Id);
            frResult.Name.Should().Be(frTenant.Name);
            frResult.TenantBrands[0].Name.Should().Be(frTenant.TenantBrands[0].Name);
            frResult.TenantBrands[0].Description.Should().Be(frTenant.TenantBrands[0].Description);
        }

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
        public async Task UpdateTenantWithTenantBrands_WithTenantBrandDescription_CreatesLocalization()
        {
            // Arrange
            var tenantId = (await CreateTenantAsync(
                new TenantCreateDto
                {
                    Name = "IWG plc",
                    TenantBrands = new List<TenantBrandUpsertDto>
                    {
                        new()
                        {
                            Name = "Regus",
                            Description = "Regus is part of a collective of global and regional workspace brands that form the IWG network.",
                        },
                        new()
                        {
                            Name = "Basepoint",
                            Description = "Basepoint Business Centres provide a wide range of high quality workspaces to let, including serviced and managed offices, workshops, trade counters and studios.",
                        },
                    },
                }, language: "en-US"))!.Id;

            // Act
            var frTenant = new TenantUpdateDto
            {
                Name = "IWG plc",
                TenantBrands = new List<TenantBrandUpsertDto>
                {
                    new()
                    {
                        Id = (await GetTenantByIdAsync(tenantId))!.TenantBrands[0].Id,
                        Name = "Regus",
                        Description = "Regus fait partie d’un collectif de marques mondiales et régionales d’espaces de travail qui forment le réseau IWG.",
                    },
                    new()
                    {
                        Name = "No18",
                        Description = "No18 est un mélange inspirant de lieu de travail et de résidence, offrant des espaces de travail privés et collaboratifs dans des lieux urbains en plein essor, chacun avec sa propre esthétique unique et éclectique.",
                    },
                    new()
                    {
                        Name = "BizDojo",
                        Description = "La vie chez BizDojo, c’est plus qu’un bureau ; avec des espaces, des lieux, des personnes et des programmes qui vous aident, vous et votre entreprise, à vous développer.",
                    },
                },
            };

            await UpdateTenantAsync(tenantId, frTenant, language: "fr-FR");

            var frResult = await GetTenantByIdAsync(tenantId, language: "fr-FR");

            // Assert
            frResult.Should().NotBeNull();
            frResult!.Id.Should().Be(tenantId);
            frResult.Name.Should().Be(frTenant.Name);
            frResult.TenantBrands.Should().HaveCount(3);
            frResult.TenantBrands[0].Name.Should().Be(frTenant.TenantBrands[0].Name);
            frResult.TenantBrands[0].Description.Should().Be(frTenant.TenantBrands[0].Description);
            frResult.TenantBrands[1].Name.Should().Be(frTenant.TenantBrands[1].Name);
            frResult.TenantBrands[1].Description.Should().Be(frTenant.TenantBrands[1].Description);
            frResult.TenantBrands[2].Name.Should().Be(frTenant.TenantBrands[1].Name);
            frResult.TenantBrands[2].Description.Should().Be(frTenant.TenantBrands[1].Description);
        }


        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
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

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
        public async Task CreateTenant_WhenProvidingTenantContactDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var enTenant = new TenantCreateDto
            {
                Name = "IWG plc",
                TenantContact = new TenantContactUpsertDto
                {
                    Name = "IWG plc helpdesk",
                    Description = "For more information please write to the email address below.",
                    Email = "helpdesk@iwgplc.com"
                }
            };

            // Act
            var postResult = await CreateTenantAsync(enTenant);

            var enResult = await GetTenantByIdAsync(postResult!.Id, language: "en-US");

            // Assert
            enResult.Should().NotBeNull();
            enResult!.Id.Should().Be(postResult.Id);
            enResult.Name.Should().Be(enTenant.Name);
            enResult.TenantContact!.Name.Should().Be(enTenant.TenantContact.Name);
            enResult.TenantContact.Description.Should().Be(enTenant.TenantContact.Description);
            enResult.TenantContact.Email.Should().Be(enTenant.TenantContact.Email);
        }

        [Fact(Skip = "Due to Nuid relationship issue and update owned entity localization limitation.")]
        public async Task CreateTenant_WhenProvidingTenantContactNotDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var frTenant = new TenantCreateDto
            {
                Name = "IWG plc",
                TenantContact = new TenantContactUpsertDto
                {
                    Name = "IWG plc helpdesk",
                    Description = "Pour plus d'informations, veuillez écrire à l'adresse e-mail ci-dessous.",
                    Email = "helpdesk@iwgplc.com"
                },
            };

            // Act
            var postResult = await CreateTenantAsync(frTenant, language: "fr-FR");

            var frResult = await GetTenantByIdAsync(postResult!.Id, language: "fr-FR");

            // Assert
            frResult.Should().NotBeNull();
            frResult!.Id.Should().Be(postResult.Id);
            frResult.Name.Should().Be(frTenant.Name);
            frResult.TenantContact!.Name.Should().Be(frTenant.TenantContact.Name);
            frResult.TenantContact.Description.Should().Be(frTenant.TenantContact.Description);
        }

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
        public async Task UpdateTenantWithTenantContact_WithTenantContactDescription_CreatesLocalization()
        {
            // Arrange
            var tenantId = (await CreateTenantAsync(
                new TenantCreateDto
                {
                    Name = "IWG plc",
                    TenantContact = new TenantContactUpsertDto
                    {
                        Name = "IWG plc helpdesk",
                        Description = "For more information please write to the email address below.",
                        Email = "helpdesk@iwgplc.com"
                    }
                }, language: "en-US"))!.Id;

            // Act
            var frTenant = new TenantUpdateDto
            {
                Name = "IWG plc",
                TenantContact = new TenantContactUpsertDto
                {
                    Name = "IWG plc helpdesk",
                    Description = "Pour plus d'informations, veuillez écrire à l'adresse e-mail ci-dessous.",
                    Email = "helpdesk@iwgplc.com"
                },
            };

            await UpdateTenantAsync(tenantId, frTenant, language: "fr-FR");

            var frResult = await GetTenantByIdAsync(tenantId, language: "fr-FR");

            // Assert
            frResult.Should().NotBeNull();
            frResult!.Id.Should().Be(tenantId);
            frResult.Name.Should().Be(frTenant.Name);
            frResult.TenantContact!.Name.Should().Be(frTenant.TenantContact.Name);
            frResult.TenantContact.Description.Should().Be(frTenant.TenantContact.Description);
        }

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
        public async Task CreateTenantAndUpdateTenantContact_WithTenantContactDescription_CreatesCorrectLocalizations()
        {
            // Arrange
            var tenantId = (await CreateTenantAsync(new TenantCreateDto { Name = "IWG plc" }))!.Id;

            var enTenantContact = new TenantContactUpsertDto
            {
                Name = "IWG plc helpdesk",
                Description = "For more information please write to the email address below.",
                Email = "helpdesk@iwgplc.com"
            };

            var frTenantContact = new TenantContactUpsertDto
            {
                Name = "IWG plc helpdesk",
                Description = "Pour plus d'informations, veuillez écrire à l'adresse e-mail ci-dessous.",
                Email = "helpdesk@iwgplc.com"
            };

            var deTenantContact = new TenantContactUpsertDto
            {
                Name = "IWG plc helpdesk",
                Description = "Für weitere Informationen schreiben Sie bitte an die unten angegebene E-Mail-Adresse.",
                Email = "helpdesk@iwgplc.com"
            };

            // Act
            await CreateTenantContactAsync(tenantId, enTenantContact, language: "en-US");
            await UpdateTenantContactAsync(tenantId, frTenantContact, language: "fr-FR");
            await PartiallyUpdateTenantContactAsync(tenantId, deTenantContact, language: "de-DE");

            var enResult = await GetTenantByIdAsync(tenantId, language: "en-US");
            var frResult = await GetTenantByIdAsync(tenantId, language: "fr-FR");
            var deResult = await GetTenantByIdAsync(tenantId, language: "de-DE");
            var itResult = await GetTenantByIdAsync(tenantId, language: "it-IT");

            // Assert
            enResult.Should().NotBeNull();
            enResult!.TenantContact!.Description.Should().Be(enTenantContact.Description);

            frResult.Should().NotBeNull();
            frResult!.TenantContact!.Description.Should().Be(frTenantContact.Description);

            deResult.Should().NotBeNull();
            deResult!.TenantContact!.Description.Should().Be(deTenantContact.Description);

            itResult.Should().NotBeNull();
            itResult!.TenantContact!.Description.Should().Be("[" + enTenantContact.Description + "]");
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

        #region Localizations

        [Fact(Skip = "Nuid relationship issue and update owned entity localization limitation.")]
        public async Task ExpandingLocalizedWorkplacesOnTenants_RetunsLocalizedDetails()
        {
            // Arrange
            var frWorkplace = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un bâtiment moderne et de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            var frWorkplaceId = (await CreateWorkplaceAsync(frWorkplace, language: "fr-FR"))!.Id;

            // Act
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
                TenantContact = new TenantContactUpsertDto
                {
                    Name = "IWG plc helpdesk",
                    Description = "Pour plus d'informations, veuillez écrire à l'adresse e-mail ci-dessous.",
                    Email = "helpdesk@iwgplc.com"
                },
                WorkplacesId = new List<long> { frWorkplaceId }
            };

            var frTenantId = (await CreateTenantAsync(frTenant, language: "fr-FR"))!.Id;

            var enResult = await GetODataSimpleResponseAsync<TenantDto>($"{Endpoints.TenantsUrl}/{frTenantId}?$expand={nameof(TenantDto.Workplaces)}&lang=en-US");

            var frResult = await GetODataSimpleResponseAsync<TenantDto>($"{Endpoints.TenantsUrl}/{frTenantId}?$expand={nameof(TenantDto.Workplaces)}&lang=fr-FR");

            // Assert
            enResult.Should().NotBeNull();
            enResult!.TenantBrands[0].Description.Should().Be("[" + frTenant.TenantBrands[0].Description + "]");
            enResult.TenantContact!.Description.Should().Be("[" + frTenant.TenantContact!.Description + "]");
            enResult.Workplaces[0].Description.Should().Be("[" + frWorkplace!.Description + "]");

            frResult.Should().NotBeNull();
            frResult!.TenantBrands[0].Description.Should().Be(frTenant.TenantBrands[0].Description);
            frResult.TenantContact!.Description.Should().Be(frTenant.TenantContact.Description);
            frResult.Workplaces[0].Description.Should().Be(frWorkplace.Description);
        }

        #endregion Localizations

        #endregion Many to Many Relations

        #region Utils

        private async Task<TenantDto?> CreateTenantAsync(TenantCreateDto tenant, string? language = null)
            => await PostAsync<TenantCreateDto, TenantDto>($"{Endpoints.TenantsUrl}{CreateLangParam(language)}", tenant);

        private async Task<TenantDto?> UpdateTenantAsync(uint tenantId, TenantUpdateDto tenant, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PutAsync<TenantUpdateDto, TenantDto>($"{Endpoints.TenantsUrl}/{tenantId}{CreateLangParam(language)}", tenant, CreateEtagHeader(etag));
        }

        private async Task<TenantDto?> GetTenantByIdAsync(uint id, string? language = null)
            => await GetODataSimpleResponseAsync<TenantDto>($"{Endpoints.TenantsUrl}/{id}{CreateLangParam(language)}");

        private async Task<TenantBrandDto?> CreateTenantBrandAsync(uint tenantId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PostAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private async Task<TenantBrandDto?> UpdateTenantBrandAsync(uint tenantId, long tenantBrandId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            tenantBrand.Id = tenantBrandId;
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PutAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private async Task<TenantBrandDto?> PartiallyUpdateTenantBrandAsync(uint tenantId, long tenantBrandId, TenantBrandUpsertDto tenantBrand, string? language = null)
        {
            tenantBrand.Id = tenantBrandId;
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            return await PatchAsync<TenantBrandUpsertDto, TenantBrandDto>($"{Endpoints.TenantsUrl}/{tenantId}/TenantBrands{CreateLangParam(language)}", tenantBrand, CreateEtagHeader(etag));
        }

        private async Task CreateTenantContactAsync(uint tenantId, TenantContactUpsertDto tenantContact, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            await PostAsync($"{Endpoints.TenantsUrl}/{tenantId}/TenantContact{CreateLangParam(language)}", tenantContact, CreateEtagHeader(etag));
        }

        private async Task UpdateTenantContactAsync(uint tenantId, TenantContactUpsertDto tenantContact, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            await PutAsync($"{Endpoints.TenantsUrl}/{tenantId}/TenantContact{CreateLangParam(language)}", tenantContact, CreateEtagHeader(etag));
        }

        private async Task PartiallyUpdateTenantContactAsync(uint tenantId, TenantContactUpsertDto tenantContact, string? language = null)
        {
            var etag = (await GetTenantByIdAsync(tenantId))!.Etag;
            await PatchAsync($"{Endpoints.TenantsUrl}/{tenantId}/TenantContact{CreateLangParam(language)}", tenantContact, CreateEtagHeader(etag));
        }

        private async Task<WorkplaceDto?> CreateWorkplaceAsync(WorkplaceCreateDto workplace, string? language = null)
            => await PostAsync<WorkplaceCreateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}{CreateLangParam(language)}", workplace);

        private async Task<WorkplaceDto?> UpdateWorkplaceAsync(long workplaceId, WorkplaceUpdateDto workplace, string? language = null)
        {
            var etag = (await GetWorkplaceByIdAsync(workplaceId))!.Etag;
            return await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceId}{CreateLangParam(language)}", workplace, CreateEtagHeader(etag));
        }

        private async Task<WorkplaceDto?> GetWorkplaceByIdAsync(long id, string? language = null)
            => await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{id}{CreateLangParam(language)}");

        private static string CreateLangParam(string? language = null)
            => string.IsNullOrWhiteSpace(language) ? string.Empty : $"?lang={language}";

        #endregion
    }
}
