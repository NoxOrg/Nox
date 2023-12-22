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

    [Fact]
    public async Task WhenPatchZeroToOneRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var ownerExpectedName = _fixture.Create<string>();
        var storeResponse = await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, new StoreCreateDto
        {
            Name = _fixture.Create<string>(),
            Address = new StreetAddressDto(
                 null!,
                 "3000 Hillswood Business Park",
                 null!,
                 null!,
                 null!,
                 null!,
                 null!,
                 null!,
                 "KT16 0RS",
                 Nox.Types.CountryCode.GB),
            Location = new LatLongDto(51.3728033, -0.5389749)
        });
        var ownerResponse = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(Endpoints.StoreOwnersUrl, new StoreOwnerCreateDto
        {
            Id = "002",
            Name = _fixture.Create<string>(),
            TemporaryOwnerName = _fixture.Create<string>()
        });
        await PostAsync($"{Endpoints.StoresUrl}/{storeResponse!.Id}/{nameof(StoreDto.StoreOwner)}/{ownerResponse!.Id}/$ref");
        var getOwnedResponse = await GetODataSimpleResponseAsync<StoreOwnerDto>($"{Endpoints.StoreOwnersUrl}/{ownerResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(getOwnedResponse!.Etag);
        var patchResponse = await PatchAsync<StoreOwnerPartialUpdateDto, StoreOwnerDto>(
            $"{Endpoints.StoresUrl}/{storeResponse!.Id}/{nameof(StoreDto.StoreOwner)}/{ownerResponse!.Id}",
            new StoreOwnerPartialUpdateDto
            {
                Name = ownerExpectedName
            },
            headers);


        const string oDataRequest = $"$expand={nameof(StoreDto.StoreOwner)}";
        var getStoreResponse = await GetODataSimpleResponseAsync<StoreDto>($"{Endpoints.StoresUrl}/{storeResponse!.Id}?{oDataRequest}");


        //Assert
        patchResponse.Should().NotBeNull();

        getStoreResponse.Should().NotBeNull();
        getStoreResponse!.StoreOwner.Should().NotBeNull();
        getStoreResponse!.StoreOwner!.Name.Should().Be(ownerExpectedName);
    }
}

