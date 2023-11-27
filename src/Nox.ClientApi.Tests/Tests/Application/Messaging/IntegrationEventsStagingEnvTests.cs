using AutoFixture;
using FluentAssertions;
using MassTransit.Testing;
using Xunit.Abstractions;

using Nox.Infrastructure.Messaging;
using ClientApi.Tests.Controllers;
using ClientApi.Application.Dto;
using ClientApi.Application.IntegrationEvents;

namespace ClientApi.Tests.Application.Messaging
{
    [Collection("Sequential")]
    public class IntegrationEventsStagingEnvTests : NoxWebApiTestBase
    {        
        public IntegrationEventsStagingEnvTests(
            ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
           : base(testOutput, containerService, true, Environments.Staging) { }

        #region Integration Events Staging

        [Fact]
        public async Task Put_Country_WithDevelopmentEnvironment_SetsEnvelopValuesProperly()
        {
            // Arrange
            var createDto = new CountryCreateDto
            {
                Name = _fixture.Create<string>(),
                Population = 99_999_999,
            };

            var createResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

            var updateDto = new CountryUpdateDto
            {
                Name = createDto.Name,
                Population = 100_000_001,
            };

            // Act
            var headers = CreateEtagHeader(createResult!.Etag);
            var updateResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{createResult!.Id}", updateDto, headers);

            //Assert
            updateResult.Should().NotBeNull();
            var messageObject = MassTransitTestHarness.Published.Select(x => true).AsEnumerable().First().MessageObject;
            ((CloudEventMessage<CountryCreated>)messageObject).Source!.OriginalString.Should().Be("https://staging.Nox-Tests.com/ClientApi");
            ((CloudEventMessage<CountryCreated>)messageObject).Type.Should().Be("Nox-Tests.ClientApi.Country.v1.0.created");
            ((CloudEventMessage<CountryCreated>)messageObject).DataSchema!.OriginalString.Should().Be("https://staging.Nox-Tests.com/schemas/ClientApi/Country/v1.0/created.json");
        }

        #endregion Integration Events
    }
}