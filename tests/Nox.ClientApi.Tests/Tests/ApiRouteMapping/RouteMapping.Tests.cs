﻿using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Xunit.Abstractions;
using Nox.Application.Dto;

namespace ClientApi.Tests.ApiRouteMapping;

[Collection("Sequential")]
public partial class RouteMappingTests : NoxWebApiTestBase
{
    public RouteMappingTests(ITestOutputHelper testOutputHelper,
    TestDatabaseContainerService containerService
    //For Development purposes
    //TestDatabaseInstanceService containerService
    )
    : base(testOutputHelper, containerService)
    {
        _fixture.Customize<string>(s => s.FromFactory(() => ToUpperFirstChar(Guid.NewGuid().ToString())));
    }

    [Fact]
    public async Task WhenRouteGetWithPathParameters_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByName/10"))!.ToList();
        //var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.CountriesUrl}"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]    
    public async Task WhenRouteGetWithQueryParameters_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByNameQuery?count=10"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRouteGetWithTargetUrlEncoded_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        //TODO uncomment in apiConfiguration.nox.yaml - $ref: ./apiRouteMappings/countries.encodedTargetUrl.ApiRouteMapping.nox.yaml
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesEncoded"))!.ToList();
        //var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.CountriesUrl}?$filter=ISO_Alpha3 eq ''"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }
    
    [Fact]
    public async Task WhenRouteGetWithDirectRoute_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        //TODO uncomment in apiConfiguration.nox.yaml - $ref: ./apiRouteMappings/countries.directRoute.ApiRouteMapping.nox.yaml  
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/Paises"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRouteGetIsCaseInsensitive_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/paIses"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRouteGetWithDefaults_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByName/"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRouteGetWithODataQuery_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);
        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByOdata/10?$select=Name"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRouteGetWithODataQuery3Segments_ShouldSucceed()
    {

        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByOdataSegments/10/MySpecial?$select=Name"))!.ToList();

        //Assert
        AssertTwoCountriesCase(countryName1, countryName2, result);
    }

    [Fact]
    public async Task WhenRoutePutWithParametersWithMultipleSegments_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

        // Act
        var headers = CreateEtagHeader(countryResponse!.Etag);
        await PutAsync(
            //$"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/$ref",            
            $"{Endpoints.RoutePrefix}/MySpecial/{countryResponse!.Id}/SecondSpecial/{Guid.NewGuid()}/ThirdSpecial/$ref",
            new ReferencesDto<long>
            {
                References = new List<long> { workplaceResponse!.Id }
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(1);
        getCountryResponse!.Workplaces!.First().Name.Should().Be(workplaceResponse!.Name);
    }
    
    private async Task CreateCountriesAsync(string countryName1, string countryName2)
    {
        await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = countryName1
            });
        await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = countryName2
            });
    }


    [Fact]
    public async Task WhenRouteGetWithTwoSequentialSegmentsParameters_ShouldSucceed()
    {
        // Arrange
        string countryName1 = _fixture.Create<string>();
        string countryName2 = _fixture.Create<string>();
        await CreateCountriesAsync(countryName1, countryName2);
        // Act
        var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/countriesSeqSegProps/Name/10");

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
   }
   private static string ToUpperFirstChar(string input)
   {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return char.ToUpper(input[0]) + input[1..];
   }
    
    private static void AssertTwoCountriesCase(string countryName1, string countryName2, List<CountryDto> result)
    {
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(r => r.Name == countryName1);
        result.Should().Contain(r => r.Name == countryName2);
    }
}
