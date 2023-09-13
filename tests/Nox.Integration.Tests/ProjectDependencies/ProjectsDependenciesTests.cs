using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.CodeAnalysis;
using Nox.Integration.Tests.ProjectDependencies;

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
        public void Nox_Types_Abstractions__Cannot_Reference_Projects()
        {
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxTypesAbstractionsProject.Id);
            projectDependencies.Should().BeEmpty();
            //_fixture.NoxTypesProject.ProjectReferences.Should().BeEmpty();
        }
        [Fact]
        public void Nox_Types_Abstractions_Cannot_Reference_ThirdParty_Packages()
        {
            using (new AssertionScope())
            {
                
                foreach (var metadataRef in _fixture.NoxTypesAbstractionsProject.MetadataReferences)
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
        public void Nox_Solution_References_Nox_Types_Abstractions_Only()
        {
            var projectDependenciesNoxSolutionNet7 = 
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolutionNet7.Id);
            var projectDependenciesNoxSolutionStd20 =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolutionNetStd20.Id);

            projectDependenciesNoxSolutionNet7.Should().HaveCount(1);
            projectDependenciesNoxSolutionStd20.Should().HaveCount(1);

            (projectDependenciesNoxSolutionNet7.Single() == _fixture.NoxTypesAbstractionsProject.Id).Should().BeTrue();
            (projectDependenciesNoxSolutionStd20.Single() == _fixture.NoxTypesAbstractionsProject.Id).Should().BeTrue();
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
                projectDependencies.Should().Contain(_fixture.NoxTypesAbstractionsProject.Id);
            }

        }
        [Fact]
        public void Nox_GeneratortProjectsThatDirectlyDependOnn_MustOnlyLib()
        {
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatDirectlyDependOnThisProject(_fixture.NoxGenerator.Id);

            using (new AssertionScope())
            {
                // No project should depend on the Generators, this brings issues generating the code
                // Only test projects
                foreach (var projectDependency in projectDependencies)
                {
                    var dependent = _fixture.Solution.Projects.Single(project => project.Id.Id == projectDependency.Id);
                    
                    if (!dependent.Name.Contains("Tests") && !dependent.Name.Contains("Nox.Lib"))
                    {
                        Assert.Fail($"Project {dependent.Name} cannot depend on Nox.Generators");
                    }
                }
            }
        }
        [Fact]
        public void Nox_Abstraction_References_Nox_Types_And_Solution_Only()
        {
            var projectDependencies =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxAbstractions.Id);

            projectDependencies.Should().HaveCount(2);

            projectDependencies.SingleOrDefault(d=> d.Id == _fixture.NoxTypesProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxSolutionNetStd20.Id.Id || d.Id == _fixture.NoxSolutionNet7.Id.Id).Should().NotBeNull();
        }
    }
}