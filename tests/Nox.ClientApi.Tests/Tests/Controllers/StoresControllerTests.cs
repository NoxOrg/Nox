using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Types;

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
                    Name = name
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<StoreKeyDto>>()
                .Which.Entity.keyId.Should().Be(expectedId);
        }

    }
}
