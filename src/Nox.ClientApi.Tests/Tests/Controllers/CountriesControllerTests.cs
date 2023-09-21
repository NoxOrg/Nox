using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ClientApi.Tests.Tests.Models;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("CountriesControllerTests")]
    public class CountriesControllerTests : NoxIntegrationTestBase
    {
        private const string EntityPluralName = "countries";
        private const string EntityUrl = $"api/{EntityPluralName}";
        private const string WorkplacesUrl = $"api/workplaces";

        public CountriesControllerTests(NoxTestContainerService containerService) : base(containerService)
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
                CountryDebt = new MoneyDto(10, CurrencyCode.USD)
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act
            const string oDataRequest = "$select=Name";
            var response = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}?{oDataRequest}");


            //Assert
            response.Should().NotBeNull();
            response!.Name.Should().NotBeNullOrEmpty();
            response.Population.Should().BeNull();
            response.CountryDebt.Should().BeNull();

        }
        #endregion

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
                CountryDebt = new MoneyDto(10, CurrencyCode.USD),
                CountryShortNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = expectedLocalName}
                },
                CountryBarCode = new CountryBarCodeCreateDto() { BarCodeName = expectedBarCodeName }
            };
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act            
            const string oDataRequest = $"$select={nameof(dto.CountryShortNames)}&$expand={nameof(dto.CountryShortNames)}($filter=Name eq 'Lusitania')";
            var response = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}?{oDataRequest}");


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
        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{EntityUrl}/{result!.Id}/{nameof(dto.CountryShortNames)}");

            // Assert
            results.Should()
                .HaveCount(expectedCountryLocalNames.Count)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty())
                    .And
                .AllSatisfy(x => x.Id.Should().BeGreaterThan(0));

        }
        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryLocalNameDto>>($"{EntityUrl}/{result!.Id}/{nameof(dto.CountryShortNames)}?$filter=Name eq '{expectedName}'");

            // Assert
            results.Should()
                .HaveCount(1)
                    .And
                .AllSatisfy(x => x.Name.Should().Be(expectedName))
                    .And
                .AllSatisfy(x => x.Id.Should().BeGreaterThan(0));

        }
        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var country = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            // Act
            var countryLocalName = await GetODataSimpleResponseAsync<CountryLocalNameDto>(
                $"{EntityUrl}/{country!.Id}/{nameof(dto.CountryShortNames)}/{country!.CountryShortNames[0].Id}");

            // Assert
            countryLocalName.Should().NotBeNull();
            countryLocalName!.Id.Should().Be(country!.CountryShortNames[0].Id);
            countryLocalName!.Name.Should().Be(expectedCountryLocalName);
        }
        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act
            var countryBarCode = await GetODataSimpleResponseAsync<CountryBarCodeDto>(
                $"{EntityUrl}/{result!.Id}/CountryBarCode");

            // Assert
            countryBarCode.Should().NotBeNull();
            countryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
        }
        #endregion

        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.CountryShortNames!.Single().Name.Should().Be(expectedCountryLocalName);
            getCountryResponse!.CountryBarCode.Should().NotBeNull();
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
        }
        #endregion

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

            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            //Act
            var ownedResult = await PostAsync<CountryLocalNameCreateDto, CountryLocalNameDto>($"{EntityUrl}/{result!.Id}/{nameof(createDto.CountryShortNames)}", localNameDto, headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().BeGreaterThan(0);
            ownedResult!.Name.Should().Be(expectedLocalName);
        }
        #endregion

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

            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            //Act
            var ownedResult = await PostAsync<CountryBarCodeCreateDto, CountryBarCodeDto>($"{EntityUrl}/{result!.Id}/CountryBarCode", barCodeDto, headers);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");
            
            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.BarCodeName.Should().Be(expectedBarCodeName);
            getCountryResponse!.CountryBarCode.Should().NotBeNull();
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);

        }
        #endregion

        #endregion

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
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{postCountryResponse!.Id}");
            var headers = CreateEtagHeader(getCountryResponse?.Etag);
            var ownedResult = await PutAsync<CountryLocalNameUpdateDto, CountryLocalNameDto>(
                $"{EntityUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryShortNames)}/{getCountryResponse!.CountryShortNames[0].Id}",
                new CountryLocalNameUpdateDto
                {
                    Name = expectedOwnedName
                }, headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().Be(getCountryResponse!.CountryShortNames[0].Id);
            ownedResult!.Name.Should().Be(expectedOwnedName);
        }
        #endregion

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
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var headers = CreateEtagHeader(postCountryResponse?.Etag);
            var putToCountryBarCodeResponse = await PutAsync<CountryBarCodeUpdateDto, CountryBarCodeDto>(
                $"{EntityUrl}/{postCountryResponse!.Id}/CountryBarCode",
                new CountryBarCodeUpdateDto
                {
                    BarCodeName = expectedBarCode

                }, headers);

            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{postCountryResponse!.Id}");

            //Assert
            putToCountryBarCodeResponse.Should().NotBeNull();
            putToCountryBarCodeResponse!.BarCodeName.Should().Be(expectedBarCode);

            getCountryResponse!.Id.Should().Be(postCountryResponse!.Id);
            getCountryResponse!.Name.Should().Be(postCountryResponse!.Name);
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCode);
        }
        #endregion

        #endregion

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
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{postCountryResponse!.Id}");
            var headers = CreateEtagHeader(getCountryResponse?.Etag);
            var ownedResult = await PatchAsync<Dictionary<string, object>, CountryLocalNameDto>(
                $"{EntityUrl}/{getCountryResponse!.Id}/{nameof(dto.CountryShortNames)}/{getCountryResponse!.CountryShortNames[0].Id}",
                dictionary,
                headers);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().Be(getCountryResponse!.CountryShortNames[0].Id);
            ownedResult!.Name.Should().Be(expectedOwnedName);
            ownedResult!.NativeName.Should().Be(expectedOwnedNativeName);
        }
        #endregion

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
                CountryBarCode = new CountryBarCodeCreateDto {
                    BarCodeName = _fixture.Create<string>(),
                    BarCodeNumber = expectedBarCodeNumber
                }
            };
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("BarCodeName", expectedBarCodeName);

            // Act
            var postCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var headers = CreateEtagHeader(postCountryResponse?.Etag);
            var ownedResult = await PatchAsync<Dictionary<string, object>, CountryBarCodeDto>(
                $"{EntityUrl}/{postCountryResponse!.Id}/CountryBarCode",
                dictionary,
                headers);
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{postCountryResponse!.Id}");

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.BarCodeName.Should().Be(expectedBarCodeName);
            ownedResult!.BarCodeNumber.Should().Be(expectedBarCodeNumber);

            getCountryResponse!.Id.Should().Be(postCountryResponse!.Id);
            getCountryResponse!.Name.Should().Be(postCountryResponse!.Name);
            getCountryResponse!.CountryBarCode!.BarCodeName.Should().Be(expectedBarCodeName);
            getCountryResponse!.CountryBarCode!.BarCodeNumber.Should().Be(expectedBarCodeNumber);
        }
        #endregion

        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var country = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            // Act
            await DeleteAsync($"{EntityUrl}/{country!.Id}/{nameof(dto.CountryShortNames)}/{country!.CountryShortNames[0].Id}");
            var countryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            // Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.CountryShortNames.Should().BeEmpty();
        }
        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            // Act
            await DeleteAsync($"{EntityUrl}/{result!.Id}/CountryBarCode");
            var countryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            // Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.CountryBarCode.Should().BeNull();
        }
        #endregion

        #endregion

        #endregion

        #region RELATIONSHIPS EXAMPLES

        #region GET

        #region GET Ref To Related Entities /api/{EntityPluralName}/1/{RelationshipName} => api/countries/1/PhysicalWorkplaces/$ref
        [Fact]
        public async Task GetRefTo_PhysicalWorkplaces_Success()
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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var getRefResponse = await GetODataCollectionResponseAsync<IEnumerable<ODataReferenceResponse>>($"{EntityUrl}/{result!.Id}/physicalworkplaces/$ref");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getRefResponse.Should().NotBeNull();
            getRefResponse.Should().HaveCount(3)
                .And
                .AllSatisfy(x => x.ODataId.Should().NotBeNullOrEmpty());
        }
        #endregion

        #endregion

        #region POST

        #region POST Entity With Related Entities /api/{EntityPluralName} => api/countries
        [Fact]
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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(3)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }
        #endregion

        #region POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref
        [Fact]
        public async Task Post_CreateRefToPhysicalWorkplaces_Success()
        {
            // Arrange
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };

            // Act
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, countryCreateDto);
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesUrl, workplaceCreateDto);
            var createRefResponse = await PostAsync($"{EntityUrl}/{countryResponse!.Id}/physicalworkplaces/{workplaceResponse!.Id}/$ref");
            
            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(1)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }
        #endregion

        #endregion

        #region DELETE

        #region DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/countries/1/PhysicalWorkplaces/1/$ref
        [Fact]
        public async Task Delete_RefToPhysicalWorkplaces_Success()
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
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{countryResponse!.Id}?{oDataRequest}");

            var deleteRefResponse = await DeleteAsync($"{EntityUrl}/{countryResponse!.Id}/physicalworkplaces/{getCountryResponse!.PhysicalWorkplaces!.First()!.Id}/$ref");
            getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{countryResponse!.Id}?{oDataRequest}");


            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces!.Should()
                .HaveCount(2)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty());
        }
        #endregion

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
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var deleteRefResponse = await DeleteAsync($"{EntityUrl}/{countryResponse!.Id}/physicalworkplaces/$ref");

            const string oDataRequest = $"$expand={nameof(CountryDto.PhysicalWorkplaces)}"; 
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{countryResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.PhysicalWorkplaces.Should().NotBeNull();
            getCountryResponse!.PhysicalWorkplaces.Should().BeEmpty();
        }
        #endregion

        #endregion

        #endregion

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);
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
                await PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);
            }
            // Act
            const string oDataRequest = "$select=Name&$filter=population lt 3000000&$count=true";
            var results = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{EntityUrl}/?{oDataRequest}");

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
            var expectedAmount = 100;
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

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
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);

            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);

            var updateResult = await PutAsync($"{EntityUrl}/{result!.Id}", updateDto, false);
            var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            //Assert
            updateResult!.StatusCode.Should().Be(HttpStatusCode.Conflict);
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

            var updateDto = new CountryUpdateDto
            {
                Population = expectedNumber
            };

            // Act
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(postResult!.Etag);

            var patchResult = await PatchAsync<CountryUpdateDto, CountryDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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
            var result = await PostAsync(EntityUrl, createDto);

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            await DeleteAsync($"{EntityUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{EntityUrl}/{result!.Id}");

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);
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
            var postResult = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, dto);
            var headers = CreateEtagHeader(postResult?.Etag);
            var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{EntityUrl}/{postResult!.Id}", updateDto, headers);

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
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);

            var deleteResult = await DeleteAsync($"{EntityUrl}/{result!.Id}", false);
            var queryResult = await GetAsync($"{EntityUrl}/{result!.Id}");

            // Assert
            deleteResult!.StatusCode.Should().Be(HttpStatusCode.Conflict);
            queryResult.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_WhenTryingToGetOwnedEntities_ReturnesNotFound()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1_000_000,
                CountryDebt = new MoneyDto(10, CurrencyCode.USD),
                CountryShortNames = new List<CountryLocalNameCreateDto>()
                {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = "Lusitania"}
                }
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(EntityUrl, createDto);
            var headers = CreateEtagHeader(result?.Etag);

            var country = await GetODataSimpleResponseAsync<CountryDto>($"{EntityUrl}/{result!.Id}");

            await DeleteAsync($"{EntityUrl}/{result!.Id}", headers);

            // Assert
            var queryResult = await GetAsync($"{EntityUrl}/{result!.Id}/CountryLocalNames/{country!.CountryShortNames[0].Id}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion
    }
}