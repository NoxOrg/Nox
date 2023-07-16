using FluentAssertions;

namespace Nox.Solution.Tests;

public class IntegrationTests
{
    [Fact]
    public void Valid_Integration_Definition_is_deserialized()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/valid-integration.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig.Application);
        Assert.NotNull(noxConfig.Application.Integrations);
        Assert.NotNull(noxConfig.Infrastructure);
        Assert.NotNull(noxConfig.Infrastructure.Persistence);
        Assert.NotNull(noxConfig.Infrastructure.Persistence.IntegrationDatabaseServer);
    }

    [Fact]
    public void Missing_Integration_database_throws()
    {
        var noxConfig = new NoxSolutionBuilder().UseYamlFile("./files/missing-integration-server.solution.nox.yaml");

        noxConfig
            .Invoking(solution => solution.Build())
            .Should().Throw<FluentValidation.ValidationException>();   
    }
}