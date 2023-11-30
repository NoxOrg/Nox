using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using Nox.Application.Dto;

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
    [Fact(Skip= "Compound types in Delta changed properties will also be a Delta type, this needs used in the controller / factory")]
    //[Fact]
    public async Task WhenPatchCompoundTypeLatLong_ShouldSucceed()
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

        var updateDto = new CountryPartialUpdateDto
        {
            CapitalCityLocation = new LatLongDto() {Latitude = expectedLat , Longitude = expectedLong},
            Name = expectedName

        };
        var headers = CreateEtagHeader(result!.Etag);
        var putResult = await PatchAsync<CountryPartialUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, headers);

        //Assert
        putResult.Should().NotBeNull();
        
        putResult!.CapitalCityLocation!.Latitude.Should().Be(expectedLat);
        putResult!.CapitalCityLocation.Longitude.Should().Be(expectedLong);
        putResult!.Name.Should().Be(expectedName);
    }
}
