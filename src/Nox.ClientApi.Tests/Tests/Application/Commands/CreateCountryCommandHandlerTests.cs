using FluentAssertions;
using ClientApi.Application.Dto;

namespace ClientApi.Tests.Tests.Controllers;

[Collection("Sequential")]
public class CreateCountryCommandHandlerTests : NoxIntegrationTestBase
{
    private const string CountryControllerName = "api/countries";

    public CreateCountryCommandHandlerTests(NoxTestContainerService containerService) : base(containerService)
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

        var postResult = await PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);
        var headers = CreateEtagHeader(postResult?.Etag);
        var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{CountryControllerName}/{postResult!.Id}", countryUpdateDto, headers);

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
        var result = await PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);

        //Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(expectedName);
    }
}