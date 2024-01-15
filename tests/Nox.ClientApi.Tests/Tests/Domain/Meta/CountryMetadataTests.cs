using Nox.Solution;
using Xunit.Abstractions;
using FluentAssertions;
using ClientApi.Application.Dto;
using Nox;

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
            var nameUiOptions = CountryMetadata.NameUiOptions;

            //Assert
            nameUiOptions.Should().NotBeNull();
            nameUiOptions!.Label.Should().Be("Country Name");
            nameUiOptions!.CanSort.Should().BeTrue();
            nameUiOptions!.CanSearch.Should().BeFalse();
            nameUiOptions!.CanFilter.Should().BeTrue();
            nameUiOptions!.ShowOnCreateForm.Should().BeTrue();
            nameUiOptions!.ShowOnUpdateForm.Should().BeFalse();
            nameUiOptions!.ShowInSearchResults.Should().Be(ShowInSearchResultsOption.OptionalAndOnByDefault);
            nameUiOptions!.IconPosition.Should().Be(IconPosition.Begin);
            nameUiOptions!.InputOrder.Should().Be(0);
            nameUiOptions.Widget.Should().BeNull();
            nameUiOptions!.Icon.Should().BeNull();
            nameUiOptions!.InputMask.Should().BeNull();
            nameUiOptions!.OutputMask.Should().BeNull();
            nameUiOptions!.Regex.Should().BeNull();
            nameUiOptions!.PageGroup.Should().BeNull();
            nameUiOptions!.FieldGroup.Should().BeNull();
            nameUiOptions!.HelpHint.Should().BeNull();
            nameUiOptions!.ErrorMessage.Should().BeNull();
        }
    }
}
