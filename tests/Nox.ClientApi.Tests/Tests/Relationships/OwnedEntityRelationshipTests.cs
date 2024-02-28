using AutoFixture;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Types;
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
    public async Task WhenUpdatingCountryTimeZones_Existing_AllShouldBeUpdated()
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
        var updateDto = new CountryTimeZoneUpsertDto[]
        {
            new() { Id = "AMERICA/NEW_YORK", Name = "Eastern Standard Time" },
            new() { Id = "AMERICA/CHICAGO", Name = "Central Standard Time" },
            new() { Id = "AMERICA/DENVER", Name = "Mountain Standard Time" },
            new() { Id = "AMERICA/LOS_ANGELES", Name = "Pacific Standard Time" }
        };

        await PutAsync($"{Endpoints.CountriesUrl}/{country.Id}/CountryTimeZones", updateDto, etag);

        // Assert
        var updatedCountry = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{country.Id}");

        updatedCountry!.CountryTimeZones!.Find(c => c.Id == "EST")!.Name.Should().Be("Eastern Standard Time");
        updatedCountry.CountryTimeZones.Find(c => c.Id == "CST")!.Name.Should().Be("Central Standard Time");
        updatedCountry.CountryTimeZones.Find(c => c.Id == "MST")!.Name.Should().Be("Mountain Standard Time");
        updatedCountry.CountryTimeZones.Find(c => c.Id == "PST")!.Name.Should().Be("Pacific Standard Time");
    }

    [Fact]
    public async Task WhenUpdatingCountryTimeZones_ExistingAndNew_ExistingShouldBeUpdatedAndNewShouldBeCreated()
    {
        await Task.CompletedTask;
    }

    [Fact]
    public async Task WhenUpdatingCountryTimeZones_ExistingAndRemoved_ExistingShouldBeUpdatedAndRemovedShouldBeDeleted()
    {
        await Task.CompletedTask;
    }

    #endregion

    #region ToOne
    #endregion
}
