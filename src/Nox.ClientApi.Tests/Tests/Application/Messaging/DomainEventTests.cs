using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using Xunit.Abstractions;
using ClientApi.Application.IntegrationEvents.StoreOwner;
using ClientApi.Application.IntegrationEvents;

namespace ClientApi.Tests.Application.Messaging
{
    [Collection("Sequential")]
    public class DomainEventTests : NoxWebApiTestBase
    {
        private const string StoreOwnersControllerName = "api/storeowners";
        private const string CountriesControllerName = "api/countries";

        public DomainEventTests(
            ITestOutputHelper testOutput,
           NoxTestContainerService containerService)
           : base(testOutput, containerService, true)
        {
        }

        #region Domain Events

        [Fact]
        public async Task Post_Country_DomainEvent_SendsIntegrationEvent()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 100_000_001,
            };

            // Act
            var result = await PostAsync<CountryCreateDto, CountryDto>(CountriesControllerName, createDto);

            //Assert
            result.Should().NotBeNull();

            (await MassTransitTestHarness.Published.Any<Nox.Messaging.NoxMessageRecord<CountryPopulationHigherThan100M>>()).Should().BeTrue();
        }

        #endregion Integration Events
    }
}