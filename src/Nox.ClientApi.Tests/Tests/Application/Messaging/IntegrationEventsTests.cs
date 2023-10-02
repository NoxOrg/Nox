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
    public class IntegrationEventsTests : NoxWebApiTestBase
    {
        private const string StoreOwnersControllerName = "api/storeowners";
        private const string CountriesControllerName = "api/countries";

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

        [Fact]
        public async Task Post_Country_SendsCustomIntegrationEvent()
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

        [Fact]
        public async Task Put_Country_SendsCustomIntegrationEvent()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 99_999_999,
            };

            var createResult = await PostAsync<CountryCreateDto, CountryDto>(CountriesControllerName, createDto);

            var updateDto = new CountryUpdateDto
            {
                Name = createDto.Name,
                Population = 100_000_001,
            };

            // Act
            var headers = CreateEtagHeader(createResult?.Etag);
            var updateResult = await PutAsync<CountryUpdateDto, CountryDto>($"{CountriesControllerName}/{createResult!.Id}", updateDto, headers);

            //Assert
            updateResult.Should().NotBeNull();

            (await MassTransitTestHarness.Published.Any<Nox.Messaging.NoxMessageRecord<CountryPopulationHigherThan100M>>()).Should().BeTrue();
        }

        #endregion Integration Events
    }
}