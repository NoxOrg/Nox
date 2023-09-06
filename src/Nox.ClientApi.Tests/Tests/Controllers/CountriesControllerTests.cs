using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using AutoFixture.AutoMoq;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CountriesControllerTests
    {
        private const string EntityPluralName = "countries";
        private const string EntityUrl = $"api/{EntityPluralName}";
          
        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public CountriesControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        #region EXAMPLES

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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);

            // Act
            const string oDataRequest = "$select=Name";
            var response = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}?{oDataRequest}");


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
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 1_000_000,
                CountryDebt = new MoneyDto(10, CurrencyCode.USD),
                CountryLocalNames = new List<CountryLocalNameCreateDto>() {
                    new CountryLocalNameCreateDto() { Name = "Iberia" },
                    new CountryLocalNameCreateDto() { Name = expectedLocalName}
                }
            };
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);

            // Act            
            const string oDataRequest = "$select=CountryLocalNames&$expand=CountryLocalNames($filter=Name eq 'Lusitania')";
            var response = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}?{oDataRequest}");


            //Assert
            response.Should().NotBeNull();
            response!.Name.Should().BeNull();
            response.Population.Should().BeNull();
            response.CountryDebt.Should().BeNull();

            response.CountryLocalNames.Should().HaveCount(1);
            response.CountryLocalNames.First().Name.Should().Be(expectedLocalName);
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
                CountryLocalNames = expectedCountryLocalNames
            };
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);

            // Act
            var odataResponse = await _oDataFixture.GetAsync<ODataResponse<IEnumerable<CountryLocalNameDto>>>($"{EntityUrl}/{result!.keyId}/CountryLocalNames");
            var results = odataResponse!.Value;

            // Assert
            results.Should()
                .HaveCount(expectedCountryLocalNames.Count())
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
                CountryLocalNames = expectedCountryLocalNames
            };
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);

            // Act
            var odataResponse = await _oDataFixture.GetAsync<ODataResponse<IEnumerable<CountryLocalNameDto>>>($"{EntityUrl}/{result!.keyId}/CountryLocalNames?$filter=Name eq '{expectedName}'");
            var results = odataResponse!.Value;

            // Assert
            results.Should()
                .HaveCount(1)
                    .And
                .AllSatisfy(x => x.Name.Should().Be(expectedName))
                    .And
                .AllSatisfy(x => x.Id.Should().BeGreaterThan(0));

        }
        #endregion  

        #endregion

        #endregion

        #region TESTS 
        [Fact]
        public async Task Post_ReturnsDatabaseNumberId()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>()
            };

            // Act
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);

            //Assert
            result.Should().NotBeNull();
            result!.keyId.Should().BeGreaterThan(0);
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
                await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);
            }
            // Act
            const string oDataRequest = "$select=Name&$filter=population lt 3000000&$count=true";
            var odataResponse = await _oDataFixture.GetAsync<ODataResponse<IEnumerable<CountryDto>>>($"{EntityUrl}/?{oDataRequest}");
            var results = odataResponse!.Value;

            //Assert
            const int expectedCountryCount = 2;

            odataResponse.Count.Should().Be(expectedCountryCount);

            results.Should()
                .HaveCount(expectedCountryCount)
                    .And
                .AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty())
                    .And
                .AllSatisfy(x => x.Population.Should().BeNull());
        }

        [Fact]
        public async Task Post_WithCompoundMoney_ReturnsDatabaseNumberId()
        {
            // Arrange
            var expectedAmount = 100;
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
            };

            // Act
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();
            queryResult!.CountryDebt!.Amount.Should().Be(expectedAmount);
        }

        [Fact]
        public async Task Post_WithManyOwnedEntity_ReturnsDatabaseNumberId()
        {
            // Arrange
            var expectedOwnedName = _fixture.Create<string>();
            var dto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                CountryLocalNames = new List<CountryLocalNameCreateDto>() { new CountryLocalNameCreateDto() { Name = expectedOwnedName } }
            };
            // Act
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            result.Should().NotBeNull();
            result!.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();
            queryResult!.Id.Should().Be(result!.keyId);
            // TODO: add odata controller to test include properly
            //queryResult!.ToDto().OwnedEntities!.Single().Name.Should().Be(expectedOwnedName);
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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, dto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            queryResult.Should().NotBeNull();
            queryResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);
            await _oDataFixture.PutAsync($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            queryResult!.Population.Should().Be(expectedNumber);
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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);
            await _oDataFixture.PutAsync($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            queryResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);
            await _oDataFixture.PutAsync($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            queryResult.Should().NotBeNull();
            queryResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Fact(Skip = "Fix issue with delta serialization")]
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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);
            await _oDataFixture.PatchAsync($"{EntityUrl}/{result!.keyId}", updateDto);
            var queryResult = await _oDataFixture.GetAsync<CountryDto>($"{EntityUrl}/{result!.keyId}");

            //Assert
            queryResult!.Population.Should().Be(expectedNumber);
            queryResult!.Name.Should().Be(expectedName);
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
            var result = await _oDataFixture.PostAsync(EntityUrl, createDto);

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
            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);
            await _oDataFixture.DeleteAsync($"{EntityUrl}/{result!.keyId}");

            // Assert
            var queryResult = await _oDataFixture.GetAsync($"{EntityUrl}/{result!.keyId}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact(Skip = "Test fails when post local names.  The property 'Name[Nullable=False]' of type 'Edm.String' has a null value, which is not allowed.'")]
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

            var result = await _oDataFixture.PostAsync<CountryCreateDto, CountryKeyDto>(EntityUrl, createDto);

            //Act
            var ownedResult = await _oDataFixture.PostAsync<CountryLocalNameCreateDto, CountryLocalNameDto>($"{EntityUrl}/{result!.keyId}/CountryLocalNames", localNameDto);

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().BeGreaterThan(0);
        }

        #endregion
    }
}