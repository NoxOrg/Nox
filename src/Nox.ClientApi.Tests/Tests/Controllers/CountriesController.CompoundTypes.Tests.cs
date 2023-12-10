using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using Nox.Application.Dto;
using System.Dynamic;

namespace ClientApi.Tests.Controllers;

[Collection("CountriesControllerTests")]
public partial class CountriesControllerCompoundTypesTests : NoxWebApiTestBase
{
    public CountriesControllerCompoundTypesTests(ITestOutputHelper testOutputHelper,
       TestDatabaseContainerService containerService
       //For Development purposes
       //TestDatabaseInstanceService containerService
       )
       : base(testOutputHelper, containerService)
    {
    }
   
    [Fact]
    public async Task WhenPutCompoundTypeMoney_ShouldSucceed()
    {
        // Arrange
        var expectedAmount = 200_000;
        var expectedName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryDebt = new MoneyDto(100001, CurrencyCode.AED)
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        var updateDto = new CountryUpdateDto
        {
            CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED),
            Name = expectedName

        };
        var headers = CreateEtagHeader(result!.Etag);
        var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, headers);

        //Assert
        putResult.Should().NotBeNull();
        putResult!.CountryDebt!.Amount.Should().Be(expectedAmount);
        putResult!.Name.Should().Be(expectedName);
    }

    [Fact]
    public async Task WhenPutCompoundTypeLatLong_ShouldSucceed()
    {
        // Arrange
        var expectedLat = 50;
        var expectedLong = 55;
        var expectedName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CapitalCityLocation = new LatLongDto() { Latitude = 45, Longitude = 45 },
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        var updateDto = new CountryUpdateDto
        {
            CapitalCityLocation = new LatLongDto() { Latitude = expectedLat, Longitude = expectedLong },
            //CapitalCityLocation2 = new MyLatLongDto() { Latitude = 3, Longitude = 5 },
            Name = expectedName

        };
        var headers = CreateEtagHeader(result!.Etag);
        var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, headers);

        //Assert
        putResult.Should().NotBeNull();
        putResult!.CapitalCityLocation!.Latitude.Should().Be(expectedLat);
        putResult!.CapitalCityLocation.Longitude.Should().Be(expectedLong);
        putResult!.Name.Should().Be(expectedName);
    }

    
    [Fact]
    public async Task WhenPatchCompoundTypeLatLong_ShouldSucceed()
    {
        // Arrange
        var expectedLat = 50;
        var expectedName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CapitalCityLocation = new LatLongDto() { Latitude = 45, Longitude = 45 },
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        //Act
        var updateDto = new CountryPartialUpdateDto
        {
            CapitalCityLocation = new LatLongDto() {Latitude = expectedLat},
            Name = expectedName

        };
        var headers = CreateEtagHeader(result!.Etag);
        var putResult = await PatchAsync<CountryPartialUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, headers);

        //Assert
        putResult.Should().NotBeNull();
        
        putResult!.CapitalCityLocation!.Latitude.Should().Be(expectedLat);
        putResult!.CapitalCityLocation.Longitude.Should().Be(result!.CapitalCityLocation!.Longitude);
        putResult!.Name.Should().Be(expectedName);
    }

    [Fact]
    public async Task WhenPatchCompoundTypeMoney_ShouldSucceed()
    {
        // Arrange
        var expectedAmount = 500000;
        var expectedCurrencyCode = CurrencyCode.EUR;
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryDebt = new MoneyDto { Amount = 100001, CurrencyCode = CurrencyCode.USD }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        //Act
        var dictionary = new Dictionary<string, object>
        {
            { nameof(CountryDto.CountryDebt), new Dictionary<string, object>
                {
                    { nameof(MoneyDto.Amount), expectedAmount },
                    { nameof(MoneyDto.CurrencyCode), expectedCurrencyCode.ToString() }
                }
            }
        };
        var headers = CreateEtagHeader(result!.Etag);
        await PatchAsync($"{Endpoints.CountriesUrl}/{result!.Id}", dictionary, headers);
        var putResult = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        putResult.Should().NotBeNull();

        putResult!.CountryDebt!.Amount.Should().Be(expectedAmount);
        putResult!.CountryDebt.CurrencyCode.Should().Be(expectedCurrencyCode);
    }
}
