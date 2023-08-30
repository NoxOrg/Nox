using FluentAssertions;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Nox.Types;
using ClientApi.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CountriesControllerTests : NoxIntgrationTestBase
    {
        private const string CountryControllerName = "countries";

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
            var result = await PostAsync(CountryControllerName,dto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);
        }

        [Fact]
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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();

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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, dto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);
            var putResult = await PutAsync<CountryUpdateDto, UpdatedODataResult<CountryKeyDto>>($"{CountryControllerName}/{result!.Entity.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
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
            var updateDto = new CountryCreateDto
            {
                Name = "Portugal",
                Population = 10350000
            };

            // Act 
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);
            await PutAsync<CountryUpdateDto, UpdatedODataResult<CountryKeyDto>>($"{CountryControllerName}/{result!.Entity.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            queryResult.Should().NotBeNull();
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
            var updateDto = new CountryCreateDto
            {
                Population = 10350000
            };
            // Act 
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);
            await PutAsync<CountryUpdateDto, UpdatedODataResult<CountryKeyDto>>($"{CountryControllerName}/{result!.Entity.keyId}", updateDto);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            queryResult.Should().NotBeNull();
            queryResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
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
            // Act 
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);

            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(Country.Population), expectedNumber);

            var patchResult = await PatchAsync<CountryUpdateDto, UpdatedODataResult<CountryKeyDto>>($"{CountryControllerName}/{result!.Entity.keyId}", updatedProperties);
            var queryResult = await GetAsync<CountryDto>($"{CountryControllerName}/{result!.Entity.keyId}");

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);

            result.Should().BeOfType<BadRequest>();
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
            var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);
            await DeleteAsync($"{CountryControllerName}/{result!.Entity.keyId}");

            // Assert
            var queryResult = await GetAsync($"{CountryControllerName}/{result!.Entity.keyId}");

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        /* 
        //TODO: Add endpont invocation PostToCountryLocalNames
        [Fact]
        public async Task PostToCountryLocalNames_ShouldAddToCountryLocalNames(ApiFixture apiFixture)
        {
            //// Arrange
            //var expectedLocalNameId = "10";
            //var expectedLocalName = "local UA";

            //var createDto = new CountryCreateDto
            //{
            //    Name = "Ukraine",
            //    Population = 44000000
            //};

            //var result = await PostAsync<CountryCreateDto, CreatedODataResult<CountryKeyDto>>(CountryControllerName, createDto);

            //Act
            //var ownedResult = (CreatedODataResult<CountryLocalNameDto>)await apiFixture.CountriesController!.PostToCountryLocalNames(
            //    result.Entity.keyId,
            //    new CountryLocalNameCreateDto
            //    {
            //        Id = expectedLocalNameId,
            //        Name = expectedLocalName
            //    });

            ////Assert
            //ownedResult.Should().NotBeNull();
            //ownedResult!.Entity.Id.Should().Be(expectedLocalNameId);
        }*/
    }
}
