using FluentAssertions;
using ClientApi.Application.Dto;
using Xunit.Abstractions;
using AutoFixture;

namespace ClientApi.Tests.Tests.Controllers;

[Collection("Sequential")]
public class FormulaTests : NoxWebApiTestBase
{
    public FormulaTests(ITestOutputHelper testOutput,
        TestDatabaseContainerService containerService)
        : base(testOutput, containerService) { }

    [Fact]
    public async Task Formula_ShouldReturnDouble()
    {
        // Arrange
        var debt = 999999999;
        var population = 15000000;
        double expectedDebtPerCapita = (double)debt / population;
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Population = population,
            CountryDebt = new MoneyDto { Amount = debt, CurrencyCode = Nox.Types.CurrencyCode.USD }
        });

        // Act
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.DebtPerCapita.Should().NotBeNull();
        getCountryResponse!.DebtPerCapita!.Should().Be(expectedDebtPerCapita);
    }
}