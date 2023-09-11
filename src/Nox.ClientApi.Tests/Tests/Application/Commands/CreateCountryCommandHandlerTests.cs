using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture.AutoMoq;
using AutoFixture;

namespace ClientApi.Tests.Tests.Controllers;

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

        var postResult = await _oDataFixture.PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);
        var headers = _oDataFixture.CreateEtagHeader(postResult?.Etag);
        var putResult = await _oDataFixture.PutAsync<CountryUpdateDto, CountryDto>($"{CountryControllerName}/{postResult!.Id}", countryUpdateDto, headers);

        //Assert

        putResult.Should().NotBeNull();
        putResult!.Population.Should().Be(expectedNumber);
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
        var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);

        //Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(expectedName);
    }
}