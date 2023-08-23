using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class ClientDatabaseNumbersControllerTests
    {
        [Theory, AutoMoqData]
        public async Task Post_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange            

            // Act 
            var result = await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>()
                });
            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);
        }

        [Theory, AutoMoqData]
        public async Task Post_WithCompoundMoney_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedAmount = 100;
            // Act 
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    AmmountMoney = new MoneyDto(expectedAmount, CurrencyCode.AED)
                });

            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().AmmountMoney!.Amount.Should().Be(expectedAmount);
        }

        [Theory, AutoMoqData]
        public async Task Post_WithManyOwnedEntity_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange                    
            var expectedOwnedName = apiFixture.Fixture.Create<string>();
            // Act 
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    OwnedEntities = new List<OwnedEntityUpdateDto>() { new OwnedEntityUpdateDto() { Name = expectedOwnedName } }
                });

            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().BeGreaterThan(0);

            queryResult.Should().NotBeNull();

            // TODO: add odata controller to test include properly
            //queryResult!.ToDto().OwnedEntities!.Single().Name.Should().Be(expectedOwnedName);
        }

        [Theory, AutoMoqData]
        public async Task Put_Number_ShouldUpdate(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 50;
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Number = 1
                });

            // Act 
            var putResult = await apiFixture.ClientDatabaseNumbersController!.Put(result.Entity.keyId,
                new ClientDatabaseNumberUpdateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                    Number = expectedNumber
                });
            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Number.Should().Be(expectedNumber);
        }        

        [Theory, AutoMoqData]
        public async Task Patch_Number_ShouldUpdateNumberOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedNumber = 50;
            var expectedName = apiFixture.Fixture.Create<string>();
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = expectedName,
                    Number = 1
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<ClientDatabaseNumberUpdateDto>();
            updatedProperties.TrySetPropertyValue("Number", expectedNumber);

            var patchResult = await apiFixture.ClientDatabaseNumbersController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Number.Should().Be(expectedNumber);
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async Task Patch_UnsetNumber_ShouldUpdateNumberOnly(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedName = apiFixture.Fixture.Create<string>();
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = expectedName,
                    Number = 1
                });

            // Act 
            var updatedProperties = new Microsoft.AspNetCore.OData.Deltas.Delta<ClientDatabaseNumberUpdateDto>();
            updatedProperties.TrySetPropertyValue(nameof(ClientDatabaseNumberCreateDto.Number), null);


            var patchResult = await apiFixture.ClientDatabaseNumbersController!.Patch(result.Entity.keyId, updatedProperties);
            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ExtractResult().Number.Should().BeNull();
            queryResult!.ExtractResult().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async Task Post_IfNoRequireField_ThrowsException(ApiFixture apiFixture)
        {

            // Arrange  
            Func<Task> action = () =>
            {
                return apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    //Name = null
                });
            };

            // Act 
            // Assert
            //await action.Should().ThrowAsync<ModelValidationException?>();
            //This is incorrect is getting to the insert command should fail model validation
            await action.Should().ThrowAsync<Microsoft.EntityFrameworkCore.DbUpdateException>();
        }

        [Theory, AutoMoqData]
        public async Task Deleted_ShouldPerformSoftDelete(ApiFixture apiFixture)
        {

            // Arrange  
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
                new ClientDatabaseNumberCreateDto
                {
                    Name = apiFixture.Fixture.Create<string>(),
                });

            // Act
            await apiFixture.ClientDatabaseNumbersController.Delete(result.Entity.keyId);

            // Assert
            var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            (queryResult.Result as NotFoundResult)!.StatusCode.Should().Be(404);
            queryResult.Value.Should().BeNull();

            var context = apiFixture.ServiceProvider.GetService<ClientApiDbContext>()!;
            context.ClientDatabaseNumbers.Find(DatabaseNumber.FromDatabase(result.Entity.keyId)).Should().NotBeNull();
        }
    }
}
