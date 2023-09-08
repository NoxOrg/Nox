using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;

namespace Nox.ClientApi.Tests.Tests
{
    [Collection("Sequential")]
    public class GenerateODataEndPointHtmlRoutingTests
    {
        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public GenerateODataEndPointHtmlRoutingTests()
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
                       
            File.WriteAllText("../../../odata.html", content);
        }
    }
}
