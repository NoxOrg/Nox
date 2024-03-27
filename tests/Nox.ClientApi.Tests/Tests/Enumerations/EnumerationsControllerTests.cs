using FluentAssertions;
using ClientApi.Application.Dto;
using System.Net;
using Xunit.Abstractions;
using Nox.Types;

namespace ClientApi.Tests.Enumerations;

[Collection("Sequential")]
public class EnumerationsControllerTests : NoxWebApiTestBase
{
    public EnumerationsControllerTests(
        ITestOutputHelper testOutput,
        TestDatabaseContainerService containerService)
        : base(testOutput, containerService)
    {
    }

    #region Owned Entity

    #region Localization

    [Fact]
    public async Task WhenDeletingSingleOwnedEntityEnumerationLocalization_WithDefaultCultureCode_ReturnsBadRequest()
    {
        // Arrange
        await PostAsync(Endpoints.TenantsUrl, new TenantCreateDto
        {
            Name = "IWG plc",
            TenantContact = new TenantContactUpsertDto
            {
                Name = "IWG plc helpdesk",
                Description = "For more information please write to the email address below.",
                Email = "helpdesk@iwgplc.com",
                Status = 1, // Active
            }
        });

        // Act
        var response = await DeleteAsync($"{Endpoints.TenantsUrl}/TenantContact/Statuses/1/Languages/en-US", throwOnError: false);

        // Assert
        response!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        (await response.Content.ReadAsStringAsync()).Should().Contain("CultureCode cannot be the default culture code: en-US.");
    }

    [Fact]
    public async Task WhenDeletingSingleOwnedEntityEnumerationLocalization_WthNonDefaultCultureCode_DeletesLocalization()
    {
        // Arrange
        await PostAsync(Endpoints.TenantsUrl, new TenantCreateDto
        {
            Name = "IWG plc",
            TenantContact = new TenantContactUpsertDto
            {
                Name = "IWG plc helpdesk",
                Description = "For more information please write to the email address below.",
                Email = "helpdesk@iwgplc.com",
                Status = 1, // Active
            }
        });

        // Can be replaced with POST enum localized call when implemented
        var context = GetDbContext();
        var tenantContactStatusLocalized = new ClientApi.Domain.TenantContactStatusLocalized
        {
            Id = TenantMetadata.CreateStatus(1),
            CultureCode = CultureCode.From("de-DE"),
            Name = "Aktiv",
        };
        await context.AddAsync(tenantContactStatusLocalized);
        await context.SaveChangesAsync();

        // Act
        var response = await DeleteAsync($"{Endpoints.TenantsUrl}/TenantContact/Statuses/1/Languages/de-DE");

        // Assert
        response!.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task WhenDeletingMultiOwnedEntityEnumerationLocalization_WithDefaultCultureCode_ReturnsBadRequest()
    {
        // Arrange
        await PostAsync(Endpoints.TenantsUrl, new TenantCreateDto
        {
            Name = "IWG plc",
            TenantBrands = new List<TenantBrandUpsertDto>
            {
                new()
                {
                    Name = "Regus",
                    Description = "Regus is part of a collective of global and regional workspace brands that form the IWG network.",
                    Status = 1, // Active
                },
            },
        });

        // Act
        var response = await DeleteAsync($"{Endpoints.TenantsUrl}/TenantBrands/Statuses/1/Languages/en-US", throwOnError: false);

        // Assert
        response!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        (await response.Content.ReadAsStringAsync()).Should().Contain("CultureCode cannot be the default culture code: en-US.");
    }

    [Fact]
    public async Task WhenDeletingMultiOwnedEntityEnumerationLocalization_WthNonDefaultCultureCode_DeletesLocalization()
    {
        // Arrange
        await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl, new TenantCreateDto
        {
            Name = "IWG plc",
            TenantBrands = new List<TenantBrandUpsertDto>
            {
                new()
                {
                    Name = "Regus",
                    Description = "Regus is part of a collective of global and regional workspace brands that form the IWG network.",
                    Status = 1, // Active
                },
            },
        });

        // Can be replaced with POST enum localized call when implemented
        var context = GetDbContext();
        var tenantBrandStatusLocalized = new ClientApi.Domain.TenantBrandStatusLocalized
        {
            Id = TenantMetadata.CreateStatus(1),
            CultureCode = CultureCode.From("de-DE"),
            Name = "Aktiv",
        };
        await context.AddAsync(tenantBrandStatusLocalized);
        await context.SaveChangesAsync();

        // Act
        var response = await DeleteAsync($"{Endpoints.TenantsUrl}/TenantBrands/Statuses/1/Languages/de-DE");

        // Assert
        response!.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    #endregion

    #endregion Owned Entity
}
