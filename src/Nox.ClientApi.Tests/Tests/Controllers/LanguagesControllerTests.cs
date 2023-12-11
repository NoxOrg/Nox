using AutoFixture;
using ClientApi.Application.Dto;
using ClientApi.Tests.Controllers;
using FluentAssertions;
using FluentAssertions.Common;
using Nox.Application.Dto;
using Nox.Types;
using System.Drawing;
using System.Net;
using Xunit.Abstractions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class LanguagesControllerTests : NoxWebApiTestBase
    {
        private readonly EndPointsFixture _endPointFixture;
        public LanguagesControllerTests(ITestOutputHelper testOutput,

            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
            //TODO receive it on the constructor
            _endPointFixture = new EndPointsFixture(nameof(ClientApi.Domain.Language));
        }

        [Fact]
        public async Task WhenGetAll_ShouldSucceed()
        {
            var postResponse = await PostAsync<LanguageCreateDto, LanguageDto>(Endpoints.LanguagesUrl, new LanguageCreateDto
            {
                Id = CountryCode.US.ToString(),
                Name = _fixture.Create<string>(),
                Region = _fixture.Create<string>()
            });

            var getResponse = await GetODataCollectionResponseAsync<IEnumerable<LanguageDto>>(Endpoints.LanguagesUrl);

            getResponse.Should().NotBeEmpty();
        }

        [Fact]
        public async Task WhenGetSelectQuery_ShouldSucceed()
        {
            //Arrange
            var expectedName = _fixture.Create<string>();
            var postResponse = await PostAsync<LanguageCreateDto, LanguageDto>(Endpoints.LanguagesUrl, new LanguageCreateDto
            {
                Id = CountryCode.US.ToString(),
                Name = expectedName,
                Region = _fixture.Create<string>()
            });

            //Act
            const string oDataRequest = "$select=Name";
            var getResponse = await GetODataCollectionResponseAsync<IEnumerable<LanguageDto>>($"{Endpoints.LanguagesUrl}/?{oDataRequest}");

            //Assert
            getResponse.Should().NotBeNullOrEmpty();
            getResponse!.Should().HaveCount(1);
            getResponse!.First().Name.Should().Be(expectedName);

        }
    }
}