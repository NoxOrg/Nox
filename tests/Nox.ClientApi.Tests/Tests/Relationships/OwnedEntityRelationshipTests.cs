using ClientApi.Application.Dto;
using FluentAssertions;
using Xunit.Abstractions;

namespace ClientApi.Tests.Relationships;

[Collection("Sequential")]
public class OwnedEntityRelationshipTests : NoxWebApiTestBase
{
    public OwnedEntityRelationshipTests(
        ITestOutputHelper testOutput,
        TestDatabaseContainerService containerService)
        : base(testOutput, containerService)
    {
    }

    #region ToMany

    [Fact]
    public async Task WhenUpdatingCountry_WithEmptyCountryTimeZones_DeletesAllCountryTimeZones()
    {
        // Arrange
        var country = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto
        {
            Name = "United States of America",
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/NEW_YORK" },
                new() { Id = "AMERICA/CHICAGO" },
                new() { Id = "AMERICA/DENVER" },
                new() { Id = "AMERICA/LOS_ANGELES" }
            }
        });

        var etag = CreateEtagHeader(country!.Etag);

        // Act
        var updateDto = new CountryUpdateDto
        {
            Name = "United States of America",
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>()
        };

        var updatedCountry = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        updatedCountry!.CountryTimeZones.Should().BeEmpty();

    }

    [Fact]
    public async Task WhenUpdatingCountry_WithNullCountryTimeZones_DoesNotChangeCountryTimeZones()
    {
        // Arrange
        var country = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto
        {
            Name = "United States of America",
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/NEW_YORK" },
                new() { Id = "AMERICA/CHICAGO" },
                new() { Id = "AMERICA/DENVER" },
                new() { Id = "AMERICA/LOS_ANGELES" }
            }
        });

        var etag = CreateEtagHeader(country!.Etag);

        // Act
        var updateDto = new CountryUpdateDto
        {
            Name = "United States of America",
            CountryTimeZones = null!,
        };

        var updatedCountry = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto { Id = "AMERICA/NEW_YORK" },
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES" }
        });
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithUndefinedCountryTimeZones_DoesNotChangeCountryTimeZones()
    {
        // Arrange
        var country = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto
        {
            Name = "United States of America",
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/NEW_YORK" },
                new() { Id = "AMERICA/CHICAGO" },
                new() { Id = "AMERICA/DENVER" },
                new() { Id = "AMERICA/LOS_ANGELES" }
            }
        });

        var etag = CreateEtagHeader(country!.Etag);

        // Act
        var updateDto = new CountryUpdateDto
        {
            Name = "United States of America",
        };

        var updatedCountry = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto { Id = "AMERICA/NEW_YORK" },
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES" }
        });
    }

    #endregion
}