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
    public void Error_if_set_yaml_file_does_not_exist()
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
        Assert.False(noxConfig == null);
    }

    [Fact]
    public void Error_if_solution_not_found_in_nox_folder()
    {
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.yaml", "zaml");
        var noxConfigBuilder = new NoxSolutionBuilder();
        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
        TestHelpers.RenameFilesInFolder("../../../../../.nox/design", "*.nox.zaml", "yaml");
    }
    
    
}