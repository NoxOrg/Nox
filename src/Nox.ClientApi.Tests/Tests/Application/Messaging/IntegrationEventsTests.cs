using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using Xunit.Abstractions;
using ClientApi.Application.IntegrationEvents.StoreOwner;
using Xunit.Sdk;

namespace ClientApi.Tests.Application.Messaging
{
    [Collection("Sequential")]
    public class IntegrationEventsTests : NoxWebApiTestBase
    {
        private const string StoreOwnersControllerName = "api/storeowners";

        public IntegrationEventsTests(
            ITestOutputHelper testOutput,
           NoxTestContainerService containerService)
           : base(testOutput, containerService, true)
        {
        }

        #region Integration Events

        [Fact]
        public async Task Post_StoreOwner_SendsCustomIntegrationEvent()
        {
            // Arrange
            var expectedVatNumber = "515714941";
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                VatNumber = new VatNumberDto(expectedVatNumber, CountryCode.PT)
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersControllerName, createDto);

            //Assert
            result.Should().NotBeNull();

            (await MassTransitTestHarness.Published.Any<Nox.Messaging.NoxMessageRecord<CustomStoreOwnerCreated>>()).Should().BeTrue();
        }

        #endregion Integration Events
    }
}