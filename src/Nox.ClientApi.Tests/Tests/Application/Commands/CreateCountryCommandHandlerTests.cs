using FluentAssertions;
using ClientApi.Application.Dto;

namespace Nox.ClientApi.Tests.Tests.Controllers;

[Collection("Sequential")]
public class CreateCountryCommandHandlerTests : NoxIntgrationTestBase
{
    private const string CountryControllerName = "api/countries";

    public CreateCountryCommandHandlerTests(NoxTestApplicationFactory<StartupFixture> factory) : base(factory)
    {
    }

    /// <summary>
    /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
    /// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientDatabaseNumberCommand>.
    /// </summary>
    [Fact]
    public async Task Put_PopulationNegative_ShouldUpdateTo0()
    {
        // Arrange
        var expectedNumber = 0;
        var countryDto = new CountryCreateDto
        {
            Name = "Test",
            Population = -1
        };
        var countryUpdateDto = new CountryUpdateDto
        {
            Name = "Test",
            Population = expectedNumber
        };
        // Act

        var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, countryDto);
        await PutAsync($"{CountryControllerName}/{result!.keyId}", countryUpdateDto);
        var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

        //Assert

        queryResult.Should().NotBeNull();
        queryResult!.Population.Should().Be(expectedNumber);
    }

    /// <summary>
    /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
    /// Example to Ensure or validate invariants for an entity
    /// </summary>
    [Fact]
    public async Task Put_Name_ShouldEnsureTitelize()
    {
        // Arrange
        var expectedName = "Portugal";

        // Act
        var countryDto = new CountryCreateDto
        {
            Name = "portugal",
        };

        // Act
        var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, countryDto);
        var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

        //Assert
        queryResult.Should().NotBeNull();
        queryResult!.Name.Should().Be(expectedName);
    }
}