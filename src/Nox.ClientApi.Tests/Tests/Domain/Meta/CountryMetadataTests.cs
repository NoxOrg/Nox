using Nox.Solution;
using Xunit.Abstractions;
using ClientApi.Domain;
using FluentAssertions;

namespace ClientApi.Tests.Domain.Meta
{
    [Collection("CountryMetadataTests")]
    public class CountryMetadataTests : NoxWebApiTestBase
    {
        public CountryMetadataTests(ITestOutputHelper testOutput,
            NoxTestContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        [Fact]
        public void CountryMetadata_ShouldHaveUserInterfaces()
        {
            //Arrange
            var rootPath = "../../../.nox";
            var noxSolution = new NoxSolutionBuilder()
                .UseYamlFile($"{rootPath}/design/clientapi.solution.nox.yaml")
                .Build();
            
            //Act
            var nameUserInterface = CountryMetadata.NameUserInterface(noxSolution);

            //Assert
            nameUserInterface.Should().NotBeNull();
            nameUserInterface!.CanSort.Should().BeTrue();
            nameUserInterface!.CanSearch.Should().BeTrue();
            nameUserInterface!.CanFilter.Should().BeTrue();
        }
    }
}
