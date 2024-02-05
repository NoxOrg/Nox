using FluentAssertions;
using Nox.Yaml.Tests.TestDesigns.Sample.Models;

namespace Nox.Yaml.Tests;

public class YamlConfigurationBuilderTests
{

    [Fact]
    public void YamlConfigurationReader_Reads_Sample1()
    {
        // Arrange
        var reader = new YamlConfigurationReader<SampleClass>()
            .WithFile("./TestDesigns/Sample/Yaml/sample1.sampleClass.yaml");

        // Act

        var sample = reader.Read();

        // Assert

        sample.Should().NotBeNull();
        sample.SampleString.Should().Be("This is a sample string");
        sample.SampleEnum.Should().Be(SampleEnum.Second);
    }

    [Fact]
    public void YamlConfigurationReader_Reads_Sample1_Using_Discovery()
    {
        // Arrange

        var reader = new YamlConfigurationReader<SampleClass>()
            .WithSingleFileMatching("*.sampleClass.yaml")
            .WithSearchFromExecutionFolder("./TestDesigns/Sample/Yaml/");

        // Act

        var sample = reader.Read();

        // Assert

        sample.Should().NotBeNull();
        sample.SampleString.Should().Be("This is a sample string");
        sample.SampleEnum.Should().Be(SampleEnum.Second);
    }

    [Fact]
    public void YamlConfigurationReader_Reads_Nox_Using_CryptoCash()
    {
        // Arrange

        var reader = new YamlConfigurationReader<TestDesigns.Nox.Models.NoxSolution,NoxSolutionBasicsOnly>()
            .WithSingleFileMatching("*.solution.nox.yaml")
            .WithSearchFromExecutionFolder("./TestDesigns/Nox/Yaml/cryptoCash/");

        // Act

        var sample = reader.Read();

        // Assert

        sample.Should().NotBeNull();
        sample.Name.Should().Be("Cryptocash");
    }

    [Fact]
    public void YamlConfigurationReader_Reads_Nox_Using_CryptoCash_from_design_folder()
    {
        // Arrange

        var reader = new YamlConfigurationReader<TestDesigns.Nox.Models.NoxSolution,NoxSolutionBasicsOnly>()
            .WithSearchPath("./.nox/design")
            .WithSearchFromExecutionFolder("./.nox/design");

        // Act

        var sample = reader.Read();

        // Assert

        sample.Should().NotBeNull();
        sample.Name.Should().Be("Cryptocash");
    }
    
    [Fact]
    public void YamlConfigurationReader_Reads_Nox_Using_ClientApi_files()
    {
        // Arrange

        var reader = new YamlConfigurationReader<TestDesigns.Nox.Models.NoxSolution,NoxSolutionBasicsOnly>()
            .WithFile("./TestDesigns/Nox/Yaml/ClientApi/clientapi.solution.nox.yaml");

        // Act

        var sample = reader.Read();

        // Assert

        sample.Should().NotBeNull();
        sample.Name.Should().Be("Cryptocash");
    }

}