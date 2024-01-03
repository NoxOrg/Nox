using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Xunit.Abstractions;
using System.Net;
using Nox.Application.Dto;

namespace ClientApi.Tests.ApiRouteMapping;
public partial class RelatedEndpointsRouteMappingTests : NoxWebApiTestBase
{
    public RelatedEndpointsRouteMappingTests(ITestOutputHelper testOutputHelper,
    TestDatabaseContainerService containerService)
    : base(testOutputHelper, containerService)
    { }

    #region PATCH    

    [Fact]
    public async Task WhenDifferentRequest_ShouldValidateByDepth()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}");

        //Act & Assert
        var headers = CreateEtagHeader(getWorkplaceResponse!.Etag);
        
        var patchResponseDepth4 = await PatchAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}",
            new WorkplacePartialUpdateDto { Name = expectedName },
            headers,
            throwOnError: false);
        patchResponseDepth4!.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);

        var patchResponseDepth4WithoutId = await PatchAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}" +
            $"/{nameof(CountryDto.Workplaces)}",
            new WorkplacePartialUpdateDto { Name = expectedName },
            headers,
            throwOnError: false);
        patchResponseDepth4WithoutId!.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WhenApiGenerateRelatedEndpointFalse_ShouldNotRedirect()
    {
        //Arrange
        var store = await CreateStore();
        var storeLicenseResponse = await PostAsync<StoreLicenseCreateDto, StoreLicenseDto>(Endpoints.StoreLicensesUrl, new StoreLicenseCreateDto
        {
            Issuer = _fixture.Create<string>(),
            StoreId = store!.Id,
        });
        var currencyResponse = await PostAsync<CurrencyCreateDto, CurrencyDto>(Endpoints.CurrenciesUrl, new CurrencyCreateDto
        {
            Id = "USD",
            Name = "US dollar"
        });
        var headers = CreateEtagHeader(currencyResponse!.Etag);

        //Act
        var patchResponse = await PatchAsync(
            $"{Endpoints.CurrenciesUrl}/{currencyResponse!.Id}/StoreLicenseDefault/{storeLicenseResponse!.Id}", 
            new StoreLicensePartialUpdateDto() { Issuer = _fixture.Create<string>() },
            headers,
            throwOnError: false
            );

        //Assert
        patchResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task WhenPatchSecondDepthRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();

        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl, 
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");
        await PostAsync($"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        //Act
        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var patchResponse = await PatchAsync<CountryPartialUpdateDto, CountryDto>(
            $"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/" +
            $"{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/" +
            $"{nameof(WorkplaceDto.Country)}",
            new CountryPartialUpdateDto
            {
                Name = expectedName
            },
            headers);

        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        //Assert
        patchResponse.Should().NotBeNull();

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Name.Should().Be(expectedName);
    }

    #endregion PATCH

    #region GET

    #region GET /api/v1/Tenants/1/Workplaces/1/Country
    [Fact]
    public async Task WhenGetSecondDepthRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");
        await PostAsync($"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        //Act
        var getResponse = await GetODataSimpleResponseAsync<CountryDto>(
            $"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}");

        //Assert
        getResponse.Should().NotBeNull();
        getResponse!.Name.Should().NotBeNullOrEmpty();
        getResponse!.Id.Should().Be(countryResponse!.Id);
    }
    #endregion

    #region GET /api/v1/Countries/1/Workplaces/1/Tenants/1
    [Fact]
    public async Task WhenGetByIdSecondDepthRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");
        await PostAsync($"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        //Act
        var getResponse = await GetODataSimpleResponseAsync<TenantDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Tenants)}/{tenantResponse!.Id}");

        //Assert
        getResponse.Should().NotBeNull();
        getResponse!.Name.Should().NotBeNullOrEmpty();
        getResponse!.Id.Should().Be(tenantResponse!.Id);
    }
    #endregion

    #region GET /api/v1/Countries/1/Workplaces/1/Tenants
    [Fact]
    public async Task WhenGetAllSecondDepthRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");
        await PostAsync($"{Endpoints.TenantsUrl}/{tenantResponse!.Id}/{nameof(TenantDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        //Act
        var getResponse = await GetODataCollectionResponseAsync<IEnumerable<TenantDto>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Tenants)}");

        //Assert
        getResponse.Should().NotBeNull();
        getResponse!.Should().HaveCount(1);
        getResponse!.First().Name.Should().NotBeNullOrEmpty();
        getResponse!.First().Id.Should().Be(tenantResponse!.Id);
    }
    #endregion

    #endregion GET

    #region REF

    #region POST /api/v1/Countries/1/Workplaces/1/Tenants/1
    [Fact]
    public async Task WhenPostRefToRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        //Act
        await PostAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/" +
            $"{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/" +
            $"{nameof(WorkplaceDto.Tenants)}/{tenantResponse!.Id}/$ref");

        const string oDataRequest = $"$expand={nameof(WorkplaceDto.Tenants)}";
        var getResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");        

        //Assert
        getResponse.Should().NotBeNull();
        getResponse!.Tenants.Should().NotBeNull();
        getResponse!.Tenants.Should().HaveCount(1);
        getResponse!.Tenants.First().Id.Should().Be(tenantResponse!.Id);
    }
    #endregion

    #region PUT /api/v1/Countries/1/Workplaces/1/Tenants
    [Fact]
    public async Task WhenPostRefsToRelatedEntity_ShouldSucceed()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var tenantResponse1 = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });
        var tenantResponse2 = await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
            new TenantCreateDto { Name = _fixture.Create<string>() });

        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/$ref");

        //Act
        await PutAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/" +
            $"{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}/" +
            $"{nameof(WorkplaceDto.Tenants)}/$ref",
            new ReferencesDto<UInt32>
            {
                References = new List<UInt32> { tenantResponse1!.Id, tenantResponse2!.Id }
            });

        const string oDataRequest = $"$expand={nameof(WorkplaceDto.Tenants)}";
        var getResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

        //Assert
        getResponse.Should().NotBeNull();
        getResponse!.Tenants.Should().NotBeNull();
        getResponse!.Tenants.Should().HaveCount(2);
        getResponse!.Tenants.Should().Contain(t => t.Id == tenantResponse1!.Id);
        getResponse!.Tenants.Should().Contain(t => t.Id == tenantResponse2!.Id);
    }
    #endregion

    #endregion REF


    private async Task<StoreDto?> CreateStore()
    {
        var createDto = new StoreCreateDto
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
            Location = new LatLongDto(51.3728033, -0.5389749),
        };

        return await PostAsync<StoreCreateDto, StoreDto>(Endpoints.StoresUrl, createDto)!;
    }
}

