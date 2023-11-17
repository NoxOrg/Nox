using FluentAssertions;

namespace Nox.Solution.Tests.Models.Infrastructure.Endpoints
{
    public class EndPointsTests
    {
        [Fact]
        public void WhenNoEndPointOrVersionIsDefined_ShouldApplyDefaultsV1()
        {
            var solution = new NoxSolution();
            var endPoints = solution.Infrastructure.Endpoints;

            endPoints.SetDefaults(solution, solution.Infrastructure, string.Empty);

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("/api/v1");
        }

        [Fact]
        public void WhenNoEndPointWithVersion2Defined_ShouldApplyDefaultsV2()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/endpoints.defaultversion2.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("/api/v2");
        }

        [Fact]
        public void WhenApiRoutePrefixSet_ShouldReturnIt()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/endpoints.routeprefix.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("/testapi");
        }
        [Fact]
        public void WhenApiRoutePrefixSet_ShouldSanitizeIt()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/endpoints.routeprefix.sanitized.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("/testapi");
        }
        [Fact]
        public void WhenApiRoutePrefixRoot_ShouldBeRoot()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/endpoints.root.routeprefix.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("");
        }

        [Fact]
        public void WhenApiRouteNoPrefix_ShouldBeDefault()
        {
            var solution = new NoxSolutionBuilder()
                .WithFile("./files/endpoints.no.routeprefix.solution.nox.yaml")
                .AllowMissingSolutionYaml()
                .Build();

            solution.Infrastructure.Endpoints.Should().NotBeNull();
            solution.Infrastructure.Endpoints.ApiRoutePrefix.Should().Be("/api/v1");
        }

        [Theory]
        [InlineData("", "1.0", "/api/v1")]
        [InlineData("", "2.0", "/api/v2")]
        [InlineData("/api", "2.0", "/api")]
        [InlineData("/api/v3", "2.0", "/api/v3")]
        [InlineData("/", "2", "")]
        public void WhenApiRoute_ShouldExpect(string configuration, string version, string expected)
        {
            // Arrange
            var solution = new NoxSolution() { Version = version };
            var endPoints = solution.Infrastructure.Endpoints;
            endPoints.ApiRoutePrefix = configuration;

            // Act
            endPoints.SetDefaults(solution,solution.Infrastructure,string.Empty);

            // Assert
            endPoints.ApiRoutePrefix.Should().Be(expected);
        }
    }
}
