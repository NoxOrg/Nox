using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;

namespace Nox.ClientApi.Tests.Tests.Controllers;

[Collection("Sequential")]
public class CreateCountryCommandHandlerTests 
{
    private const string CountryControllerName = "api/countries";
    private readonly Fixture _fixture;
    private readonly ODataFixture _oDataFixture;

    public CreateCountryCommandHandlerTests()
    {
        _fixture = new Fixture();
        _fixture.Customize(new AutoMoqCustomization());
        _oDataFixture = _fixture.Create<ODataFixture>();
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

        var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, countryDto);
        var etag = await GetEtagAsync(result);
        var headers = _oDataFixture.CreateEtagHeader(etag);

        await _oDataFixture.PutAsync($"{CountryControllerName}/{result!.keyId}", countryUpdateDto, headers);
        var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
        var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, countryDto);
        var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

        //Assert
        queryResult.Should().NotBeNull();
        queryResult!.Name.Should().Be(expectedName);
    }

    private async Task<System.Guid?> GetEtagAsync(CountryKeyDto? keyDto)
    {
        if (keyDto == null)
            return null;

        var result = await _oDataFixture.GetAsync<CountryDto>($"{CountryControllerName}/{keyDto!.keyId}");
        return result?.Etag;
    }
}