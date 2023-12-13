using FluentAssertions;
using System.Text;
using System.Xml;
using Nox.Solution;
using Nox.Docs.Extensions;
using Xunit.Abstractions;

namespace ClientApi.Tests.ServiceMetadata
{
    [Collection("Sequential")]
    public class GenerateMetadataTests : NoxWebApiTestBase
    {
        public GenerateMetadataTests(
            ITestOutputHelper testOutputHelper,
            TestDatabaseContainerService containerService) : base(testOutputHelper, containerService)
        //For development purposes
        //TestDatabaseInstanceService containerService) : base(testOutputHelper, containerService)
        {
        }

        [Fact]
        public async Task Generate_OdataRouting_HTML()
        {
            var result = await GetAsync("$odata");
            var content = await result.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            File.WriteAllText("../../../Tests/ServiceMetadata/odata.html", content);
        }

        [Fact]
        public async Task Generate_OdataMetadata()
        {
            var result = await GetAsync("api/$metadata");
            var content = await result.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            File.WriteAllText("../../../Tests/ServiceMetadata/oDataMetadata.xml", BeautifyXml(content));
        }

        [Fact]
        public async Task Generate_Swagger_Html()
        {
            var result = await GetAsync("swagger/v1/swagger.json");
            var content = await result.Content.ReadAsStringAsync();

            content.Should().NotBeNull();
            File.WriteAllText("../../../Tests/ServiceMetadata/swagger.json", content);
        }

        [Fact]
        public void Generate_Readme()
        {
            var rootPath = "../../../.nox";

            var noxSolution = new NoxSolutionBuilder()
                .WithFile($"{rootPath}/design/clientapi.solution.nox.yaml")
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