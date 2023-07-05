using FluentAssertions;

namespace Nox.Tests
{
    public class ProjectsDependenciesTests: IClassFixture<CodeAnalysisSolutionFixture>
    {
        private readonly CodeAnalysisSolutionFixture _fixture;

        public ProjectsDependenciesTests(CodeAnalysisSolutionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Nox_Types_Cannot_Reference_Projects()
        {
            _fixture.NoxTypesProject.ProjectReferences.Should().BeEmpty();
        }
        [Fact]
        public void Nox_Types__References_Nox_Types_Only()
        {
            _fixture.NoxSolutionNet7.ProjectReferences.Count().Should().Be(1);
            _fixture.NoxSolutionNetStd20.ProjectReferences.Count().Should().Be(1);

            (_fixture.NoxSolutionNet7.ProjectReferences.Single().ProjectId == _fixture.NoxTypesProject.Id).Should().BeTrue();
            (_fixture.NoxSolutionNetStd20.ProjectReferences.Single().ProjectId == _fixture.NoxTypesProject.Id).Should().BeTrue();
        }
    }
}