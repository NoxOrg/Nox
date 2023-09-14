using FluentAssertions;
using AutoFixture;
using AutoFixture.AutoMoq;
using System.Text;
using System.Xml;
using Nox.Solution;
using Nox.Docs.Extensions;

namespace ClientApi.Tests.Tests
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

            content.Should().NotBeNull();
            File.WriteAllText("../../../odata.html", BeautifyXml(content));
        }

        [Fact]
        public async Task Generate_OdataMetadata()
        {
            var result = await _oDataFixture.GetAsync("api/$metadata");
            var content = await result.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            File.WriteAllText("../../../metadata.xml", BeautifyXml(content));
        }

        [Fact]
        public void Generate_Readme()
        {
            var rootPath = "../../../.nox";

            var noxSolution = new NoxSolutionBuilder()
                .UseYamlFile($"{rootPath}/design/clientapi.solution.nox.yaml")
                .Build();

            var action = () => noxSolution.GenerateMarkdownReadme($"{rootPath}/docs");

            action.Should().NotThrow();
        }

        public static string BeautifyXml(string xmlString)
            => new XmlBeautifier().Beautify(xmlString);

        public class XmlBeautifier
        {
            private static readonly XmlWriterSettings _settings = new()
            {
                Indent = true,        // Enable indentation
                IndentChars = "    ", // Set the indentation characters (four spaces)
                NewLineChars = "\r\n" // Set the newline characters (carriage return + line feed)
            };

            public string Beautify(string xmlString)
            {
                try
                {
                    var xmlDoc = ReadXml(xmlString);
                    return BeautifyXmlDoc(xmlDoc);
                }
                catch (Exception)
                {
                    return xmlString;
                }
            }

            private static string BeautifyXmlDoc(XmlDocument xmlDoc)
            {
                var text = new StringBuilder();

                var writer = XmlWriter.Create(text, _settings);
                xmlDoc.Save(writer);

                return text.ToString();
            }

            private static XmlDocument ReadXml(string xmlString)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);

                return xmlDoc;
            }
        }
    }
}
