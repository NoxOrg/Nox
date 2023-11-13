using FluentAssertions;

namespace Nox.Solution.Tests.Models.Infrastructure.Endpoints
{
    public class EndPointsTests
    {
        [Fact]
        public void WhenNoEndPointOrVersionIsDefined_ShouldApplyDefaultsV1()
        {
            var solution = new NoxSolutionBuilder()
                .UseYamlFile("./files/x.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRootPrefix.Should().Be("/api/v1");
        }
        [Fact]
        public void WhenNoEndPointWithVersion2Defined_ShouldApplyDefaultsV2()
        {
            var solution = new NoxSolutionBuilder()
                .UseYamlFile("./files/endpoints.defaultversion2.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRootPrefix.Should().Be("/api/v2");
        }

        [Fact]
        public void WhenApiRootPrefixSet_ShouldReturnIt()
        {
            var solution = new NoxSolutionBuilder()
                .UseYamlFile("./files/endpoints.routeprefix.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRootPrefix.Should().Be("/testapi");
        }
        [Fact]
        public void WhenApiRootPrefixSet_ShouldSanitizeIt()
        {
            var solution = new NoxSolutionBuilder()
                .UseYamlFile("./files/endpoints.routeprefix.sanitized.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRootPrefix.Should().Be("/testapi");
        }
        [Fact]
        public void WhenApiRootNoPrefix_ShouldBeEmpty()
        {
            var solution = new NoxSolutionBuilder()
                .UseYamlFile("./files/endpoints.no.routeprefix.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRootPrefix.Should().BeEmpty("/");
        }
    }
}
