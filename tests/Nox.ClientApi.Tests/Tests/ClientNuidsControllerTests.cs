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
    public class ClientNuidsControllerTests
    {
        [Theory, AutoMoqData]
        public async void Post_ReturnsNuidId(ApiFixture apiFixture)
        {
            // Arrange            
            string name = "MySpecialName";
            uint expectedId = 2374505856;

            // Act 
            var result = await apiFixture.ClientNuidsController!.Post(
                new ClientNuidCreateDto
                {
                    Name = name
                });

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<CreatedODataResult<ClientNuidKeyDto>>()
                .Which.Entity.keyId.Should().Be(expectedId);
        }
       
    }
}
