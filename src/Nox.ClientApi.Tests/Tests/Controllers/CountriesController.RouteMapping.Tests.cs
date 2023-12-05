using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Xunit.Abstractions;
using Nox.Application.Dto;

namespace ClientApi.Tests.Controllers;

[Collection("CountriesControllerTests")]
public partial class CountriesControllerRouteMappingTests : NoxWebApiTestBase
{
    public CountriesControllerRouteMappingTests(ITestOutputHelper testOutputHelper,
    TestDatabaseContainerService containerService
    //For Development purposes
    //TestDatabaseInstanceService containerService
    )
    : base(testOutputHelper, containerService)
    {
    }

    [Fact]
    public async Task WhenRouteGetWithParameters_ShouldSucceed()
    {
        // Arrange
        string countryName1 = "Portugal";
        string countryName2 = "Spain";
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByName/10"))!.ToList();

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(r => r.Name == countryName1);
        result.Should().Contain(r => r.Name == countryName2);
    }

    [Fact(Skip ="Api Routing")]
    public async Task WhenRouteGetWithDefaults_ShouldSucceed()
    {
        // Arrange
        string countryName1 = "Portugal";
        string countryName2 = "Spain";
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByName/");

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(r => r.Name == countryName1);
        result.Should().Contain(r => r.Name == countryName2);
    }

    [Fact]
    public async Task WhenRouteGetWithODataQuery_ShouldSucceed()
    {
        // Arrange
        string countryName1 = "Portugal";
        string countryName2 = "Spain";
        await CreateCountriesAsync(countryName1, countryName2);
        // Act
        var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByOdata/10?$select=Name");

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(r => r.Name == countryName1);
        result.Should().Contain(r => r.Name == countryName2);
    }
    [Fact(Skip = "Api Routing")]
    public async Task WhenRouteGetWithODataQuery3Segments_ShouldSucceed()
    {

        // Arrange
        string countryName1 = "Portugal";
        string countryName2 = "Spain";
        await CreateCountriesAsync(countryName1, countryName2);

        // Act
        var result = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.RoutePrefix}/CountriesByOdataSegments/10/MySpecial?$select=Name");

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }



    [Fact(Skip = "Api Routing")]
    public async Task WhenRoutePutWithParametersWithMultipleSegments_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

        // Act
        var headers = CreateEtagHeader(countryResponse!.Etag);
        await PutAsync<ReferencesDto<Int64>>(
            //$"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/$ref",            
            $"{Endpoints.RoutePrefix}/MySpecial/{countryResponse!.Id}/SecondSpecial/{Guid.NewGuid()}/ThirdSpecial/$ref",
            new ReferencesDto<Int64>
            {
                References = new List<Int64> { workplaceResponse!.Id }
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
}

