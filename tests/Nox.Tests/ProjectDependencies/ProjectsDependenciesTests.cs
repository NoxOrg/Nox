using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis;

namespace Nox.Tests.ProjectDependencies
{
    public class ProjectsDependenciesTests : IClassFixture<CodeAnalysisSolutionFixture>
    {
        private readonly CodeAnalysisSolutionFixture _fixture;

        public ProjectsDependenciesTests(CodeAnalysisSolutionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Nox_Types_Cannot_Reference_Projects()
        {
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxTypesProject.Id);
            projectDependencies.Should().BeEmpty();
            //_fixture.NoxTypesProject.ProjectReferences.Should().BeEmpty();
        }
        [Fact]
        public void Nox_Types_Cannot_Reference_ThirdParty_Packages()
        {
            using (new AssertionScope())
            {
                
                foreach (var metadataRef in _fixture.NoxTypesProject.MetadataReferences)
                {
                    var properties = metadataRef.Properties;
                    
                    if (properties.Kind == MetadataImageKind.Assembly)
                    {
                        var portableExecutableReference = ((PortableExecutableReference)metadataRef);
                        var fileName = Path.GetFileName(portableExecutableReference.FilePath);

                        fileName.Should().Match(filename =>
                            string.IsNullOrEmpty(filename)
                            || fileName!.StartsWith("Microsoft")
                            || fileName.StartsWith("System")
                            || fileName.StartsWith("mscorlib")
                            || fileName.StartsWith("netstandard"));
                    }
                }
            }

        }
        [Fact]
        public void Nox_Solution_References_Nox_Types_Only()
        {
            var projectDependenciesNoxSolutionNet7 = 
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolutionNet7.Id);
            var projectDependenciesNoxSolutionStd20 =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolutionNetStd20.Id);

            projectDependenciesNoxSolutionNet7.Should().HaveCount(1);
            projectDependenciesNoxSolutionStd20.Should().HaveCount(1);

            (projectDependenciesNoxSolutionNet7.Single() == _fixture.NoxTypesProject.Id).Should().BeTrue();
            (projectDependenciesNoxSolutionStd20.Single() == _fixture.NoxTypesProject.Id).Should().BeTrue();
        }

        [Fact]
        public void Nox_Generator_Depends_OnlyOn_Nox_Solution()
        {
            // This method is not deterministic and returns sometimes transitive projects dependencies
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxGenerator.Id);

            projectDependencies.Should().HaveCountLessOrEqualTo(2);
            projectDependencies.Should().Contain(_fixture.NoxSolutionNetStd20.Id);

            if (projectDependencies.Count() == 2)
            {
                projectDependencies.Should().Contain(_fixture.NoxTypesProject.Id);
            }

        }
    }
}