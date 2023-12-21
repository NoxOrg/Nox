using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Xunit.Abstractions;

namespace ClientApi.Tests.ApiRouteMapping;
public partial class RelatedEndpointsRouteMappingTests : NoxWebApiTestBase
{
    public RelatedEndpointsRouteMappingTests(ITestOutputHelper testOutputHelper,
    TestDatabaseContainerService containerService)
    : base(testOutputHelper, containerService)
    { }

    [Fact]
    public async Task WhenPatchRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, 
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}");

        //Act
        var headers = CreateEtagHeader(getWorkplaceResponse!.Etag);
        var patchResponse = await PatchAsync<WorkplacePartialUpdateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}",
            new WorkplacePartialUpdateDto
            {
                Name = expectedName
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        patchResponse.Should().NotBeNull();

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Workplaces.Should().HaveCount(1);
        getCountryResponse!.Workplaces.First().Name.Should().Be(expectedName);
    }

}

