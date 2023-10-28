using AutoFixture;
using ClientApi.Application.Dto;
using ClientApi.Application.IntegrationEvents;
using FluentAssertions;
using MassTransit.Testing;
using Nox.Infrastructure.Messaging;
using Xunit.Abstractions;

namespace ClientApi.Tests.Application.Messaging
{
    [Collection("Sequential")]
    public class IntegrationEventsStagingEnvTests : NoxWebApiTestBase
    {
        private const string CountriesControllerName = "api/countries";

        public IntegrationEventsStagingEnvTests(
            ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
           : base(testOutput, containerService, true, Environments.Staging) { }

        #region Integration Events Staging

        [Fact(Skip ="Cloud event is being create in serialization phase, need to investigate how to assert the serialization")]
        public async Task Put_Country_WithDevelopmentEnvironment_SetsEnvelopValuesProperly()
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
            //((NoxMessageRecord<CountryCreated>)messageObject).source!.OriginalString.Should().Be("https://staging.Nox-Tests.com/ClientApi");
            //((NoxMessageRecord<CountryCreated>)messageObject).type.Should().Be("Nox-Tests.ClientApi.Country.v1.0.created");
            //((NoxMessageRecord<CountryCreated>)messageObject).dataschema!.OriginalString.Should().Be("https://staging.Nox-Tests.com/schemas/ClientApi/Country/v1.0/created.json");
        }

        #endregion Integration Events
    }
}