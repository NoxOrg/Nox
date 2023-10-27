using FluentAssertions;
using FluentValidation;
using Nox.Solution.Exceptions;
using Nox.Types;

namespace Nox.Solution.Tests;

public class SolutionBuilderTests
{
    [Fact]
    public void Can_create_solution_from_set_yaml_file()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/minimal.solution.nox.yaml")
            .Build();
        noxConfig.Should().NotBeNull();
        noxConfig.Name.Should().Be("MinimalService");
        noxConfig.PlatformId.Should().Be("MinimalService");

        noxConfig.Description.Should().Be("Minimal yaml file for tests");
        noxConfig.Version.Should().Be("1.0");
    }

    [Fact]
    public void Can_get_instance_after_builder_build()
    {
        _ = new NoxSolutionBuilder()
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
        Assert.Throws<NoxSolutionConfigurationException>(noxConfigBuilder.Build);
    }

    [Fact]
    public void Throw_if_solution_wrong_set()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile("./files/wrong.solution.nox.yaml");

        var exception = Assert.Throws<ValidationException>(noxConfigBuilder.Build);

        exception.Message.Should().Contain("Solution Version doesn't satisfy pattern.");
    }

    [Fact]
    public void Can_create_solution_from_nox_design_folder()
    {
        var noxConfig = new NoxSolutionBuilder()
            .Build();

        noxConfig.Should().NotBeNull();
    }

    [Fact]
    public void Error_if_solution_not_found_in_nox_folder()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile(".files/invalidextension.solution.nox.zaml");

        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void When_InMemmory_AzureServiceBusConfig_Must_Be_Null()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile($"./files/invalid-messaging.inmemory.solution.nox.yaml");

        Assert.Throws<NoxSolutionConfigurationException>(() => noxConfigBuilder.Build());
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

    [Fact]
    public void Throw_if_entity_has_multiple_autonumber_property_when_database_provider_sqlite()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .UseYamlFile("./files/sqlite-multiple-autonumber-entity.solution.nox.yaml");

        var exception = Assert.Throws<ValidationException>(noxConfigBuilder.Build);

        exception.Message.Should().Contain("SQLite does not support more than one AutoNumber per entity.");
    }

    [Fact]
    public void Must_not_throw_if_entity_has_multiple_autonumber_property_when_database_provider_not_sqlite()
    {

        _ = new NoxSolutionBuilder()
            .UseYamlFile("./files/mssql-multiple-autonumber-entity.solution.nox.yaml")
            .Build();
        var instance = NoxSolutionBuilder.Instance;

        Assert.NotNull(instance);
        Assert.Equal(DatabaseServerProvider.SqlServer, instance.Infrastructure!.Persistence.DatabaseServer.Provider);

        var allProperties = instance.Domain!.Entities[0].Attributes.Union(instance.Domain!.Entities[0].Keys);
        Assert.True(allProperties.Count(p=>p.Type == NoxType.AutoNumber) > 1);
    }
}