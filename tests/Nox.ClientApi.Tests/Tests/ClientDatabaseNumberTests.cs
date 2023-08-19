using FluentAssertions;
using Nox.ClientApp.Tests.FixtureConfig;
using ClientApi.Application.Dto;
using ClientApi.Presentation.Api.OData;
using Microsoft.AspNetCore.OData.Results;
using AutoFixture;

namespace Nox.ClientApi.Tests.Tests
{
    public class ClientDatabaseNumberTests
    {
        [Theory, AutoMoqData]
        public async void Post_ReturnsAutoNumberId(ApiFixture apiFixture)
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
    }
}
