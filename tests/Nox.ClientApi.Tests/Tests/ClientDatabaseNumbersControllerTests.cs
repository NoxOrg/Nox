using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types;

namespace Nox.ClientApi.Tests.Tests
{
    [Collection("Sequential")]
    public class ClientDatabaseNumbersControllerTests
    {
        [Theory, AutoMoqData]
        public async void Post_ReturnsDatabaseNumberId(ApiFixture apiFixture)
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
        public async void Post_WithCompoundMoney_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        {
            // Arrange            
            var expectedAmount = 100;
            // Act 
            var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>) await apiFixture.ClientDatabaseNumbersController!.Post(
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
            queryResult!.ToDto().AmmountMoney!.Amount.Should().Be(expectedAmount);
        }

        //[Theory, AutoMoqData]
        //public async void Post_WithSingleOwnedEntity_ReturnsDatabaseNumberId(ApiFixture apiFixture)
        //{           
        //    // Arrange                    

        //    // Act 
        //    var result = (CreatedODataResult<ClientDatabaseNumberKeyDto>)await apiFixture.ClientDatabaseNumbersController!.Post(
        //        new ClientDatabaseNumberCreateDto
        //        {
        //            Name = apiFixture.Fixture.Create<string>(),
        //            OwnedEntity = new OwnedEntityUpdateDto() { Name = apiFixture.Fixture.Create<string>() }
        //        });

        //    var queryResult = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

        //    //Assert
        //    result.Should().NotBeNull();
        //    result.Should()
        //        .BeOfType<CreatedODataResult<ClientDatabaseNumberKeyDto>>()
        //        .Which.Entity.keyId.Should().BeGreaterThan(0);

        //    queryResult.Should().NotBeNull();
        //    //queryResult!.ToDto().OwnedEntity!.Amount.Should().Be(expectedAmount);
        //}

        [Theory, AutoMoqData]
        public async void Put_Number_ShouldUpdate(ApiFixture apiFixture)
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
            var queryResult  = await apiFixture.ClientDatabaseNumbersController!.Get(result.Entity.keyId);

            //Assert
            putResult.Should().NotBeNull();
            putResult.Should()
                .BeOfType<UpdatedODataResult<ClientDatabaseNumberKeyDto>>()
                .Which.Entity.keyId.Should().Be(result.Entity.keyId);

            queryResult.Should().NotBeNull();
            queryResult!.ToDto().Number.Should().Be(expectedNumber);
        }
        [Theory, AutoMoqData]
        public async void Patch_Number_ShouldUpdateNumberOnly(ApiFixture apiFixture)
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
            queryResult!.ToDto().Number.Should().Be(expectedNumber);
            queryResult!.ToDto().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async void Patch_UnsetNumber_ShouldUpdateNumberOnly(ApiFixture apiFixture)
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
            queryResult!.ToDto().Number.Should().BeNull();
            queryResult!.ToDto().Name.Should().Be(expectedName);
        }

        [Theory, AutoMoqData]
        public async void Post_IfNoRequireField_ThrowsException(ApiFixture apiFixture)
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


    }
}
