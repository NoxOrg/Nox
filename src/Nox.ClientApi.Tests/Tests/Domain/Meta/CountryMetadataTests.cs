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
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        [Fact]
        public void CountryMetadata_ShouldHaveUiOptions()
        {
            //Arrange
            var rootPath = "../../../.nox";
            var noxSolution = new NoxSolutionBuilder()
                .WithFile($"{rootPath}/design/clientapi.solution.nox.yaml")
                .Build();
            
            //Act
            var nameUiOptions = CountryMetadata.NameUiOptions(noxSolution);

            //Assert
            nameUiOptions.Should().NotBeNull();
            nameUiOptions!.CanSort.Should().BeTrue();
            nameUiOptions!.CanSearch.Should().BeTrue();
            nameUiOptions!.CanFilter.Should().BeTrue();
        }
    }
}
