using ClientApi.Application.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using Nox.ClientApp.Tests.FixtureConfig;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests
    {
        [Theory, AutoMoqData]
        public async Task Post_ReturnsNuidId(ApiFixture apiFixture)
        {
            // Arrange            
            string name = "MySpecialName";
            uint expectedId = 2519540169u;

            // Act 
            var result = await apiFixture.StoresController!.Post(
                new StoreCreateDto
                {
                    Name = name,
                    // TODO make email mandatory
                    //EmailAddress = new EmailAddressUpdateDto()
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<StoreKeyDto>>()
                .Which.Entity.keyId.Should().Be(expectedId);
        }

        [Theory, AutoMoqData]
        public async Task Post_OneToOnePointsToRealEntity(ApiFixture apiFixture)
        {
            // Arrange
            var name = "MySpecialName";
            var expectedId = 2519540169u;
            var storeOwnerName = "Will Smith";
            var storeOwnerId = "OW1";

            // Act 
            var result = await apiFixture.StoreOwnersController!.Post(
                new StoreOwnerCreateDto
                {
                    Name = storeOwnerName,
                    Id = storeOwnerId,
                });

            // Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<StoreOwnerKeyDto>>()
                .Which.Entity.keyId.Should().Be(storeOwnerId);

            // Act
            result = await apiFixture.StoresController!.Post(
                new StoreCreateDto
                {
                    Name = name,
                    StoreOwnerId = "OW1",
                    // TODO make email mandatory
                    //EmailAddress = new EmailAddressUpdateDto()
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<StoreKeyDto>>()
                .Which.Entity.keyId.Should().Be(expectedId);

            // Get Store data
            var value = ((CreatedODataResult<StoreKeyDto>)result).Value;
            var converterValue = (StoreKeyDto)value!;
            var getStoreResult = await apiFixture.StoresController!.Get(converterValue.keyId);

            // Get StoreOwner data
            var storeValue = (StoreDto)((OkObjectResult)getStoreResult.Result!).Value!;
            var getStoreOwnerResult = await apiFixture.StoreOwnersController!.Get(storeValue!.StoreOwnerId!);

            // Assert
            var storeOwner = (StoreOwnerDto)((OkObjectResult)getStoreOwnerResult.Result!).Value!;
            storeOwner!.Id.Should().BeEquivalentTo(storeOwnerId);
        }
    }
}
