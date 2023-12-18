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
        public void Nox_Types_Abstractions_References_Nox_Yaml()
        {
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxTypesAbstractionsProject.Id);
            projectDependencies.Count.Should().Be(1);
        }

        [Fact]
        public void Nox_Types_Abstractions_Reference_Only_YamlDotNet()
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
                            || fileName!.StartsWith("YamlDotNet")
                            || fileName!.StartsWith("Microsoft")
                            || fileName.StartsWith("System")
                            || fileName.StartsWith("mscorlib")
                            || fileName.StartsWith("netstandard"));
                    }
                }
            }
        }


        [Fact]
        public void Nox_Generator_Depends_OnlyOn_Nox_Solution()
        {
            // This method is not deterministic and returns sometimes transitive projects dependencies
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxGenerator.Id);

            projectDependencies.Should().HaveCountLessOrEqualTo(3);
            projectDependencies.Should().Contain(_fixture.NoxSolution.Id);

            if (projectDependencies.Count == 3)
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
        public void NoxCore_References_Nox_Types_And_Solution_Only()
        {
            var projectDependencies =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectTransitivelyDependsOn(_fixture.NoxCore.Id);

            projectDependencies.Should().HaveCount(3);

            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesAbstractionsProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxYamlProject.Id.Id).Should().NotBeNull();
        }

        #region Nox.Solution
        [Fact]
        public void Nox_Solution_References_Nox_Types_Abstractions_Yaml_Only()
        {
            var projectDependenciesNoxSolution =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolution.Id);

            projectDependenciesNoxSolution.Should().HaveCount(2);

            projectDependenciesNoxSolution.Where(p => p == _fixture.NoxTypesAbstractionsProject.Id).Count().Should().Be(1);
            projectDependenciesNoxSolution.Where(p => p == _fixture.NoxYamlProject.Id).Count().Should().Be(1);
        }

        #endregion

        #region Nox.Yaml
        [Fact]
        public void Nox_Yaml_Should_Not_Reference_Any_Project()
        {
            var projectDependenciesNoxSolution =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxYamlProject.Id);

            projectDependenciesNoxSolution.Should().HaveCount(0);
        }
        #endregion
    }
}