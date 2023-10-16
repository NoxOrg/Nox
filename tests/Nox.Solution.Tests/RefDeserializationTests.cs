using FluentAssertions;
using FluentValidation;

namespace Nox.Solution.Tests;


public class RefDeserializationTests
{

    [Fact]
    public void Can_create_a_full_configuration()
    {
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/ref/ref.solution.nox.yaml")
            .Build();


        noxConfig.Should().NotBeNull();
        noxConfig.VersionControl.Should().NotBeNull();
        noxConfig.Domain.Should().NotBeNull();

        noxConfig.Name.Should().Be("SampleService");
        noxConfig.Domain!.Entities.Count.Should().Be(4);
        noxConfig.VersionControl!.Provider.Should().Be(VersionControlProvider.AzureDevops);
    }
}