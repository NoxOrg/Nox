﻿using FluentAssertions;
using ClientApi.Application.Dto;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class ReferenceNumberTests : NoxWebApiTestBase
    {
        public ReferenceNumberTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }
        [Fact]
        public async Task WhenEntityCreated_ShouldCreateReferenceNumber()
        {
            //Act
            var postResult = await PostAsync<ReferenceNumberEntityCreateDto, ReferenceNumberEntityDto>(Endpoints.ReferenceNumberUrl, new());
            var postResult2 = await PostAsync<ReferenceNumberEntityCreateDto, ReferenceNumberEntityDto>(Endpoints.ReferenceNumberUrl, new());

            //Assert
            postResult!.ReferenceNumber.Should().Be("RN-109");
            postResult2!.ReferenceNumber.Should().Be("RN-158");

            postResult!.Id.Should().Be("ID-109");
            postResult2!.Id.Should().Be("ID-158");
        }
    }
}