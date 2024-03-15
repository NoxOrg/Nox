using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using Nox.Application.Dto;
using Guid = System.Guid;

namespace ClientApi.Tests.Tests.Controllers;

[Collection("CountriesControllerTests")]
public partial class CountriesControllerTests : NoxWebApiTestBase
{
    public CountriesControllerTests(ITestOutputHelper testOutputHelper,
        TestDatabaseContainerService containerService
        //For Development purposes
        //TestDatabaseInstanceService containerService
        )
        : base(testOutputHelper, containerService)
    {
    }

    #region OWNED RELATIONSHIPS EXAMPLES

    #region GET

    #region GET Entity By Key With Query /api/{EntityPluralName}/{EntityKey}?Query => api/countries/1?$select=Name

    [Fact]
    public async Task GetById_WhenSelect_ReturnsOnlySelectedFields()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Population = 1_000_000,
            CountryDebt = new MoneyDto(200_000, CurrencyCode.USD)
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        const string oDataRequest = "$select=Name";
        var response = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}?{oDataRequest}");

        //Assert
        response.Should().NotBeNull();
        response!.Name.Should().NotBeNullOrEmpty();
        response.Population.Should().BeNull();
        response.CountryDebt.Should().BeNull();
    }

    #endregion GET Entity By Key With Query /api/{EntityPluralName}/{EntityKey}?Query => api/countries/1?$select=Name

    #region GET Single Owned Entity (filter by query) via Parent Entity /api/{EntityPluralName}/{EntityKey}?Query => api/countries/1?$select=CountryLocalNames&$expand=CountryLocalNames($filter=Name eq 'Lusitania')

    [Fact]
    public async Task Get_OwnedEntityByParentEntity_ReturnsOnlySelectedOwnedEntityFields()
    {
        var expectedLocalName = "Lusitania";
        var expectedBarCodeName = "Lusitania";
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            Population = 1_000_000,
            CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new CountryLocalNameUpsertDto() { Name = "Iberia" },
                new CountryLocalNameUpsertDto() { Name = expectedLocalName}
            },
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = expectedBarCodeName }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        const string oDataRequest = $"$select={nameof(dto.CountryLocalNames)}&$expand={nameof(dto.CountryLocalNames)}($filter=Name eq 'Lusitania')";
        var response = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}?{oDataRequest}");

        //Assert
        response.Should().NotBeNull();
        response!.Name.Should().BeNull();
        response.Population.Should().BeNull();
        response.CountryDebt.Should().BeNull();

        response.CountryLocalNames.Should().HaveCount(1);
        response.CountryLocalNames[0].Name.Should().Be(expectedLocalName);
        response.CountryBarCode.Should().NotBeNull();
        response.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
    }

    #endregion GET Single Owned Entity (filter by query) via Parent Entity /api/{EntityPluralName}/{EntityKey}?Query => api/countries/1?$select=CountryLocalNames&$expand=CountryLocalNames($filter=Name eq 'Lusitania')

    #region GET Owned Entities via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    [Fact]
    public async Task Get_OwnedEntitiesByParentKey_ReturnsOwnedEntitiesList()
    {
        var expectedCountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new CountryLocalNameUpsertDto() { Name = "Iberia" },
                new CountryLocalNameUpsertDto() { Name = "Lusitania"}
            };
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryLocalNames = expectedCountryLocalNames
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryLocalNames)}");

        // Assert
        results.Should()
            .HaveCount(expectedCountryLocalNames.Count)
                .And
            .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty())
                .And
            .AllSatisfy(x => x.Id.Should().BeGreaterThan(0));
    }

    #endregion GET Owned Entities via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    #region GET Single Owned Entity (filter by query) via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}?{Query} => api/countries/1/CountryLocalNames?$filter=Name eq 'Lusitania'

    [Fact]
    public async Task Get_OwnedEntityByParentKeyAndFilter_ReturnsSingleEntity()
    {
        var expectedName = "Lusitania";
        var expectedCountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new CountryLocalNameUpsertDto() { Name = "Iberia" },
                new CountryLocalNameUpsertDto() { Name = expectedName}
            };
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryLocalNames = expectedCountryLocalNames
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryLocalNames)}?$filter=Name eq '{expectedName}'");

        // Assert
        results.Should()
            .HaveCount(1)
                .And
            .AllSatisfy(x => x.Name.Should().Be(expectedName))
                .And
            .AllSatisfy(x => x.Id.Should().BeGreaterThan(0));
    }

    #endregion GET Single Owned Entity (filter by query) via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}?{Query} => api/countries/1/CountryLocalNames?$filter=Name eq 'Lusitania'

    #region GET Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1

    [Fact]
    public async Task Get_OwnedEntityByParentKey_ReturnsOwnedEntity()
    {
        var expectedCountryLocalName = _fixture.Create<string>();
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new CountryLocalNameUpsertDto() { Name = expectedCountryLocalName }
            }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Act
        var countryLocalName = await GetODataSimpleResponseAsync<CountryLocalNameDto>(
            $"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(dto.CountryLocalNames)}/{country!.CountryLocalNames[0].Id}");

        // Assert
        countryLocalName.Should().NotBeNull();
        countryLocalName!.Id.Should().Be(country!.CountryLocalNames[0].Id);
        countryLocalName!.Name.Should().Be(expectedCountryLocalName);
    }

    #endregion GET Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1

    #region GET [ZeroOrOne] Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    [Fact]
    public async Task Get_CountryBarCodeByParentKey_ReturnsCountryBarCode()
    {
        var expectedBarCodeName = _fixture.Create<string>();
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = expectedBarCodeName }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        var countryBarCode = await GetODataSimpleResponseAsync<CountryBarCodeDto>(
            $"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode");

        // Assert
        countryBarCode.Should().NotBeNull();
        countryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
    }

    #endregion GET [ZeroOrOne] Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    #endregion GET

    #region POST

    #region POST Entity With Owned Entities /api/{EntityPluralName} => api/countries

    [Fact]
    public async Task Post_WithManyOwnedEntity_ReturnsAutoNumberId()
    {
        // Arrange
        var expectedCountryLocalName = _fixture.Create<string>();
        var expectedBarCodeName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() { new CountryLocalNameUpsertDto() { Name = expectedCountryLocalName } },
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = expectedBarCodeName }
        };
        // Act
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        result.Should().NotBeNull();
        result!.Id.Should().BeGreaterThanOrEqualTo(10);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.CountryLocalNames!.Single().Name.Should().Be(expectedCountryLocalName);
        getCountryResponse!.CountryBarCode.Should().NotBeNull();
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
    }
#if RELEASE //Due to postgresql cascade delete not working as expected
    [Fact]
    public async Task DeleteAllCountryLocalNamesForCountryCommand_ShouldDeleteAllCountryLocalNames()
    {
        // Arrange
        var expectedCountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new() { Name = "Iberia" },
                new() { Name = "Lusitania"}
            };
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryLocalNames = expectedCountryLocalNames
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(result!.Etag);

        // Act
        await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryLocalNames)}", headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task WhenInvalidEtagProvided_DeleteAllCountryLocalNamesForCountryCommand_ShouldReturnConflict()
    {
        // Arrange
        var expectedCountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new() { Name = "Iberia" },
                new() { Name = "Lusitania"}
            };
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryLocalNames = expectedCountryLocalNames
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(Guid.NewGuid());

        // Act
        var response = await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryLocalNames)}", headers, throwOnError:false);

        // Assert
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }
#endif    
    [Fact]
    public async Task DeleteAllCountryBarCodeForCountryCommand_ShouldDeleteCountryBarCode()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = "Lusitania" }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(result!.Etag);

        // Act
        await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode", headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryBarCode.Should().BeNull();
    }
    
    [Fact]
    public async Task WhenInvalidEtagProvided_DeleteAllCountryBarCodeForCountryCommand_ShouldReturnConflict()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = "Portugal",
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = "Lusitania" }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(Guid.NewGuid());

        // Act
        var response = await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode", headers, throwOnError:false);

        // Assert
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task Post_CountryLocalNamesWithId_ShouldFail()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            {
                new CountryLocalNameUpsertDto()
                {
                    Id = 1,
                    Name = _fixture.Create<string>()
                },
                new CountryLocalNameUpsertDto() { Name = _fixture.Create<string>() },
                new CountryLocalNameUpsertDto() { Name = _fixture.Create<string>() }
            }
        };
        // Act
        var result = await PostAsync(Endpoints.CountriesUrl, dto);

        //Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Post_CountryTimeZoneWithoutId_ShouldFail()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryTimeZones = new List<CountryTimeZoneUpsertDto>()
            {
                new CountryTimeZoneUpsertDto() { Name = _fixture.Create<string>() }
            }
        };
        // Act
        var result = await PostAsync(Endpoints.CountriesUrl, dto);

        //Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Post_WithHolidays_Success()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Holidays = new List<HolidayUpsertDto>()
            {
                new HolidayUpsertDto() { Name = _fixture.Create<string>() },
                new HolidayUpsertDto()
                {
                    Id = _fixture.Create<System.Guid>(),
                    Name = _fixture.Create<string>()
                }
            }
        };
        // Act
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        result.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Holidays.Should().NotBeNull();
        getCountryResponse!.Holidays!.Should().HaveCount(2);
        getCountryResponse!.Holidays!.Should().Contain(x => x.Id == dto.Holidays.Last().Id);
    }

    #endregion POST Entity With Owned Entities /api/{EntityPluralName} => api/countries

    #region POST to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    [Fact]
    public async Task PostToCountryLocalNames_ShouldAddToCountryLocalNames()
    {
        // Arrange
        var expectedLocalName = "local UA";

        var createDto = new CountryCreateDto
        {
            Name = "Ukraine",
            Population = 44000000
        };

        var localNameDto = new CountryLocalNameUpsertDto
        {
            Name = expectedLocalName
        };

        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PostAsync<CountryLocalNameUpsertDto, CountryLocalNameDto>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(createDto.CountryLocalNames)}", localNameDto, headers);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.Id.Should().BeGreaterThan(0);
        ownedResult!.Name.Should().Be(expectedLocalName);
    }

    [Fact]
    public async Task PostToCountryLocalNames_WithId_ShouldFail()
    {
        // Arrange
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 44000000
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PostAsync($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.CountryLocalNames)}",
            new CountryLocalNameUpsertDto
            {
                Id = 1,
                Name = _fixture.Create<string>()
            },
            headers);

        //Assert
        ownedResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    #endregion POST to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    #region POST to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    [Fact]
    public async Task PostToCountryBarCode_ShouldSetCountryBarCode()
    {
        // Arrange
        var expectedBarCodeName = _fixture.Create<string>();

        var createDto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Population = 44000000
        };

        var barCodeDto = new CountryBarCodeUpsertDto
        {
            BarCodeName = expectedBarCodeName
        };

        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PostAsync<CountryBarCodeUpsertDto, CountryBarCodeDto>($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode", barCodeDto, headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.BarCodeName.Should().Be(expectedBarCodeName);
        getCountryResponse!.CountryBarCode.Should().NotBeNull();
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
    }

    #endregion POST to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    #region POST to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryTimeZones

    [Fact]
    public async Task PostToCountryTimeZones_WithId_ShouldAddToCountryTimeZone()
    {
        // Arrange
        var expectedId = "EST";
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>()
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PostAsync<CountryTimeZoneUpsertDto, CountryTimeZoneDto>(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.CountryTimeZones)}",
            new CountryTimeZoneUpsertDto
            {
                Id = expectedId,
                Name = _fixture.Create<string>()
            },
            headers);

        var getWorkplacesResponse = await GetODataSimpleResponseAsync<CountryDto>(
            $"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.CountryTimeZones.Should().NotBeNull();
        getWorkplacesResponse!.CountryTimeZones!.Should().HaveCount(1);
        getWorkplacesResponse!.CountryTimeZones!.First().Id.Should().Be(expectedId);
    }

    [Fact]
    public async Task PostToCountryTimeZones_WithoutId_ShouldFail()
    {
        // Arrange
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>()
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PostAsync(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.CountryTimeZones)}",
            new CountryTimeZoneUpsertDto
            {
                Name = _fixture.Create<string>()
            },
            headers);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    #endregion

    #region POST to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/Holidays

    [Fact]
    public async Task PostToHolidays_WithAndWithoutId_Success()
    {
        // Arrange
        var expectedId = _fixture.Create<System.Guid>();
        var country = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>()
            });
        var headers = CreateEtagHeader(country!.Etag);

        //Act
        var ownedResponse = await PostAsync<HolidayUpsertDto, HolidayDto>(
            $"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(CountryDto.Holidays)}",
            new HolidayUpsertDto
            {
                Id = expectedId,
                Name = _fixture.Create<string>()
            },
            headers);
        headers = CreateEtagHeader((await GetODataSimpleResponseAsync<CountryDto>(
            $"{Endpoints.CountriesUrl}/{country!.Id}"))!.Etag);
        await PostAsync<HolidayUpsertDto, HolidayDto>(
            $"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(CountryDto.Holidays)}",
            new HolidayUpsertDto { Name = _fixture.Create<string>() },
            headers);

        var getWorkplacesResponse = await GetODataSimpleResponseAsync<CountryDto>(
            $"{Endpoints.CountriesUrl}/{country!.Id}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.Holidays.Should().NotBeNull();
        getWorkplacesResponse!.Holidays!.Should().HaveCount(2);
        getWorkplacesResponse!.Holidays!.Should().Contain(h => h.Id == expectedId);
    }

    #endregion

    #endregion POST

    #region PUT

    #region PUT to Owned Entities /api/{EntityPluralName}/{key}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    [Fact]
    public async Task PutToCountryLocalNames_ShouldUpdateCountryLocalName()
    {
        // Arrange
        var expectedOwnedName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() { new CountryLocalNameUpsertDto() { Name = _fixture.Create<string>() } }
        };
        // Act
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");
        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var ownedResult = await PutManyAsync<CountryLocalNameUpsertDto, CountryLocalNameDto>(
            $"{Endpoints.CountriesUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryLocalNames)}",
            new[]
            {
                new CountryLocalNameUpsertDto
                {
                    Id = getCountryResponse!.CountryLocalNames[0].Id,
                    Name = expectedOwnedName
                }
            },
            headers);

        //Assert
        ownedResult.Should().NotBeNullOrEmpty();
        ownedResult![0].Id.Should().Be(getCountryResponse!.CountryLocalNames[0].Id);
        ownedResult![0].Name.Should().Be(expectedOwnedName);
    }

    [Fact]
    public async Task PutToCountryLocalNames_WithoutId_ShouldCreate()
    {
        // Arrange
        var expectedCountryLocalName1 = _fixture.Create<string>();
        var expectedCountryLocalName2 = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() { new CountryLocalNameUpsertDto() { Name = expectedCountryLocalName1 } }
        };
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var ownedResult = await PutManyAsync<CountryLocalNameUpsertDto, CountryLocalNameDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/{nameof(dto.CountryLocalNames)}",
            new[]
            {
                new CountryLocalNameUpsertDto
                {
                    Name = expectedCountryLocalName2
                },
            },
            headers,
            throwOnError: false);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        ownedResult.Should().NotBeNullOrEmpty();
        getCountryResponse!.CountryLocalNames.Should().HaveCount(2);
        getCountryResponse!.CountryLocalNames.Should().Contain(x => x.Name == expectedCountryLocalName1);
        getCountryResponse!.CountryLocalNames.Should().Contain(x => x.Name == expectedCountryLocalName2);
    }

    [Fact]
    public async Task PutToCountryLocalNames_WithInvalidId_ShouldFail()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() { new CountryLocalNameUpsertDto() { Name = _fixture.Create<string>() } }
        };
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var ownedResult = await PutManyAsync(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/{nameof(dto.CountryLocalNames)}",
            new[]
            {
                new CountryLocalNameUpsertDto
                {
                    Id = 1000,
                    Name = _fixture.Create<string>()
                }
            },
            headers,
            throwOnError: false);

        //Assert
        ownedResult!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion PUT to Owned Entities /api/{EntityPluralName}/{key}/{OwnedEntityPluralName}/{relatedKey} => api/countries/1/CountryLocalNames/1

    #region PUT to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{key}/{OwnedEntityName} => api/countries/1/CountryBarCode

    [Fact]
    public async Task Put_ToCountryBarCode_ShouldUpdateCountryBarCode()
    {
        // Arrange
        var expectedBarCode = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = _fixture.Create<string>() }
        };
        // Act
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putToCountryBarCodeResponse = await PutAsync<CountryBarCodeUpsertDto, CountryBarCodeDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/CountryBarCode",
            new CountryBarCodeUpsertDto
            {
                BarCodeName = expectedBarCode
            }, headers);

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putToCountryBarCodeResponse.Should().NotBeNull();
        putToCountryBarCodeResponse!.BarCodeName.Should().Be(expectedBarCode);

        getCountryResponse!.Id.Should().Be(postCountryResponse!.Id);
        getCountryResponse!.Name.Should().Be(postCountryResponse!.Name);
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCode);
    }

    [Fact]
    public async Task Put_ToCountryBarCode_ShouldCreateIfItWasEmpty()
    {
        // Arrange
        var expectedBarCode = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>()
        };
        // Act
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putToCountryBarCodeResponse = await PutAsync<CountryBarCodeUpsertDto, CountryBarCodeDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/CountryBarCode",
            new CountryBarCodeUpsertDto
            {
                BarCodeName = expectedBarCode
            }, headers);

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putToCountryBarCodeResponse.Should().NotBeNull();
        putToCountryBarCodeResponse!.BarCodeName.Should().Be(expectedBarCode);

        getCountryResponse!.Id.Should().Be(postCountryResponse!.Id);
        getCountryResponse!.Name.Should().Be(postCountryResponse!.Name);
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCode);
    }

    #endregion PUT to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{key}/{OwnedEntityName} => api/countries/1/CountryBarCode

    #region PUT to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryTimeZones

    [Fact]
    public async Task PutToCountryTimeZones_WithExistingId_ShouldUpdate()
    {
        // Arrange
        var timeZone = "EST";
        var expectedName = _fixture.Create<string>();
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                CountryTimeZones = new List<CountryTimeZoneUpsertDto> {
                    new CountryTimeZoneUpsertDto { Id = timeZone, Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(postCountryResponse!.Etag);

        //Act
        var ownedResult = await PutManyAsync(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/{nameof(CountryDto.CountryTimeZones)}",
            new[]
            {
                new CountryTimeZoneUpsertDto
                {
                    Id = timeZone,
                    Name = expectedName
                },
            },
            headers,
            throwOnError: false);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        ownedResult.Should().NotBeNull();
        getCountryResponse!.CountryTimeZones.Should().HaveCount(1);
        getCountryResponse!.CountryTimeZones.First().Name.Should().Be(expectedName);
    }

    [Fact]
    public async Task PutToCountryTimeZones_WithNotExistingId_ShouldCreate()
    {
        // Arrange
        var timeZone1 = "GMT";
        var timeZone2 = "UTC";
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                CountryTimeZones = new List<CountryTimeZoneUpsertDto> {
                    new CountryTimeZoneUpsertDto { Id = timeZone1, Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(postCountryResponse!.Etag);

        //Act
        var ownedResult = await PutManyAsync(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/{nameof(CountryDto.CountryTimeZones)}",
            new[]
            {
                new CountryTimeZoneUpsertDto
                {
                    Id = timeZone2,
                    Name = _fixture.Create<string>()
                },
            },
            headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        ownedResult.Should().NotBeNull();
        getCountryResponse!.CountryTimeZones.Should().HaveCount(2);
        getCountryResponse!.CountryTimeZones.Should().Contain(x => x.Id == timeZone1);
        getCountryResponse!.CountryTimeZones.Should().Contain(x => x.Id == timeZone2);
    }

    [Fact]
    public async Task PutToCountryTimeZones_WithoutId_ShouldFail()
    {
        // Arrange
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>()
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PutAsync(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.CountryTimeZones)}",
            new[]
            {
                new CountryTimeZoneUpsertDto
                {
                    Name = _fixture.Create<string>()
                },
            },
            headers,
            throwOnError: false);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    #endregion

    #region PUT to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/Holidays

    [Fact]
    public async Task PutToHolidays_WithoutId_ShouldCreate()
    {
        // Arrange
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                Holidays = new List<HolidayUpsertDto> { new HolidayUpsertDto { Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PutManyAsync<HolidayUpsertDto, HolidayDto>(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.Holidays)}",
            new[]
            {
                new HolidayUpsertDto
                {
                    Name = _fixture.Create<string>()
                },
            },
            headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>(
           $"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        ownedResult.Should().NotBeNullOrEmpty();
        getCountryResponse!.Holidays.Should().HaveCount(2);
    }

    [Fact]
    public async Task PutToHolidays_WithExistingId_ShouldSucced()
    {
        // Arrange
        var holidayId = _fixture.Create<System.Guid>();
        var expectedName = _fixture.Create<string>();
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                Holidays = new List<HolidayUpsertDto> { new HolidayUpsertDto { Id = holidayId, Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PutManyAsync(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.Holidays)}",
            new[]
            {
                new HolidayUpsertDto
                {
                    Id = holidayId,
                    Name = expectedName
                },
            },
            headers);

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>(
           $"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Holidays.Should().NotBeNull();
        getCountryResponse!.Holidays!.Should().HaveCount(1);
        getCountryResponse!.Holidays!.First().Id.Should().Be(holidayId);
        getCountryResponse!.Holidays!.First().Name.Should().Be(expectedName);
    }

    #endregion

    #region PUT Entity with Owned Entities /api/{EntityPluralName}/{key} => api/countries/1
    [Fact]
    public async Task Put_WithCountryBarCode_Success()
    {
        // Arrange
        var expectedBarCodeName = _fixture.Create<string>();
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = _fixture.Create<string>() }
            });

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = expectedBarCodeName }
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.CountryBarCode.Should().NotBeNull();
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
    }

    [Fact]
    public async Task Put_EmptyCountryBarCode_Success()
    {
        // Arrange
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryBarCode = new CountryBarCodeUpsertDto() { BarCodeName = _fixture.Create<string>() }
            });

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryBarCode = null
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryBarCode.Should().BeNull();
    }

    [Fact]
    public async Task Put_WithCountryLocalNames_FromEmptyToList_Success()
    {
        // Arrange
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>()
            });

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() }
                }
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames!.Should().HaveCount(3);
    }

    [Fact]
    public async Task Put_WithCountryLocalNames_FromListToEmpty_Success()
    {
        // Arrange
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                    new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                    new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                    new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() }
                }
            });

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames!.Should().HaveCount(0);
    }

    [Fact]
    public async Task Put_WithCountryLocalNames_FromListToList_Success()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() }
                }
            });
        var initialGetCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                        new CountryLocalNameUpsertDto { Id = initialGetCountryResponse!.CountryLocalNames.ElementAt(0).Id, Name = expectedName },
                        new CountryLocalNameUpsertDto { Id = initialGetCountryResponse!.CountryLocalNames.ElementAt(1).Id, Name = expectedName },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() }
                }
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames!.Should().HaveCount(4);
        getCountryResponse!.CountryLocalNames!.Should().Contain(x => x.Id == initialGetCountryResponse!.CountryLocalNames.ElementAt(0).Id);
        getCountryResponse!.CountryLocalNames!.Should().Contain(x => x.Id == initialGetCountryResponse!.CountryLocalNames.ElementAt(1).Id);
        getCountryResponse!.CountryLocalNames!.First(x => x.Id == initialGetCountryResponse!.CountryLocalNames.ElementAt(0).Id)!.Name.Should().Be(expectedName);
        getCountryResponse!.CountryLocalNames!.First(x => x.Id == initialGetCountryResponse!.CountryLocalNames.ElementAt(1).Id)!.Name.Should().Be(expectedName);
        getCountryResponse!.CountryLocalNames!.Should().NotContain(x => x.Id == initialGetCountryResponse!.CountryLocalNames.ElementAt(2).Id);
    }

    [Fact]
    public async Task Put_WithCountryLocalNames_InvalidId_Fails()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                        new CountryLocalNameUpsertDto { Name = expectedName },
                        new CountryLocalNameUpsertDto { Name = expectedName }
                }
            });
        var initialGetCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                CountryLocalNames = new List<CountryLocalNameUpsertDto>
                {
                        new CountryLocalNameUpsertDto { Id = initialGetCountryResponse!.CountryLocalNames.ElementAt(0).Id, Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Id = initialGetCountryResponse!.CountryLocalNames.ElementAt(0).Id + 100, Name = _fixture.Create<string>() },
                        new CountryLocalNameUpsertDto { Name = _fixture.Create<string>() }
                }
            },
            headers,
            throwOnError: false
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        putCountryResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames.Should().NotBeNull();
        getCountryResponse!.CountryLocalNames!.Should().HaveCount(2);
        getCountryResponse!.CountryLocalNames!.Should().AllSatisfy(x => x.Name.Should().Be(expectedName));
    }

    [Fact]
    public async Task Put_WithHolidays_FromListToList_Success()
    {
        // Arrange
        var expectedName = _fixture.Create<string>();
        var expectedId = _fixture.Create<System.Guid>();
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Holidays = new List<HolidayUpsertDto>
                {
                        new HolidayUpsertDto { Name = _fixture.Create<string>() },
                        new HolidayUpsertDto { Name = _fixture.Create<string>() },
                        new HolidayUpsertDto { Name = _fixture.Create<string>() }
                }
            });
        var initialGetCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var putCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = postCountryResponse!.Name,
                Holidays = new List<HolidayUpsertDto>
                {
                        new HolidayUpsertDto { Id = initialGetCountryResponse!.Holidays.ElementAt(0).Id, Name = expectedName },
                        new HolidayUpsertDto { Id = expectedId, Name = _fixture.Create<string>() },
                        new HolidayUpsertDto { Name = _fixture.Create<string>() },
                }
            },
            headers
        );

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        putCountryResponse.Should().NotBeNull();
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Holidays.Should().NotBeNull();
        getCountryResponse!.Holidays!.Should().HaveCount(3);
        getCountryResponse!.Holidays!.Should().Contain(x => x.Id == initialGetCountryResponse!.Holidays.ElementAt(0).Id);
        getCountryResponse!.Holidays!.Should().Contain(x => x.Id == expectedId);
        getCountryResponse!.Holidays!.First(x => x.Id == initialGetCountryResponse!.Holidays.ElementAt(0).Id)!.Name.Should().Be(expectedName);
        getCountryResponse!.Holidays!.Should().NotContain(x => x.Id == initialGetCountryResponse!.Holidays.ElementAt(1).Id);
        getCountryResponse!.Holidays!.Should().NotContain(x => x.Id == initialGetCountryResponse!.Holidays.ElementAt(2).Id);
    }
    #endregion

    #endregion PUT

    #region PATCH

    #region PATCH to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    [Fact]
    public async Task PatchToCountryLocalNames_ShouldUpdateCountryLocalName()
    {
        // Arrange
        var expectedOwnedName = _fixture.Create<string>();
        var expectedOwnedNativeName = _fixture.Create<string>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            {
                new CountryLocalNameUpsertDto()
                {
                    Name = _fixture.Create<string>(),
                    NativeName = expectedOwnedNativeName
                }
            }
        };
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        var dictionary = new Dictionary<string, object>
        {
            { "Id", getCountryResponse!.CountryLocalNames[0].Id },
            { "Name", expectedOwnedName }
        };

        // Act
        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var ownedResult = await PatchAsync<Dictionary<string, object>, CountryLocalNameDto>(
            $"{Endpoints.CountriesUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryLocalNames)}",
            dictionary,
            headers);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.Id.Should().Be(getCountryResponse!.CountryLocalNames[0].Id);
        ownedResult!.Name.Should().Be(expectedOwnedName);
        ownedResult!.NativeName.Should().Be(expectedOwnedNativeName);
    }

    [Fact]
    public async Task PatchToCountryLocalNames_WithoutId_ShouldFail()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            {
                new CountryLocalNameUpsertDto()
                {
                    Name = _fixture.Create<string>(),
                    NativeName = _fixture.Create<string>()
                }
            }
        };
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var dictionary = new Dictionary<string, object>
        {
            { "Name", _fixture.Create<string>() }
        };

        // Act
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var ownedResult = await PatchAsync(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/{nameof(dto.CountryLocalNames)}",
            dictionary,
            headers,
            throwOnError: false);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    #endregion PATCH to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

    #region PATCH to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    [Fact]
    public async Task PatchToCountryBarCode_ShouldUpdateCountryBarCode()
    {
        // Arrange
        var expectedBarCodeName = _fixture.Create<string>();
        var expectedBarCodeNumber = _fixture.Create<int>();
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryBarCode = new CountryBarCodeUpsertDto
            {
                BarCodeName = _fixture.Create<string>(),
                BarCodeNumber = expectedBarCodeNumber
            }
        };
        var dictionary = new Dictionary<string, object>();
        dictionary.Add("BarCodeName", expectedBarCodeName);

        // Act
        var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(postCountryResponse!.Etag);
        var ownedResult = await PatchAsync<Dictionary<string, object>, CountryBarCodeDto>(
            $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/CountryBarCode",
            dictionary,
            headers);
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.BarCodeName.Should().Be(expectedBarCodeName);
        ownedResult!.BarCodeNumber.Should().Be(expectedBarCodeNumber);

        getCountryResponse!.Id.Should().Be(postCountryResponse!.Id);
        getCountryResponse!.Name.Should().Be(postCountryResponse!.Name);
        getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
        getCountryResponse!.CountryBarCode!.BarCodeNumber.Should().Be(expectedBarCodeNumber);
    }

    #endregion PATCH to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryLocalNames

    #region PATCH to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/Holidays

    [Fact]
    public async Task PatchToHolidays_WithoutId_ShouldFail()
    {
        // Arrange
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                Holidays = new List<HolidayUpsertDto> { new HolidayUpsertDto { Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        var ownedResult = await PatchAsync(
            $"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.Holidays)}",
            new HolidayUpsertDto
            {
                Name = _fixture.Create<string>()
            },
            headers,
            throwOnError: false);

        //Assert
        ownedResult.Should().NotBeNull();
        ownedResult!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PatchToHolidays_Success()
    {
        // Arrange
        var holidayId = _fixture.Create<System.Guid>();
        var expectedName = _fixture.Create<string>();
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = _fixture.Create<int>(),
                Holidays = new List<HolidayUpsertDto> { new HolidayUpsertDto { Id = holidayId, Name = _fixture.Create<string>() } }
            });
        var headers = CreateEtagHeader(result!.Etag);

        //Act
        await PatchAsync($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(CountryDto.Holidays)}",
            new HolidayUpsertDto
            {
                Id = holidayId,
                Name = expectedName
            },
            headers);

        var getWorkplacesResponse = await GetODataSimpleResponseAsync<CountryDto>(
           $"{Endpoints.CountriesUrl}/{result!.Id}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.Holidays.Should().NotBeNull();
        getWorkplacesResponse!.Holidays!.Should().HaveCount(1);
        getWorkplacesResponse!.Holidays!.First().Id.Should().Be(holidayId);
        getWorkplacesResponse!.Holidays!.First().Name.Should().Be(expectedName);
    }

    #endregion

    #endregion PATCH

    #region DELETE

    #region DELETE Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1
    [Fact]
    public async Task Delete_OwnedEntityViaParentKey_DeletesOwnedEntity()
    {
        var expectedCountryLocalName = _fixture.Create<string>();
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>() {
                new CountryLocalNameUpsertDto() { Name = expectedCountryLocalName }
            }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var headers = CreateEtagHeader(result!.Etag);
        var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Act
        await DeleteAsync($"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(dto.CountryLocalNames)}/{country!.CountryLocalNames[0].Id}", headers);
        var countryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.CountryLocalNames.Should().BeEmpty();
    }
    #endregion DELETE Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1

    #region DELETE [ZeroOrOne] Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    [Fact]
    public async Task Delete_CountryBarCodeViaParentKey_DeletesCountryBarCode()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            CountryBarCode = new CountryBarCodeUpsertDto
            {
                BarCodeName = _fixture.Create<string>()
            }
        };
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

        var headers = CreateEtagHeader(result!.Etag);
        // Act
        await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode", headers);
        var countryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

        // Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.CountryBarCode.Should().BeNull();
    }

    #endregion DELETE [ZeroOrOne] Owned Entity via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

    #endregion DELETE

    #endregion OWNED RELATIONSHIPS EXAMPLES

    #region RELATIONSHIPS EXAMPLES

    #region GET

    #region GET Ref To Related Entities /api/{EntityPluralName}/1/{RelationshipName}/$ref => api/countries/1/Workplaces/$ref

    [Fact]
    public async Task GetRefTo_Workplaces_Success()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
        };
        var Workplaces = new List<WorkplaceCreateDto>()
            {
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
            };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        foreach (var workplace in Workplaces)
        {
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplace);
            var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");
        }

        // Act
        var getRefResponse = await GetODataCollectionResponseAsync<IEnumerable<ODataReferenceResponse>>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/$ref");

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

        getRefResponse.Should().NotBeNull();
        getRefResponse.Should().HaveCount(3)
            .And
            .AllSatisfy(x => x.ODataId.Should().NotBeNullOrEmpty());
    }

    [Fact]
    public async Task GetRefToWorkplaces_ValidateResponseStatusCode()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
        };
        var Workplaces = new List<WorkplaceCreateDto>()
            {
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
            };

        // Act and Assert
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var countryValidIdWithoutWorkplaces = await GetODataCollectionResponseAsync<IEnumerable<ODataReferenceResponse>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/$ref");
        countryValidIdWithoutWorkplaces!.Should().HaveCount(0);

        var countryInvalidIdWithoutWorkplaces = await GetAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id + 1}/Workplaces/$ref");
        countryInvalidIdWithoutWorkplaces!.StatusCode.Should().Be(HttpStatusCode.NotFound);

        foreach (var workplace in Workplaces)
        {
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplace);
            var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");
        }

        var countryValidIdWithWorkplaces = await GetODataCollectionResponseAsync<IEnumerable<ODataReferenceResponse>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/$ref");
        countryValidIdWithWorkplaces!.Should().HaveCount(3);

        var countryInvalidIdWithWorkplaces = await GetAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id + 1}/Workplaces/$ref");
        countryInvalidIdWithoutWorkplaces!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion GET Ref To Related Entities /api/{EntityPluralName}/1/{RelationshipName}/$ref => api/countries/1/Workplaces/$ref

    #region GET Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/countries/1/Workplaces

    [Fact]
    public async Task Get_CountryWorkplaces_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var headers = CreateEtagHeader(countryResponse!.Etag);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
            headers);

        // Act
        const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
        var getWorkplacesResponse = await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}?{oDataRequest}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.Should().HaveCount(1);
        getWorkplacesResponse!.First().Id.Should().Be(workplaceResponse!.Id);
        getWorkplacesResponse!.First().Country.Should().NotBeNull();
        getWorkplacesResponse!.First().Country!.Id.Should().Be(countryResponse!.Id);
        getWorkplacesResponse!.First().CountryId.Should().Be(countryResponse!.Id);
    }

    [Fact]
    public async Task Get_CountryWorkplaces_WhenNoRelatedWorkplaces_Ok()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });

        // Act
        var getWorkplacesResponse = await GetAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Get_CountryWorkplaces_InvalidCountryId_NotFound()
    {
        // Act
        var getWorkplacesResponse = await GetAsync($"{Endpoints.CountriesUrl}/{1}/{nameof(CountryDto.Workplaces)}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region GET by Id Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedKey} => api/countries/1/Workplaces/1

    [Fact]
    public async Task GetById_CountryWorkplace_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var headers = CreateEtagHeader(countryResponse!.Etag);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
            headers);

        // Act
        const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
        var getWorkplacesResponse = await GetODataSimpleResponseAsync<WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{workplaceResponse!.Id}?{oDataRequest}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.Id.Should().Be(workplaceResponse!.Id);
        getWorkplacesResponse!.Country.Should().NotBeNull();
        getWorkplacesResponse!.Country!.Id.Should().Be(countryResponse!.Id);
        getWorkplacesResponse!.CountryId.Should().Be(countryResponse!.Id);
    }

    [Fact]
    public async Task GetById_CountryWorkplace_InvalidWorkplaceId_NotFound()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });

        // Act
        var getWorkplacesResponse = await GetAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{1}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetById_CountryWorkplace_InvalidCountryIdAndWorkplaceId_NotFound()
    {
        // Act
        var getWorkplacesResponse = await GetAsync(
            $"{Endpoints.CountriesUrl}/{1}/{nameof(CountryDto.Workplaces)}/{1}");

        //Assert
        getWorkplacesResponse.Should().NotBeNull();
        getWorkplacesResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #endregion GET

    #region POST

    #region POST Entity With Related Entities /api/{EntityPluralName} => api/countries

    [Fact(Skip = "We are not allowing to related entity or entities on post, avoid circular dependency on dto and edge cases")]
    public async Task Post_WithManyRelatedEntities_Success()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Workplaces = new List<WorkplaceCreateDto>()
            {
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
            }
        };
        // Act
        var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}?{oDataRequest}");

        //Assert
        result.Should().NotBeNull();
        result!.Id.Should().BeGreaterThanOrEqualTo(10);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should()
            .HaveCount(3)
                .And
            .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
    }

    #endregion POST Entity With Related Entities /api/{EntityPluralName} => api/countries

    #region POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/Workplaces/1/$ref

    [Fact]
    public async Task Post_CreateRefToWorkplaces_Success()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
        var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
        var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        workplaceResponse.Should().NotBeNull();
        workplaceResponse!.Id.Should().BeGreaterThan(0);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should()
            .HaveCount(1)
                .And
            .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
    }

    #endregion POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/Workplaces/1/$ref

    #region POST Entity with Related Entities Ids /api/{EntityPluralName} => api/countries

    [Fact]
    public async Task Post_WithWorkplacesId_Success()
    {
        // Arrange
        var workplaceResponse1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse3 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var countryCreateDto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            WorkplacesId = new List<long> {
                workplaceResponse1!.Id,
                workplaceResponse2!.Id,
                workplaceResponse3!.Id,
            }
        };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(3);
    }

    [Fact]
    public async Task Post_WithInvalidWorkplacesId_Fails()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            WorkplacesId = new List<long> { _fixture.Create<long>() }
        };

        // Act
        var countryResponse = await PostAsync(Endpoints.CountriesUrl, countryCreateDto);

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    #endregion

    #region POST Related Entity TO Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/countries/1/Workplaces

    [Fact]
    public async Task Post_WorkplacesToCountry_Success()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);

        // Act
        var headers = CreateEtagHeader(countryResponse!.Etag);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        workplaceResponse.Should().NotBeNull();
        workplaceResponse!.Name.Should().NotBeNull();
        workplaceResponse!.CountryId.Should().Be(countryResponse!.Id);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(1);
        getCountryResponse!.Workplaces!.First().Id.Should().Be(workplaceResponse!.Id);
    }

    #endregion

    #endregion POST

    #region DELETE

    #region DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/Workplaces/1/$ref

    [Fact]
    public async Task Delete_RefToWorkplaces_Success()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
        };
        var Workplaces = new List<WorkplaceCreateDto>()
            {
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
            };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        foreach (var workplace in Workplaces)
        {
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplace);
            var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");
        }

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        var deleteRefResponse = await DeleteAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{getCountryResponse!.Workplaces!.First()!.Id}/$ref");
        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should()
            .HaveCount(2)
                .And
            .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
    }

    #endregion DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/Workplaces/1/$ref

    #region DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/countries/1/Workplaces/1/$ref

    [Fact]
    public async Task Delete_AllRefToWorkplaces_Success()
    {
        // Arrange
        var dto = new CountryCreateDto
        {
            Name = _fixture.Create<string>(),
            Workplaces = new List<WorkplaceCreateDto>()
            {
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
            }
        };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
        var deleteRefResponse = await DeleteAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/$ref");

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces.Should().BeEmpty();
    }

    #endregion DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/countries/1/Workplaces/1/$ref

    #region DELETE related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey} => api/countries/1/Workplaces/1

    [Fact]
    public async Task Delete_Workplaces_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });

        // Act
        var postToWorkplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

        var headers = CreateEtagHeader(postToWorkplaceResponse!.Etag);
        var deleteWorkplaceResponse = await DeleteAsync(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{postToWorkplaceResponse!.Id}",
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");
        var getWorkplaceResponse = await GetAsync($"{Endpoints.WorkplacesUrl}/{postToWorkplaceResponse!.Id}");

        //Assert
        deleteWorkplaceResponse.Should().NotBeNull();
        deleteWorkplaceResponse!.StatusCode.Should().Be(HttpStatusCode.NoContent);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Workplaces.Should().BeEmpty();

        getWorkplaceResponse.Should().NotBeNull();
        getWorkplaceResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #region DELETE all related entities /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/countries/1/Workplaces

    [Fact]
    public async Task Delete_AllWorkplaces_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });

        // Act
        var postToWorkplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

        var headers = CreateEtagHeader(postToWorkplaceResponse!.Etag);
        var deleteWorkplaceResponse = await DeleteAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}", headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");
        var getWorkplaceResponse = await GetAsync($"{Endpoints.WorkplacesUrl}/{postToWorkplaceResponse!.Id}");

        //Assert
        deleteWorkplaceResponse.Should().NotBeNull();
        deleteWorkplaceResponse!.StatusCode.Should().Be(HttpStatusCode.NoContent);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Workplaces.Should().BeEmpty();

        getWorkplaceResponse.Should().NotBeNull();
        getWorkplaceResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    #endregion

    #endregion DELETE

    #region PUT

    #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/countries/1

    [Fact(Skip = "NOX-237")]
    public async Task Put_UpdateCountryWorkplaces_FromEmptyToList_Success()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
        var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);

        var headers = CreateEtagHeader(countryResponse!.Etag);
        var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = countryResponse!.Name,
                //WorkplacesId = new List<UInt32> { workplaceResponse!.Id }
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

    [Fact(Skip = "NOX-237")]
    public async Task Put_UpdateCountryWorkplaces_FromListToEmpty_Success()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
        var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
        var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = countryResponse!.Name,
                //WorkplacesId = new List<UInt32>()
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(0);
    }

    [Fact(Skip = "NOX-237")]
    public async Task Put_UpdateCountryWorkplaces_FromListToList_Success()
    {
        // Arrange
        var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
        var workplaceCreateDto1 = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
        var workplaceCreateDto2 = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
        var workplaceCreateDto3 = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
        var workplaceCreateDto4 = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
        var workplaceCreateDto5 = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

        // Act
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
        var workplaceResponse1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto1);
        var workplaceResponse2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto2);
        var workplaceResponse3 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto3);
        var workplaceResponse4 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto4);
        var workplaceResponse5 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto5);
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse1!.Id}/$ref");
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse2!.Id}/$ref");
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse3!.Id}/$ref");

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
            new CountryUpdateDto
            {
                Name = countryResponse!.Name,
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(3);
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse2!.Id));
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse4!.Id));
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse5!.Id));
        getCountryResponse!.Workplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse1!.Id));
        getCountryResponse!.Workplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse3!.Id));
    }

    #endregion

    #region PUT Update Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey} => api/countries/1/Workplaces/1

    [Fact]
    public async Task Put_WorkplacesToCountry_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });

        var postToWorkplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}",
            new WorkplaceCreateDto() { Name = _fixture.Create<string>(), Description = _fixture.Create<string>() });

        var expectedDescription = _fixture.Create<string>();

        // Act
        var headers = CreateEtagHeader(postToWorkplaceResponse!.Etag);
        var putToWorkplaceResponse = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/{postToWorkplaceResponse!.Id}",
            new WorkplaceUpdateDto()
            {
                Name = postToWorkplaceResponse!.Name,
                Description = expectedDescription
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        putToWorkplaceResponse.Should().NotBeNull();
        putToWorkplaceResponse!.Id.Should().Be(postToWorkplaceResponse!.Id);
        putToWorkplaceResponse!.Description.Should().Be(expectedDescription);
        putToWorkplaceResponse!.Name.Should().Be(postToWorkplaceResponse!.Name);

        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(1);
        getCountryResponse!.Workplaces!.First().Id.Should().Be(postToWorkplaceResponse!.Id);
        getCountryResponse!.Workplaces!.First().Description.Should().Be(expectedDescription);
        getCountryResponse!.Workplaces!.First().Name.Should().Be(postToWorkplaceResponse!.Name);
    }

    #endregion

    #region PUT Update ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/countries/1/Workplaces/$ref

    [Fact]
    public async Task Put_UpdateRefCountryToWorkplaces_FromEmptyToList_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

        // Act
        var headers = CreateEtagHeader(countryResponse!.Etag);
        var updateRefResponse = await PutAsync<ReferencesDto<Int64>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/$ref",
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

    [Fact]
    public async Task Put_UpdateRefCountryToWorkplaces_FromListToEmpty_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
            new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
            new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse!.Id}/$ref");
        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var updateRefResponse = await PutAsync<ReferencesDto<Int64>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/$ref",
            new ReferencesDto<Int64>
            {
                References = new List<Int64>()
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(0);
    }

    [Fact]
    public async Task Put_UpdateRefCountryToWorkplaces_FromListToList_Success()
    {
        // Arrange
        var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, new CountryCreateDto { Name = _fixture.Create<string>() });
        var workplaceResponse1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse3 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse4 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        var workplaceResponse5 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse1!.Id}/$ref");
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse2!.Id}/$ref");
        await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/Workplaces/{workplaceResponse3!.Id}/$ref");

        var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

        // Act
        var headers = CreateEtagHeader(getCountryResponse!.Etag);
        var updateRefResponse = await PutAsync<ReferencesDto<Int64>>(
            $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.Workplaces)}/$ref",
            new ReferencesDto<Int64>
            {
                References = new List<Int64> { workplaceResponse2!.Id, workplaceResponse4!.Id, workplaceResponse5!.Id }
            },
            headers);

        const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
        getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

        //Assert
        getCountryResponse.Should().NotBeNull();
        getCountryResponse!.Id.Should().BeGreaterThan(0);
        getCountryResponse!.Workplaces.Should().NotBeNull();
        getCountryResponse!.Workplaces!.Should().HaveCount(3);
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse2!.Id));
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse4!.Id));
        getCountryResponse!.Workplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse5!.Id));
        getCountryResponse!.Workplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse1!.Id));
        getCountryResponse!.Workplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse3!.Id));
    }

    #endregion

    #endregion PUT

    #region PATCH

    #region PATCH related entity /api/{EntityPluralName}/{EntityKey}/{NavigationName}/{RelatedEntityKey} => /api/countries/1/workplaces/1
    [Fact]
    public async Task WhenPatchRelatedWorkplace_ShouldSucceed()
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
    #endregion

    #endregion PATCH


    #region Enumeration Localization

    [Fact]
    public async Task WhenEnumerationValuesProvided_ShouldCreateTranslations()
    {
        // Arrange & Act
        var dto = new CountryContinentLocalizedUpsertDto() { Name = "Europe" };

        // Act
        var result =
            await PutAsync<CountryContinentLocalizedUpsertDto, CountryContinentLocalizedDto>(
                Endpoints.CountriesUrl + "/Continents/1/Languages/fr-FR", dto, null, false);


        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Europe");
        result.CultureCode.Should().Be("fr-FR");
        result.Id.Should().Be(1);
    }

    [Fact]
    public async Task WhenEnumerationValuesProvidedWithEmptyName_ShouldReturnBadRequest()
    {
        // Arrange & Act
        var dto = new CountryContinentLocalizedUpsertDto();

        // Act
        var result =
            await PutAsync(Endpoints.CountriesUrl + "/Continents/1/Languages/fr-FR", dto, null, false);

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task WhenEnumerationValuesProvidedWithUnsupportedCultureCode_ShouldReturnBadRequest()
    {
        // Arrange & Act
        var dto = new CountryContinentLocalizedUpsertDto() { Name = "Avrupa" };

        // Act
        var result =
            await PutAsync(Endpoints.CountriesUrl + "/Continents/1/Languages/tr-TR", dto, null, false);

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task WhenEnumerationValuesProvidedWithInvalidId_ShouldReturnBadRequest()
    {
        // Arrange & Act
        var dto = new CountryContinentLocalizedUpsertDto() { Name = "Océanie" };

        // Act
        var result =
            await PutAsync(Endpoints.CountriesUrl + "/Continents/15/Languages/fr-FR", dto, null, false);


        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task WhenGetEnumerationLocalized_ShouldReturnLocalizedEnumeration()
    {
        // initial           
        var result =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
                                                                               "/Continents/Languages"))?.ToList();

        result.Should().NotBeNull();
        result!.Count.Should().Be(5);

        // Arrange
        await PutNewCountryContinent();

        // Act
        result = (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
            "/Continents/Languages"))?.ToList();

        // Assert
        result.Should().NotBeNull();
        result!.Count.Should().Be(6);
        result.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        result.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");
    }

    [Fact]
    public async Task WhenUpdateEnumeration_ShouldUpdateTranslationsButNotDefault()
    {
        // initial
        await PutNewCountryContinent();
        var initialSet =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
                                                                               "/Continents/Languages"))?.ToList();

        initialSet.Should().NotBeNull();
        initialSet!.Count.Should().Be(6);
        initialSet.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        initialSet.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        // Arrange
        var dto = new CountryContinentLocalizedUpsertDto() { Name = "Afriquee" };

        // Act
        await PutNewCountryContinent(dto);

        // Assert
        var continentTranslations =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
                                                                               "/Continents/Languages"))?.ToList();

        continentTranslations.Should().NotBeNull();
        continentTranslations!.Count.Should().Be(6);
        continentTranslations.Should().Contain(x => x.Name == "Afriquee" && x.CultureCode == "fr-FR");
        continentTranslations.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        var continents =
            (await GetODataCollectionResponseAsync<IEnumerable<CountryContinentDto>>(
                $"{Endpoints.CountriesUrl}/Continents"))?.ToList();

        continents.Should().NotBeNull();
        continents!.Count.Should().Be(5);
        continents.Should().Contain(x => x.Name == "Africa");
    }

    [Fact]
    public async Task WhenUpdateDefaultEnumerationTranslations_ShouldUpdateTranslationsAndDefaults()
    {
        // initial
        await PutNewCountryContinent();
        var initialSet =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
                                                                               "/Continents/Languages"))?.ToList();

        initialSet.Should().NotBeNull();
        initialSet!.Count.Should().Be(6);
        initialSet.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        initialSet.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        // Arrange 
        var dto = new CountryContinentLocalizedUpsertDto() { Name = "Africaa" };

        // Act
        await PutNewCountryContinent(dto, "en-US");

        // Assert
        var continentTranslations =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl +
                                                                               "/Continents/Languages"))?.ToList();

        continentTranslations.Should().NotBeNull();
        continentTranslations!.Count.Should().Be(6);
        continentTranslations.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        continentTranslations.Should().Contain(x => x.Name == "Africaa" && x.CultureCode == "en-US");

        var continents =
            (await GetODataCollectionResponseAsync<IEnumerable<CountryContinentDto>>(
                $"{Endpoints.CountriesUrl}/Continents"))?.ToList();

        continents.Should().NotBeNull();
        continents!.Count.Should().Be(5);
        continents.Should().Contain(x => x.Name == "Africaa");
    }

    [Fact]
    public async Task WhenDeleteEnumerationsTranslations_ShouldRemoveTranslations()
    {
        // initial
        await PutNewCountryContinent();
        var initialSet = (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl + "/Continents/Languages"))?.ToList();

        initialSet.Should().NotBeNull();
        initialSet!.Count.Should().Be(6);
        initialSet.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        initialSet.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        // Arrange
        await DeleteAsync($"{Endpoints.CountriesUrl}/CountryContinentsLocalized/fr-FR");

        // Act
        var continentTranslations =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl + "/Continents/Languages"))?.ToList();

        // Assert
        continentTranslations.Should().NotBeNull();
        continentTranslations!.Count.Should().Be(5);
        continentTranslations.Should().NotContain(x => x.CultureCode == "fr-FR");
        continentTranslations.Should().Contain(x => x.CultureCode == "en-US");
    }

    [Fact]
    public async Task WhenDeleteEnumerationsTranslationsWithInvalidCultureCode_ShouldReturnBadRequest()
    {
        // initial
        await PutNewCountryContinent();

        var initialSet = (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl + "/Continents/Languages"))?.ToList();

        initialSet.Should().NotBeNull();
        initialSet!.Count.Should().Be(6);
        initialSet.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        initialSet.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        // Arrange && arrange
        var result = await DeleteAsync($"{Endpoints.CountriesUrl}/CountryContinentsLocalized/aaaa", false);

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task WhenDeleteEnumerationsForDefaultCulture_ShouldReturnBadRequest()
    {
        // initial
        await PutNewCountryContinent();


        var initialSet =
            (await GetResponseAsync<IEnumerable<CountryContinentLocalizedDto>>(Endpoints.CountriesUrl + "/Continents/Languages"))?.ToList();


        initialSet.Should().NotBeNull();
        initialSet!.Count.Should().Be(6);
        initialSet.Should().Contain(x => x.Name == "Afrique" && x.CultureCode == "fr-FR");
        initialSet.Should().Contain(x => x.Name == "Africa" && x.CultureCode == "en-US");

        // Arrange && Act
        var result = await DeleteAsync($"{Endpoints.CountriesUrl}/CountryContinentsLocalized/en-US", false);

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    private async Task PutNewCountryContinent(CountryContinentLocalizedUpsertDto? dto = null,
        string cultureCode = "fr-FR")
    {
        dto ??= new CountryContinentLocalizedUpsertDto() { Name = "Afrique" };

        await PutAsync<CountryContinentLocalizedUpsertDto, CountryContinentLocalizedDto>(Endpoints.CountriesUrl + "/Continents/3/Languages/" + cultureCode, dto, null, false);
    }


    #endregion

    #endregion RELATIONSHIPS EXAMPLES       
}