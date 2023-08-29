﻿using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Humanizer;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class CountriesControllerTests
    {
        [Theory, AutoMoqData]
        public async Task Post_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>()
                });
            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqData]
        public async Task Post_WithCompoundMoney_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedAmount = 100;
            // Act 
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
                });

            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().CountryDebt!.Amount.Should().Be(expectedAmount);
        }

        [Theory, AutoMoqData]
        public async Task Post_WithManyOwnedEntity_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange                    
            var expectedOwnedName = apiFixture.Fixture.Create<string>();
            // Act 
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryLocalNames = new List<CountryLocalNameDto>() { new CountryLocalNameDto() { Name = expectedOwnedName } }
                });

            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Single().Name.Should().Be(expectedOwnedName);
        }

        [Theory, AutoMoqData]
        public async Task Post_NameAndPopulation_ShouldPopulateShortDescription(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Portugal",
                    Population = 10350000,
                });

            //Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Theory, AutoMoqData]
        public async Task Put_Number_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 50;
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Population = 1
                });

            // Act 
            var putResult = await apiFixture.CountriesController!.Put(result.Entity.keyId,
                new CountryUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Population = expectedNumber
                });
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Population.Should().Be(expectedNumber);
        }

        [Theory, AutoMoqData]
        public async Task Put_Name_ShouldPopulateShortDescription(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Portugal123",
                    Population = 10350000,
                });

            // Act 
            var putResult = await apiFixture.CountriesController!.Put(result.Entity.keyId,
                new CountryUpdateDto
                {
                    Name = "Portugal",
                    Population = 10350000
                });

            //Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Theory, AutoMoqData]
        public async Task Put_Population_ShouldPopulateShortDescription(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Portugal",
                    Population = 1,
                });

            // Act 
            var putResult = await apiFixture.CountriesController!.Put(result.Entity.keyId,
                new CountryUpdateDto
                {
                    Name = "Portugal",
                    Population = 10350000
                });

            //Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Theory, AutoMoqData]
        public async Task Put_CountryLocalNames_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedName = apiFixture.Fixture.Create<string>();
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryLocalNames = new List<CountryLocalNameDto>() { new CountryLocalNameDto() { Name = apiFixture.Fixture.Create<string>() } }
                });

            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);
            var countryLocalNameToUpdate = queryResult.ExtractResult().CountryLocalNames.Single();

            // Act 
            var putResult = await apiFixture.CountriesController!.Put(result.Entity.keyId,
                new CountryUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryLocalNames = new List<CountryLocalNameDto>() { new CountryLocalNameDto() 
                        { 
                            Id = countryLocalNameToUpdate.Id,
                            Name = expectedName
                        } }
                });
            
            queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Single().Id.Should().Be(countryLocalNameToUpdate.Id);
            queryResult.ExtractResult().CountryLocalNames.Single().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async Task Patch_Number_ShouldUpdateNumberOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 50;
            var expectedName = "Portugal";
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = expectedName,
                    Population = 1
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(Country.Population), expectedNumber);

            var patchResult = await apiFixture.CountriesController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Population.Should().Be(expectedNumber);
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async Task Patch_UnsetNumber_ShouldUpdateNumberOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedName = "Portugal";
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = expectedName,
                    Population = 1
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(CountryCreateDto.Population), null);


            var patchResult = await apiFixture.CountriesController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<CountryKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Population.Should().BeNull();
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async Task Patch_Name_ShouldUpdateShortDescription(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Portugal123",
                    Population = 10350000
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(CountryCreateDto.Name), "Portugal");


            _ = await apiFixture.CountriesController!.Patch(result.Entity.keyId, updatedProperties);

            //Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);
            
            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Theory, AutoMoqData]
        public async Task Patch_Population_ShouldUpdateShortDescription(ApiFixture apiFixture)
        {
            // Arrange            
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Portugal",
                    Population = 1
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(CountryCreateDto.Population), 10350000);


            _ = await apiFixture.CountriesController!.Patch(result.Entity.keyId, updatedProperties);

            //Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
        }

        [Theory, AutoMoqData]
        public async Task Post_IfNoRequireField_ThrowsException(ApiFixture apiFixture)
        {

            // Arrange  
            Func<Task> action = () =>
            {
                return apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    //Name = null
                });
            };

            // Act 
            // Assert
            //await action.Should().ThrowAsync<ModelValidationException?>();
            //This is incorrect is getting to the insert command should fail model validation
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        [Theory, AutoMoqData]
        public async Task Deleted_ShouldPerformSoftDelete(ApiFixture apiFixture)
        {

            // Arrange  
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act
            await apiFixture.CountriesController.Delete(result.Entity.keyId);

            // Assert
            var queryResult = await apiFixture.CountriesController!.Get(result.Entity.keyId);

            (queryResult.Result as NotFoundResult)!.StatusCode.Should().Be(404);
            queryResult.Value.Should().BeNull();

            var context = apiFixture.ServiceProvider.GetService<ClientApiDbContext>()!;
            context.Countries.Find(DatabaseNumber.FromDatabase(result.Entity.keyId)).Should().NotBeNull();
        }

        [Theory, AutoMoqData]
        public async Task PostToCountryLocalNames_ShouldAddToCountryLocalNames(ApiFixture apiFixture)
        {
            // Arrange
            var expectedLocalName = "local UA";
            var result = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = "Ukraine",
                    Population = 44000000
                });

            //Act
            var ownedResult = (CreatedODataResult<CountryLocalNameDto>)await apiFixture.CountriesController!.PostToCountryLocalNames(
                result.Entity.keyId,
                new CountryLocalNameCreateDto
                {
                    //Id = expectedLocalNameId,
                    Name = expectedLocalName
                });

            //Assert
            ownedResult.Should().NotBeNull();
            ownedResult!.Entity.Id.Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqData]
        public async Task PutToCountryLocalNames_ShouldUpdateCountryLocalName(ApiFixture apiFixture)
        {
            // Arrange                    
            var expectedOwnedName = apiFixture.Fixture.Create<string>();
            // Act 
            var createResult = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryLocalNames = new List<CountryLocalNameDto>() { new CountryLocalNameDto() { Name = apiFixture.Fixture.Create<string>() } }
                });

            var queryResult = await apiFixture.CountriesController!.Get(createResult.Entity.keyId);
            var countryLocalNameToUpdate = queryResult.ExtractResult().CountryLocalNames.Single();

            var updatedResult = (UpdatedODataResult<CountryLocalNameDto>)await apiFixture.CountriesController!.PutToCountryLocalNames(
                createResult.Entity.keyId,
                new CountryLocalNameDto
                {
                    Id = countryLocalNameToUpdate.Id,
                    Name = expectedOwnedName
                });

            queryResult = await apiFixture.CountriesController!.Get(createResult.Entity.keyId);

            //Assert
            updatedResult.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Single().Id.Should().Be(countryLocalNameToUpdate.Id);
            queryResult.ExtractResult().CountryLocalNames.Single().Name.Should().Be(expectedOwnedName);
        }

        [Theory, AutoMoqData]
        public async Task PatchToCountryLocalNames_ShouldUpdateCountryLocalName(ApiFixture apiFixture)
        {
            // Arrange                    
            var expectedOwnedName = apiFixture.Fixture.Create<string>();
            // Act 
            var createResult = (CreatedODataResult<CountryKeyDto>)await apiFixture.CountriesController!.Post(
                new CountryCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    CountryLocalNames = new List<CountryLocalNameDto>() { new CountryLocalNameDto() { Name = apiFixture.Fixture.Create<string>() } }
                });

            var queryResult = await apiFixture.CountriesController!.Get(createResult.Entity.keyId);
            var countryLocalNameToUpdate = queryResult.ExtractResult().CountryLocalNames.Single();

            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<CountryLocalNameDto>();
            updatedProperties.TrySetPropertyValue(nameof(CountryLocalNameDto.Id), countryLocalNameToUpdate.Id);
            updatedProperties.TrySetPropertyValue(nameof(CountryLocalNameDto.Name), expectedOwnedName);

            var patchResult = await apiFixture.CountriesController!.PatchToCountryLocalNames(createResult.Entity.keyId, updatedProperties);
            queryResult = await apiFixture.CountriesController!.Get(createResult.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Should().NotBeNull();
            queryResult.ExtractResult().CountryLocalNames.Single().Id.Should().Be(countryLocalNameToUpdate.Id);
            queryResult.ExtractResult().CountryLocalNames.Single().Name.Should().Be(expectedOwnedName);
        }
    }
}
