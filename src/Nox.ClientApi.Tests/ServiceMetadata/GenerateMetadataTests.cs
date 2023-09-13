using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;
using ClientApi.Tests;

namespace ClientApi.ServiceMetadata
{
    [Collection("Sequential")]
    public class GenerateMetadataTests
    {
        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public GenerateMetadataTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        [Fact]
        public async Task Generate_OdataRouting_HTML()
        {
            var result = await _oDataFixture.GetAsync("$odata");
            var content = await result.Content.ReadAsStringAsync();

            File.WriteAllText("../../../ServiceMetadata/odata.html", content);
        }
        [Fact]
        public async Task Generate_OdataMetadata()
        {
            var result = await _oDataFixture.GetAsync("api/$metadata");
            var content = await result.Content.ReadAsStringAsync();

            File.WriteAllText("../../../ServiceMetadata/oDataMetadata.xml", content);
        }
        [Fact]
        public async Task Generate_Swagger_Html()
        {
            var result = await _oDataFixture.GetAsync("swagger/v1/swagger.json");
            var content = await result.Content.ReadAsStringAsync();

            File.WriteAllText("../../../ServiceMetadata/swagger.json", content);
        }
    }
}
