using FluentAssertions;
using Nox.Yaml.Tests.TestDesigns.Cli.models;

namespace Nox.Yaml.Tests;

public class CliYamlConfigurationBuilderTests
{
    [Fact]
    public void Reader_Should_Read_Simple_Workflow()
    {
        var reader = new YamlConfigurationReader<WorkflowConfiguration>()
            .WithFile("./TestDesigns/Cli/Yaml/simple/test.workflow.nox.yaml");
        var workflow = reader.Read();
        workflow.Should().NotBeNull();
        workflow.Name.Should().Be("Test Workflow");
        workflow.Cli.Should().NotBeNull();
        workflow.Cli.Command.Should().Be("workflow");
        workflow.Cli.Examples.Should().NotBeNull();
        workflow.Cli.Examples!.Count.Should().Be(2);
        workflow.Jobs.Should().NotBeNull();
        workflow.Jobs.Count.Should().Be(1);
        workflow.Jobs[0].Name.Should().Be("Run Test workflow");
        workflow.Jobs[0].Steps.Should().NotBeNull();
        workflow.Jobs[0].Steps.Count.Should().Be(1);
    }

    [Fact]
    public void Reader_should_read_yaml_with_a_reference()
    {
        var reader = new YamlConfigurationReader<WorkflowConfiguration>()
            .WithFile("./TestDesigns/Cli/Yaml/reference/ref-test.workflow.nox.yaml");
        var workflow = reader.Read();
        workflow.Should().NotBeNull();
        workflow.Name.Should().Be("Test Workflow");
        workflow.Cli.Should().NotBeNull();
        workflow.Cli.Command.Should().Be("workflow");
        workflow.Cli.Examples.Should().NotBeNull();
        workflow.Cli.Examples!.Count.Should().Be(2);
        workflow.Jobs.Should().NotBeNull();
        workflow.Jobs.Count.Should().Be(1);
        workflow.Jobs[0].Name.Should().Be("Run Test workflow");
        workflow.Jobs[0].Steps.Should().NotBeNull();
        workflow.Jobs[0].Steps.Count.Should().Be(2);
    }
    
    [Fact]
    public void Reader_should_read_yaml_with_a_nested_reference()
    {
        var reader = new YamlConfigurationReader<WorkflowConfiguration>()
            .WithFile("./TestDesigns/Cli/Yaml/nested-reference/nested-test.workflow.nox.yaml");
        var workflow = reader.Read();
        workflow.Should().NotBeNull();
        workflow.Name.Should().Be("Test Workflow");
        workflow.Cli.Should().NotBeNull();
        workflow.Cli.Command.Should().Be("workflow");
        workflow.Cli.Examples.Should().NotBeNull();
        workflow.Cli.Examples!.Count.Should().Be(2);
        workflow.Jobs.Should().NotBeNull();
        workflow.Jobs.Count.Should().Be(1);
        workflow.Jobs[0].Name.Should().Be("Run Test workflow");
        workflow.Jobs[0].Steps.Should().NotBeNull();
        workflow.Jobs[0].Steps.Count.Should().Be(2);
    }
}