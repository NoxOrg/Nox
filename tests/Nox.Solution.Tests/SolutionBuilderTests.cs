using Nox.Solution.Exceptions;

namespace Nox.Solution.Tests;

public class SolutionBuilderTests
{
    [Fact]
    public void Can_create_solution_from_set_yaml_file()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/minimal.solution.nox.yaml")
            .Build();
        Assert.NotNull(noxConfig);
        Assert.NotNull(noxConfig);
        Assert.Equal("MinimalService", noxConfig.Name);
        Assert.Equal("Minimal yaml file for tests", noxConfig.Description);
    }

    [Fact]
    public void Can_get_instance_after_builder_build()
    {
        var _ = new NoxSolutionBuilder()
            .UseYamlFile("./files/minimal.solution.nox.yaml")
            .Build();
        var instance = NoxSolutionBuilder.Instance;
        Assert.NotNull(instance);
        Assert.NotNull(instance);
        Assert.Equal("MinimalService", instance.Name);
        Assert.Equal("Minimal yaml file for tests", instance.Description);
    }

    [Fact]
    public void Throw_if_set_yaml_file_does_not_exist()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile("./files/missing.solution.nox.yaml");
        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Can_create_solution_from_nox_design_folder()
    {
        var noxConfig = new NoxSolutionBuilder()
            .Build();
        Assert.NotNull(noxConfig);
    }

    [Fact]
    public void Error_if_solution_not_found_in_nox_folder()
    {
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.yaml", "zaml");
        var noxConfigBuilder = new NoxSolutionBuilder();
        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.zaml", "yaml");
    }

    [Fact]
    public void Throw_if_missing_yaml()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile("./files/x.solution.nox.yaml");
        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Must_not_throw_if_allow_missing_yaml()
    {
        var solution = new NoxSolutionBuilder()
            .UseYamlFile("./files/x.solution.nox.yaml")
            .AllowMissingSolutionYaml()
            .Build();
        Assert.NotNull(solution);
        Assert.Null(solution.Application);
        Assert.Null(solution.Infrastructure);
        Assert.Null(solution.Domain);
        Assert.Null(solution.Environments);
    }
}