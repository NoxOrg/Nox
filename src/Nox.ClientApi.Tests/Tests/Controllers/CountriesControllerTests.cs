using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Humanizer;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("CountriesControllerTests")]
    public class CountriesControllerTests : NoxWebApiTestBase
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
                CountryShortNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = expectedLocalName}
                },
                CountryBarCode = new CountryBarCodeCreateDto() { BarCodeName = expectedBarCodeName }
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            // Act
            const string oDataRequest = $"$select={nameof(dto.CountryShortNames)}&$expand={nameof(dto.CountryShortNames)}($filter=Name eq 'Lusitania')";
            var response = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            response.Should().NotBeNull();
            response!.Name.Should().BeNull();
            response.Population.Should().BeNull();
            response.CountryDebt.Should().BeNull();

            response.CountryShortNames.Should().HaveCount(1);
            response.CountryShortNames[0].Name.Should().Be(expectedLocalName);
            response.CountryBarCode.Should().NotBeNull();
            response.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
        }

        #endregion GET Single Owned Entity (filter by query) via Parent Entity /api/{EntityPluralName}/{EntityKey}?Query => api/countries/1?$select=CountryLocalNames&$expand=CountryLocalNames($filter=Name eq 'Lusitania')

        #region GET Owned Entities via Parent Key /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName} => api/countries/1/CountryLocalNames

        [Fact]
        public async Task Get_OwnedEntitiesByParentKey_ReturnsOwnedEntitiesList()
        {
            var expectedCountryLocalNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = "Lusitania"}
                };
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = "Portugal",
                CountryShortNames = expectedCountryLocalNames
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            // Act
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryShortNames)}");

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
            var expectedCountryLocalNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = expectedName}
                };
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = "Portugal",
                CountryShortNames = expectedCountryLocalNames
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            // Act
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(dto.CountryShortNames)}?$filter=Name eq '{expectedName}'");

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
                CountryShortNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = expectedCountryLocalName }
                }
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            // Act
            var countryLocalName = await GetODataSimpleResponseAsync<CountryLocalNameDto>(
                $"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(dto.CountryShortNames)}/{country!.CountryShortNames[0].Id}");

            // Assert
            countryLocalName.Should().NotBeNull();
            countryLocalName!.Id.Should().Be(country!.CountryShortNames[0].Id);
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
                CountryBarCode = new CountryBarCodeCreateDto() { BarCodeName = expectedBarCodeName }
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
                CountryShortNames = new List<CountryLocalNameCreateDto>() { new CountryLocalNameCreateDto() { Name = expectedCountryLocalName } },
                CountryBarCode = new CountryBarCodeCreateDto() { BarCodeName = expectedBarCodeName }
            };
            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThanOrEqualTo(10);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            getCountryResponse!.CountryShortNames!.Single().Name.Should().Be(expectedCountryLocalName);
            getCountryResponse!.CountryBarCode.Should().NotBeNull();
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
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

            var localNameDto = new CountryLocalNameCreateDto
            {
                Name = expectedLocalName
            };

            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            //Act
            var ownedResult = await PostAsync<CountryLocalNameCreateDto, CountryLocalNameDto>($"{Endpoints.CountriesUrl}/{result!.Id}/{nameof(createDto.CountryShortNames)}", localNameDto, headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().BeGreaterThan(0);
            ownedResult!.Name.Should().Be(expectedLocalName);
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

            var barCodeDto = new CountryBarCodeCreateDto
            {
                BarCodeName = expectedBarCodeName
            };

            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            //Act
            var ownedResult = await PostAsync<CountryBarCodeCreateDto, CountryBarCodeDto>($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode", barCodeDto, headers);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.BarCodeName.Should().Be(expectedBarCodeName);
            getCountryResponse!.CountryBarCode.Should().NotBeNull();
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
        }

        #endregion POST to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryBarCode

        #endregion POST

        #region PUT

        #region PUT to Owned Entities /api/{EntityPluralName}/{key}/{OwnedEntityPluralName}/{relatedKey} => api/countries/1/CountryLocalNames/1

        [Fact]
        public async Task PutToCountryLocalNames_ShouldUpdateCountryLocalName()
        {
            // Arrange
            var expectedOwnedName = _fixture.Create<string>();
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryShortNames = new List<CountryLocalNameCreateDto>() { new CountryLocalNameCreateDto() { Name = _fixture.Create<string>() } }
            };
            // Act
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");
            var headers = CreateEtagHeader(getCountryResponse?.Etag);
            var ownedResult = await PutAsync<CountryLocalNameUpdateDto, CountryLocalNameDto>(
                $"{Endpoints.CountriesUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryShortNames)}/{getCountryResponse!.CountryShortNames[0].Id}",
                new CountryLocalNameUpdateDto
                {
                    Name = expectedOwnedName
                }, headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().Be(getCountryResponse!.CountryShortNames[0].Id);
            ownedResult!.Name.Should().Be(expectedOwnedName);
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
                CountryBarCode = new CountryBarCodeCreateDto() { BarCodeName = _fixture.Create<string>() }
            };
            // Act
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var headers = CreateEtagHeader(postCountryResponse?.Etag);
            var putToCountryBarCodeResponse = await PutAsync<CountryBarCodeUpdateDto, CountryBarCodeDto>(
                $"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}/CountryBarCode",
                new CountryBarCodeUpdateDto
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

        #endregion PUT

        #region PATCH

        #region PATCH to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1

        [Fact]
        public async Task PatchToCountryLocalNames_ShouldUpdateCountryLocalName()
        {
            // Arrange
            var expectedOwnedName = _fixture.Create<string>();
            var expectedOwnedNativeName = _fixture.Create<string>();
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryShortNames = new List<CountryLocalNameCreateDto>() { new CountryLocalNameCreateDto() {
                    Name = _fixture.Create<string>(),
                    NativeName = expectedOwnedNativeName
                } }
            };
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Name", expectedOwnedName);

            // Act
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{postCountryResponse!.Id}");
            var headers = CreateEtagHeader(getCountryResponse?.Etag);
            var ownedResult = await PatchAsync<Dictionary<string, object>, CountryLocalNameDto>(
                $"{Endpoints.CountriesUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryShortNames)}/{getCountryResponse!.CountryShortNames[0].Id}",
                dictionary,
                headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().Be(getCountryResponse!.CountryShortNames[0].Id);
            ownedResult!.Name.Should().Be(expectedOwnedName);
            ownedResult!.NativeName.Should().Be(expectedOwnedNativeName);
        }

        #endregion PATCH to Owned Entities /api/{EntityPluralName}/{EntityKey}/{OwnedEntityPluralName}/{OwnedEntityKey} => api/countries/1/CountryLocalNames/1

        #region PATCH to [ZeroOrOne] Owned Entity /api/{EntityPluralName}/{EntityKey}/{OwnedEntityName} => api/countries/1/CountryLocalNames

        [Fact]
        public async Task PatchToCountryBarCode_ShouldUpdateCountryBarCode()
        {
            // Arrange
            var expectedBarCodeName = _fixture.Create<string>();
            var expectedBarCodeNumber = _fixture.Create<int>();
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryBarCode = new CountryBarCodeCreateDto
                {
                    BarCodeName = _fixture.Create<string>(),
                    BarCodeNumber = expectedBarCodeNumber
                }
            };
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("BarCodeName", expectedBarCodeName);

            // Act
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var headers = CreateEtagHeader(postCountryResponse?.Etag);
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
                CountryShortNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = expectedCountryLocalName }
                }
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            // Act
            await DeleteAsync($"{Endpoints.CountriesUrl}/{country!.Id}/{nameof(dto.CountryShortNames)}/{country!.CountryShortNames[0].Id}");
            var countryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            // Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.CountryShortNames.Should().BeEmpty();
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
                CountryBarCode = new CountryBarCodeCreateDto
                {
                    BarCodeName = _fixture.Create<string>()
                }
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            // Act
            await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryBarCode");
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

        #region GET Ref To Related Entities /api/{EntityPluralName}/1/{RelationshipName}/$ref => api/countries/1/PhysicalWorkplaces/$ref

        [Fact]
        public async Task GetRefTo_PhysicalWorkplaces_Success()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
            };
            var physicalWorkplaces = new List<WorkplaceCreateDto>()
                {
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
                };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            foreach (var workplace in physicalWorkplaces)
            {
                var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplace);
                var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/PhysicalWorkplaces/{workplaceResponse!.Id}/$ref");
            }

            // Act
            var getRefResponse = await GetODataCollectionResponseAsync<IEnumerable<ODataReferenceResponse>>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/$ref");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

            getRefResponse.Should().NotBeNull();
            getRefResponse.Should().HaveCount(3)
                .And
                .AllSatisfy(x => x.ODataId.Should().NotBeNullOrEmpty());
        }

        #endregion GET Ref To Related Entities /api/{EntityPluralName}/1/{RelationshipName}/$ref => api/countries/1/PhysicalWorkplaces/$ref

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
                PhysicalWorkplaces = new List<WorkplaceCreateDto>()
                {
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
                }
            };
            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThanOrEqualTo(10);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(3)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }

        #endregion POST Entity With Related Entities /api/{EntityPluralName} => api/countries

        #region POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        [Fact]
        public async Task Post_CreateRefToPhysicalWorkplaces_Success()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(1)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }

        #endregion POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        #region POST Entity with Related Entities Ids /api/{EntityPluralName} => api/countries

        [Fact]
        public async Task Post_WithPhysicalWorkplacesId_Success()
        {
            // Arrange
            var workplaceResponse1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, 
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
            var workplaceResponse2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
            var workplaceResponse3 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() });
            var countryCreateDto = new CountryCreateDto { 
                Name = _fixture.Create<string>(),
                PhysicalWorkplacesId = new List<UInt32> {
                    workplaceResponse1!.Id,
                    workplaceResponse2!.Id,
                    workplaceResponse3!.Id,
                }
            };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should().HaveCount(3);
        }

        [Fact]
        public async Task Post_WithInvalidPhysicalWorkplacesId_Fails()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                PhysicalWorkplacesId = new List<UInt32> { _fixture.Create<UInt32>() }
            };

            // Act
            var countryResponse = await PostAsync(Endpoints.CountriesUrl, countryCreateDto);

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Should().HaveStatusCode(HttpStatusCode.BadRequest);
        }

        #endregion

        #region POST Related Entity TO Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/countries/1/PhysicalWorkplaces

        [Fact]
        public async Task Post_PhysicalWorkplacesToCountry_Success()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);

            // Act
            var headers = CreateEtagHeader(countryResponse?.Etag);
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
                $"{Endpoints.CountriesUrl}/{countryResponse!.Id}/{nameof(CountryDto.PhysicalWorkplaces)}",
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                headers);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Name.Should().NotBeNull();
            workplaceResponse!.BelongsToCountryId.Should().Be(countryResponse!.Id);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should().HaveCount(1);
            getCountryResponse!.PhysicalWorkplaces!.First().Id.Should().Be(workplaceResponse!.Id);
        }

        #endregion

        #endregion POST

        #region DELETE

        #region DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        [Fact]
        public async Task Delete_RefToPhysicalWorkplaces_Success()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),               
            };
            var physicalWorkplaces = new List<WorkplaceCreateDto>()
                {
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
                };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            foreach (var workplace in physicalWorkplaces)
            {
                var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplace);
                var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse!.Id}/$ref");
            }

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            var deleteRefResponse = await DeleteAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{getCountryResponse!.PhysicalWorkplaces!.First()!.Id}/$ref");
            getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(2)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }

        #endregion DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        #region DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        [Fact]
        public async Task Delete_AllRefToPhysicalWorkplaces_Success()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                PhysicalWorkplaces = new List<WorkplaceCreateDto>()
                {
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() },
                    new WorkplaceCreateDto() { Name = _fixture.Create<string>() }
                }
            };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var deleteRefResponse = await DeleteAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/$ref");

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThanOrEqualTo(10);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces.Should().BeEmpty();
        }

        #endregion DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref

        #endregion DELETE

        #region PUT

        #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/countries/1

        [Fact]
        public async Task Put_UpdateCountryPhysicalWorkplaces_FromEmptyToList_Success()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);

            var headers = CreateEtagHeader(countryResponse?.Etag);
            var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
                new CountryUpdateDto
                {
                    Name = countryResponse!.Name,
                    PhysicalWorkplacesId = new List<UInt32> { workplaceResponse!.Id }
                },
                headers);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should().HaveCount(1);
            getCountryResponse!.PhysicalWorkplaces!.First().Name.Should().Be(workplaceResponse!.Name);
        }

        [Fact]
        public async Task Put_UpdateCountryPhysicalWorkplaces_FromListToEmpty_Success()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse!.Id}/$ref");
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

            var headers = CreateEtagHeader(getCountryResponse!.Etag);
            var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
                new CountryUpdateDto
                {
                    Name = countryResponse!.Name,
                    PhysicalWorkplacesId = new List<UInt32>()
                },
                headers);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should().HaveCount(0);
        }

        [Fact]
        public async Task Put_UpdateCountryPhysicalWorkplaces_FromListToList_Success()
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
            await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse1!.Id}/$ref");
            await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse2!.Id}/$ref");
            await PostAsync($"{Endpoints.CountriesUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse3!.Id}/$ref");

            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}");

            var headers = CreateEtagHeader(getCountryResponse!.Etag);
            var updateCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
                new CountryUpdateDto
                {
                    Name = countryResponse!.Name,
                    PhysicalWorkplacesId = new List<UInt32>
                    {
                        workplaceResponse2!.Id,
                        workplaceResponse4!.Id,
                        workplaceResponse5!.Id
                    }
                },
                headers);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should().HaveCount(3);
            getCountryResponse!.PhysicalWorkplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse2!.Id));
            getCountryResponse!.PhysicalWorkplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse4!.Id));
            getCountryResponse!.PhysicalWorkplaces!.Should().Contain(w => w.Id.Equals(workplaceResponse5!.Id));
            getCountryResponse!.PhysicalWorkplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse1!.Id));
            getCountryResponse!.PhysicalWorkplaces!.Should().NotContain(w => w.Id.Equals(workplaceResponse3!.Id));
        }

        #endregion

        #endregion

        #endregion RELATIONSHIPS EXAMPLES

        #region TESTS

        [Fact]
        public async Task Post_ReturnsAutoNumberId()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>()
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThanOrEqualTo(10);
        }

        [Fact]
        public async Task Post_UseODataQuery_ReturnsData()
        {
            // Arrange
            for (var i = 0; i < 5; i++)
            {
                var dto = new CountryCreateDto
                {
                    Name = _fixture.Create<string>(),
                    Population = 1_000_000 * (i + 1)
                };
                await PostAsync<CountryCreateDto, CountryKeyDto>(Endpoints.CountriesUrl, dto);
            }
            // Act
            const string oDataRequest = "$select=Name&$filter=population lt 3000000&$count=true";
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.CountriesUrl}/?{oDataRequest}");

            //Assert
            const int expectedCountryCount = 2;

            results.Should()
                .HaveCount(expectedCountryCount)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty())
                    .And
                .AllSatisfy(x => x.Population.Should().BeNull());
        }

        [Fact]
        public async Task Post_WithCompoundMoney_ReturnsAutoNumberId()
        {
            // Arrange
            var expectedAmount = 200_000;
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThanOrEqualTo(10);

            queryResult.Should().NotBeNull();
            queryResult!.CountryDebt!.Amount.Should().Be(expectedAmount);
        }

        [Fact]
        public async Task Post_NameAndPopulation_ShouldPopulateShortDescription()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 10350000
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            result.Should().NotBeNull();
            result!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Fact]
        public async Task Put_Number_ShouldUpdate()
        {
            var expectedNumber = 50;
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 1
            };
            var updateDto = new CountryUpdateDto
            {
                Name = _fixture.Create<string>(),
                Population = expectedNumber
            };

            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            putResult!.Population.Should().Be(expectedNumber);
        }

        [Fact]
        public async Task Put_Name_ShouldPopulateShortDescription()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal123",
                Population = 10350000
            };
            var updateDto = new CountryUpdateDto
            {
                Name = "Portugal",
                Population = 10350000
            };

            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);

            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            putResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Fact]
        public async Task Put_Population_ShouldPopulateShortDescription()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1,
            };
            var updateDto = new CountryUpdateDto
            {
                Name = "Portugal",
                Population = 10350000
            };
            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            putResult.Should().NotBeNull();
            putResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Fact]
        public async Task Put_NumberWithoutLatestEtag_ShouldReturnConflict()
        {
            var expectedNumber = 1;
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 1
            };
            var updateDto = new CountryUpdateDto
            {
                Name = _fixture.Create<string>(),
                Population = 50
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

            var updateResult = await PutAsync($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, false);
            var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            //Assert
            updateResult!.Should().HaveStatusCode(HttpStatusCode.PreconditionRequired);
            queryResult!.Population.Should().Be(expectedNumber);
        }

        [Fact]
        public async Task Patch_Number_ShouldUpdateNumberOnly()
        {
            // Arrange
            var expectedNumber = 50;
            var expectedName = "Portugal";
            var createDto = new CountryCreateDto
            {
                Name = expectedName,
                Population = 1
            };

            var updateDto = new CountryDto
            {
                Population = expectedNumber
            };

            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(postResult!.Etag);

            var patchResult = await PatchAsync<CountryDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            patchResult!.Population.Should().Be(expectedNumber);
            patchResult!.Name.Should().Be(expectedName);
        }

        [Fact]
        public async Task Post_IfNoRequireField_ThrowsException()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Population = 1
            };
            // Act
            var result = await PostAsync(Endpoints.CountriesUrl, createDto);

            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Deleted_ShouldPerformSoftDelete()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1,
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_WhenLanguageIsSet_ShouldReturnSuccess()
        {
            var expectedLanguageCode = "pt";
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                FirstLanguageCode = expectedLanguageCode
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThanOrEqualTo(10);
            result!.FirstLanguageCode.Should().Be(expectedLanguageCode);
        }

        [Fact]
        public async Task Put_WhenLanguageIsSet_ShouldReturnSuccess()
        {
            var createWithLanguage = "pt";
            var updateWithLanguage = "en";
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                FirstLanguageCode = createWithLanguage
            };
            var updateDto = new CountryUpdateDto
            {
                Name = _fixture.Create<string>(),
                FirstLanguageCode = updateWithLanguage
            };

            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

            // Assert
            putResult!.FirstLanguageCode.Should().Be(updateWithLanguage);
        }

        [Fact]
        public async Task Delete_WithoutLatestEtag_ShouldReturnConflict()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1,
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

            var deleteResult = await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", false);
            var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}");

            // Assert
            deleteResult!.Should().HaveStatusCode(HttpStatusCode.PreconditionRequired);
            queryResult.Should().BeSuccessful();
        }

        [Fact]
        public async Task Delete_WhenTryingToGetOwnedEntities_ReturnsNotFound()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1_000_000,
                CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
                CountryShortNames = new List<CountryLocalNameCreateDto>()
                {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = "Lusitania"}
                }
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

            await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryLocalNames/{country!.CountryShortNames[0].Id}");

            queryResult.Should().HaveStatusCode(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task WhenPostWithContinent_ShouldGetContinent()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = "Portugal",
                Continent = 1
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

            result.Should().NotBeNull();
            //TODO Translated
            result!.Continent.Should().Be(1);
        }

        /// <summary>
        /// We override PostToCountryShortNames in CountriesController to set  CustomField on the command
        /// The Command Handler validates if the custom field is properly set
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Post_WithCustomCommandFieldShouldSucced()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1,
            };

            var countryCreatedResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

            // Act
            var headers = CreateEtagHeader(countryCreatedResult?.Etag);
            var countryShortName = new CountryLocalNameCreateDto() { Name = "ShortName" };
            var countryShortNameResult = await PostAsync($"{Endpoints.CountriesUrl}/{countryCreatedResult!.Id}/{nameof(createDto.CountryShortNames)}", countryShortName, headers);

            // Assert
            countryShortNameResult!.Should().HaveStatusCode(HttpStatusCode.Created);            
        }
        #endregion TESTS
    }
}