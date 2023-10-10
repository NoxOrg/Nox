using AutoFixture;
using ClientApi.Application.Dto;
using ClientApi.Application.IntegrationEvents;
using ClientApi.Application.IntegrationEvents.StoreOwner;
using FluentAssertions;
using MassTransit.Testing;
using Nox.Messaging;
using Nox.Types;
using Xunit.Abstractions;

namespace ClientApi.Tests.Application.Messaging
{
    [Collection("Sequential")]
    public class IntegrationEventsTests : NoxWebApiTestBase
    {
        private const string StoreOwnersControllerName = "api/storeowners";
        private const string CountriesControllerName = "api/countries";
        private const string WorkplacesControllerName = "api/workplaces";

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
                TemporaryOwnerName = "unknow",
                VatNumber = new VatNumberDto(expectedVatNumber, CountryCode.PT)
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersControllerName, createDto);

            //Assert
            result.Should().NotBeNull();

            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<UnknowStoreOwnerCreated>>()).Should().BeTrue();
        }

        [Fact]
        public async Task Post_Country_SendsIntegrationEvents()
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

            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryCreated>>()).Should().BeTrue();
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryPopulationHigherThan100M>>()).Should().BeTrue();
        }

        [Fact]
        public async Task Put_Country_SendsIntegrationEvents()
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

            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryCreated>>()).Should().BeTrue();
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryUpdated>>()).Should().BeTrue();
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryPopulationHigherThan100M>>()).Should().BeTrue();
        }

        [Fact]
        public async Task Delete_Country_SendsIntegrationEvents()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 99_999_999,
            };

            var createResult = await PostAsync<CountryCreateDto, CountryDto>(CountriesControllerName, createDto);

            // Act
            var headers = CreateEtagHeader(createResult?.Etag);
            var deleteResult = await DeleteAsync($"{CountriesControllerName}/{createResult!.Id}", headers);

            //Assert
            deleteResult.Should().NotBeNull();

            // TODO: extend with event count so no additional events are sent, right now failing due to events from other test cases
            //MassTransitTestHarness.Published.Count().Should().Be(2);
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryCreated>>()).Should().BeTrue();
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<CountryUpdated>>()).Should().BeTrue(); // Because we are changing the EntityState from Deleted to Modified for auditable entities and thus updated event is raised
        }

        [Fact]
        public async Task Delete_Workplace_SendsIntegrationEvents()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var createResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(WorkplacesControllerName, createDto);

            // Act
            var headers = CreateEtagHeader(createResult?.Etag);
            var deleteResult = await DeleteAsync($"{WorkplacesControllerName}/{createResult!.Id}", headers);

            //Assert
            deleteResult.Should().NotBeNull();

            // TODO: extend with event count so no additional events are sent, right now failing due to events from other test cases
            //MassTransitTestHarness.Published.Count().Should().Be(1);
            (await MassTransitTestHarness.Published.Any<NoxMessageRecord<WorkplaceDeleted>>()).Should().BeTrue();
        }

        [Fact]
        public async Task Put_Country_SetsMessageValuesProperly()
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

            var messageObject = MassTransitTestHarness.Published.Select(x => true).AsEnumerable().First().MessageObject;
            ((NoxMessageRecord<CountryCreated>)messageObject).source!.OriginalString.Should().Be("https://Nox-Tests.com/ClientApi");
            ((NoxMessageRecord<CountryCreated>)messageObject).type.Should().Be("Nox-Tests.ClientApi.Country.v1.0.Created");
            ((NoxMessageRecord<CountryCreated>)messageObject).dataschema!.OriginalString.Should().Be("https://Nox-Tests.com/schemas/ClientApi/Country/v1.0/Created.json");
        }

        #endregion Integration Events
    }
}