using FluentAssertions;
using FluentValidation;
using Nox.Types;
using Nox.Yaml.Exceptions;

namespace Nox.Solution.Tests;

public class SolutionBuilderTests
{
    [Fact]
    public void Can_create_solution_from_set_yaml_file()
    {
        var noxConfig = new NoxSolutionBuilder()
            .WithFile("./files/minimal.solution.nox.yaml")
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
        var instance = new NoxSolutionBuilder()
            .WithFile("./files/minimal.solution.nox.yaml")
            .Build();
        Assert.NotNull(instance);
        Assert.NotNull(instance);
        Assert.Equal("MinimalService", instance.Name);
        Assert.Equal("Minimal yaml file for tests", instance.Description);
    }

    [Fact]
    public void Throw_if_set_yaml_file_does_not_exist()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .WithFile("./files/missing.solution.nox.yaml");
        Assert.Throws<NoxYamlException>(noxConfigBuilder.Build);
    }

    [Fact]
    public void Throw_if_solution_wrong_set()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .WithFile("./files/wrong.solution.nox.yaml");

        var exception = Assert.Throws<NoxYamlValidationException>(noxConfigBuilder.Build);

        exception
            .Errors[0]
            .ErrorMessage
            .Should().Match("The value [\"1.0.asddd\"] for property [version] does not match pattern*");
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
            .WithFile(".files/invalidextension.solution.nox.zaml");

        Assert.Throws<NoxYamlException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void When_InMemmory_AzureServiceBusConfig_Must_Be_Null()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .WithFile($"./files/invalid-messaging.inmemory.solution.nox.yaml");

        Assert.Throws<NoxYamlValidationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Throw_if_missing_yaml()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .WithFile("./files/x.solution.nox.yaml");
        Assert.Throws<NoxYamlException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Must_not_throw_if_allow_missing_yaml()
    {
        var solution = new NoxSolutionBuilder()
            .WithFile("./files/x.solution.nox.yaml")
            .AllowMissingSolutionYaml()
            .Build();


        Assert.NotNull(solution);
        
        // Default name and platform id when unspecified
        solution.Name.Should().Be("NotSpecified");
        solution.PlatformId.Should().Be("NotSpecified");
        
        //Infrastructure will always have a default value
        Assert.NotNull(solution.Infrastructure);
        
        //Persistence is Optional
        Assert.Null(solution.Infrastructure.Persistence);
        
        //End Points will always have a default value, even if no endpoints is being generated
        Assert.NotNull(solution.Infrastructure.Endpoints);
        Assert.Null(solution.Domain);
        Assert.Null(solution.Environments);
    }

    [Fact]
    public void Throw_if_entity_has_multiple_autonumber_property_when_database_provider_sqlite()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
            .WithFile("./files/sqlite-multiple-autonumber-entity.solution.nox.yaml");

        var exception = Assert.Throws<NoxYamlValidationException>(noxConfigBuilder.Build);

        exception
            .Errors[0]
            .ErrorMessage
            .Should().Contain("SQLite only supports one AutoNumber per entity.");
    }

    [Fact]
    public void Must_not_throw_if_entity_has_multiple_autonumber_property_when_database_provider_is_mssql()
    {

        var instance = new NoxSolutionBuilder()
            .WithFile("./files/mssql-multiple-autonumber-entity.solution.nox.yaml")
            .Build();

        Assert.NotNull(instance);
        Assert.Equal(DatabaseServerProvider.SqlServer, instance.Infrastructure!.Persistence!.DatabaseServer.Provider);

        var allProperties = instance.Domain!.Entities[0].Attributes.Union(instance.Domain!.Entities[0].Keys);
        Assert.True(allProperties.Count(p=>p.Type == NoxType.AutoNumber) > 1);
    }  
    [Fact]
    public void Must_not_throw_if_entity_has_multiple_autonumber_property_when_database_provider_is_postgresql()
    {

        var instance = new NoxSolutionBuilder()
            .WithFile("./files/postgresql-multiple-autonumber-entity.solution.nox.yaml")
            .Build();

        Assert.NotNull(instance);
        Assert.Equal(DatabaseServerProvider.Postgres, instance.Infrastructure!.Persistence!.DatabaseServer.Provider);

        var allProperties = instance.Domain!.Entities[0].Attributes.Union(instance.Domain!.Entities[0].Keys);
        Assert.True(allProperties.Count(p=>p.Type == NoxType.AutoNumber) > 1);
    }
}