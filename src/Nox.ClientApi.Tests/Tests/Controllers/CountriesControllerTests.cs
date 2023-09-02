using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CountriesControllerTests : NoxIntgrationTestBase
    {
        private const string CountryControllerName = "api/countries";

        public CountriesControllerTests(NoxTestApplicationFactory<StartupFixture> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Post_ReturnsDatabaseNumberId()
        {
            // Arrange
            var dto = new CountryCreateDto
            {
                Name = _objectFixture.Create<string>()
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, dto);

            //Assert
            result.Should().NotBeNull();
            result!.keyId.Should().BeGreaterThan(0);
        }

        [Fact(Skip = "Fix issue with inner dto")]
        public async Task Post_WithCompoundMoney_ReturnsDatabaseNumberId()
        {
            // Arrange
            var expectedAmount = 100;
            var dto = new CountryCreateDto
            {
                Name = _objectFixture.Create<string>(),
                CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var expectedOwnedName = _objectFixture.Create<string>();
            var dto = new CountryCreateDto
            {
                Name = _objectFixture.Create<string>(),
                CountryLocalNames = new List<CountryLocalNameUpdateDto>() { new CountryLocalNameUpdateDto() { Name = expectedOwnedName } }
            };
            // Act
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
                Name = _objectFixture.Create<string>(),
                Population = 1
            };
            var updateDto = new CountryUpdateDto
            {
                Name = _objectFixture.Create<string>(),
                Population = expectedNumber
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);
            await PutAsync($"{CountryControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);
            await PutAsync($"{CountryControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);
            await PutAsync($"{CountryControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);
            await PatchAsync($"{CountryControllerName}/{result!.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.keyId}");

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
            var result = await PostAsync(CountryControllerName, createDto);

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
            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);
            await DeleteAsync($"{CountryControllerName}/{result!.keyId}");

            // Assert
            var queryResult = await GetAsync($"{CountryControllerName}/{result!.keyId}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact(Skip = "PostToCountryLocalNames is not found.The problem with routing. Route is found when it uses countries (without api prefix))")]
        public async Task PostToCountryLocalNames_ShouldAddToCountryLocalNames()
        {
            // Arrange
            var expectedLocalNameId = "10";
            var expectedLocalName = "local UA";

            var createDto = new CountryCreateDto
            {
                Name = "Ukraine",
                Population = 44000000
            };

            var localNameDto = new CountryLocalNameCreateDto
            {
                Id = expectedLocalNameId,
                Name = expectedLocalName
            };

            var result = await PostAsync<CountryCreateDto, CountryKeyDto>(CountryControllerName, createDto);

            //Act
            var ownedResult = await PostAsync<CountryLocalNameCreateDto, CountryLocalNameDto>($"{CountryControllerName}/PostToCountryLocalNames/{result!.keyId}", localNameDto);
             

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Id.Should().Be(expectedLocalNameId);
        }
    }
}