using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;

namespace ClientApi.Tests.Tests
{
    [Collection("Sequential")]
    public class GenerateODataEndPointHtmlRoutingTests : NoxIntegrationTestBase
    {
        [Fact]
        public async Task Generate_OdataRouting_HTML()
        {
            var result = await GetAsync("$odata");
            var content = await result.Content.ReadAsStringAsync();
                       
            File.WriteAllText("../../../odata.html", content);

            content.Should().NotBeEmpty();
        }
        [Fact]
        public async Task Generate_OdataMetadata()
        {
            var result = await GetAsync("api/$metadata");
            var content = await result.Content.ReadAsStringAsync();

            File.WriteAllText("../../../metadata.xml", content);

            content.Should().NotBeEmpty();
        }
    }
}
