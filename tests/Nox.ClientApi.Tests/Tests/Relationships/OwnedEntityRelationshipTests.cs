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
    public async Task WhenUpdatingCountry_WithExistingCountryTimeZones_AllShouldBeUpdated()
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
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/NEW_YORK", Name = "Eastern Standard Time" },
                new() { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
                new() { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
                new() { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
            }
        };

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto { Id = "AMERICA/NEW_YORK", Name = "Eastern Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
        });
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithExistingAndNewCountryTimeZones_ExistingShouldBeUpdatedAndNewShouldBeCreated()
    {
        // Arrange
        var country = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto
        {
            Name = "United States of America",
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
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
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/NEW_YORK", Name = "Eastern Standard Time" },
                new() { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
                new() { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
                new() { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
            }
        };

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto {Id = "AMERICA/NEW_YORK", Name = "Eastern Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
        });
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithExistingAndRemovedCountryTimeZones_ExistingShouldBeUpdatedAndRemovedShouldBeDeleted()
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
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>
            {
                new() { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
                new() { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
                new() { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
            }
        };

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" },
        });
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithEmptyCountryTimeZones_ExistingShouldBeDeleted()
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

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones.Should().BeEmpty();
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithNullCountryTimeZones_NoChangesShouldBeMade()
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

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones.Should().BeEquivalentTo(new[]
        {
            new CountryTimeZoneDto { Id = "AMERICA/NEW_YORK" },
            new CountryTimeZoneDto { Id = "AMERICA/CHICAGO" },
            new CountryTimeZoneDto { Id = "AMERICA/DENVER" },
            new CountryTimeZoneDto { Id = "AMERICA/LOS_ANGELES" }
        });
    }

    [Fact]
    public async Task WhenUpdatingCountry_WithUndefinedCountryTimeZones_NoChangesShouldBeMade()
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

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

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