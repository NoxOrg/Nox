using FluentAssertions;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using ClientApi.Application.Dto;

namespace ClientApi.Tests.Application.CommandHandlers;

[Collection("CreateCountryCommandHandlerTests")]
public class CreateCountryCommandHandlerTests : NoxWebApiTestBase
{
    public CreateCountryCommandHandlerTests(
        ITestOutputHelper testOutputHelper,
        TestDatabaseContainerService containerService) : base(testOutputHelper, containerService)
    {
    }

    /// <summary>
    /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
    /// For Request Validation, before command handler is executed use <see cref="IValidator"/> instead IValidator<CreateClientAutoNumberCommand>.
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
        var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryDto);
        var headers = CreateEtagHeader(postResult!.Etag);
        var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", countryUpdateDto, headers);

        //Assert

        putResult.Should().NotBeNull();
        putResult!.Population.Should().Be(expectedNumber);
    }

    /// <summary>
    /// Test a command extension for <see cref="CreateCountryCommandHandler"/>
    /// Example to Ensure or validate invariants for an entity
    /// </summary>
    [Fact]
    public async Task Put_Name_ShouldEnsureFirstLetterisCapitalized()
    {
        // Arrange
        var expectedName = "Portugal";

        // Act
        var countryDto = new CountryCreateDto
        {
            Name = "portugal",
        };

        // Act
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryDto);

        //Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(expectedName);
    }
}