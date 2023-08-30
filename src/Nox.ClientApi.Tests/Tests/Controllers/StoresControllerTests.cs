using FluentAssertions;
using ClientApi.Application.Dto;
using Microsoft.AspNetCore.OData.Results;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoresControllerTests : NoxIntgrationTestBase
    {
        private const string StoresControllerName = "stores";

        public StoresControllerTests(NoxTestApplicationFactory<StartupFixture> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Post_ReturnsNuidId()
        {
            // Arrange            
            string name = "MySpecialName";
            uint expectedId = 2519540169u;

            var createDto = new StoreCreateDto
            {
                Name = name,
                // TODO make email mandatory
                //EmailAddress = new EmailAddressUpdateDto()
            };

            // Act 
            var result = await PostAsync<StoreCreateDto, CreatedODataResult<StoreKeyDto>>(StoresControllerName, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<StoreKeyDto>>()
                .Which.Entity.keyId.Should().Be(expectedId);
        }

    }
}
