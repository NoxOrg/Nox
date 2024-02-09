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
        public void Nox_GeneratorProjectsThatDirectlyDependOn_MustOnlyBeLib()
        {
            var projectDependencies = _fixture.ProjectDependencyGraph.GetProjectsThatDirectlyDependOnThisProject(_fixture.NoxGenerator.Id);

            using (new AssertionScope())
            {
                // No project should depend on the Generators, this brings issues generating the
                // code Only test projects
                foreach (var projectDependency in projectDependencies)
                {
                    var dependent = _fixture.Solution.Projects.Single(project => project.Id.Id == projectDependency.Id);

                    if (!dependent.Name.Contains("Tests") && !dependent.Name.Contains("Nox.Lib") && !dependent.Name.Contains("Nox.Generator.Tasks"))
                    {
                        Assert.Fail($"Project {dependent.Name} cannot depend on Nox.Generators");
                    }
                }
            }
        }

        #region Nox.Solution

        [Fact]
        public void Nox_Solution_References_Nox_Types_Abstractions_Yaml_Only()
        {
            var projectDependencies =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxSolution.Id);

            projectDependencies.Should().HaveCount(2);

            projectDependencies.Count(p => p == _fixture.NoxTypesAbstractionsProject.Id).Should().Be(1);
            projectDependencies.Count(p => p == _fixture.NoxYamlProject.Id).Should().Be(1);
        }

        #endregion Nox.Solution

        #region Nox.Yaml

        [Fact]
        public void Nox_Yaml_Should_Not_Reference_Any_Project()
        {
            var projectDependenciesNoxSolution =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxYamlProject.Id);

            projectDependenciesNoxSolution.Should().HaveCount(0);
        }

        #endregion Nox.Yaml

        #region Nox.Types.Extensions

        [Fact]
        public void Nox_Types_Extensions_Should_Reference_Nox_Types_Only()
        {
            var projectDependencies =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxTypesExtensionsProject.Id);

            projectDependencies.Should().HaveCount(3);

            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesAbstractionsProject.Id.Id).Should().NotBeNull();
            //Nox.Yaml
        }

        #endregion Nox.Types.Extensions

        #region Nox.UI.Blazor.Lib
        [Fact]
        public void Nox_UI_Blazor_Lib_Should_Reference_Nox_Types_Only()
        {
            var projectDependencies =
                _fixture.ProjectDependencyGraph.GetProjectsThatThisProjectDirectlyDependsOn(_fixture.NoxUIBlazorProject.Id);

            projectDependencies.Should().HaveCount(4,"Nox UI Blazor Lib is C# component used by a generated Blazor Client UI, and can only reference and use Nox.Types. " +
                "Can not reference Nox.Core, for example, since does not run a instance of Service API, but only consumes it");

            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesAbstractionsProject.Id.Id).Should().NotBeNull();
            projectDependencies.SingleOrDefault(d => d.Id == _fixture.NoxTypesExtensionsProject.Id.Id).Should().NotBeNull();
            //Nox.Yaml

        }
        #endregion
    }
}