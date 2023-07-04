using FluentAssertions;
using Nox.Solution.Exceptions;
using Nox.Solution.Resolvers;

namespace Nox.Solution.Tests;

public class YamlFileValidationTests
{

    [Theory]
    [InlineData("unsupported-version-control.solution.nox")]
    [InlineData("not-found.yaml")]
    public void UseYamlFile_ThrowsException_NoxSolutionConfigurationException(string filrName)
    {
        var solutionBuilder = new NoxSolutionBuilder().UseYamlFile($"./files/{filrName}");

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxSolutionConfigurationException>();
    }

    [Theory]
    [InlineData("duplicate-environment-name.solution.nox.yaml", "The environment name 'test' is duplicated. Environment names must be unique in a solution.")]
    public void Validate_Solution_ThrowsException_WithMessage(string ymlFileName, string expectedErrorMessage)
    {
        Action act = () => new NoxSolutionBuilder()
            .UseYamlFile($"./files/{ymlFileName}")
            .Build()
            .Validate();

        act.Should()
            .Throw<FluentValidation.ValidationException>()
            .Where(exception => exception.Errors.First().ErrorMessage.Contains(expectedErrorMessage));
    }

    [Fact]
    public void Deserialize_WithNoxYamlSerializer_ThrowsException()
    {
        var yaml = File.ReadAllText("./files/invalid-sample.solution.nox.yaml");

        var exception = Assert.Throws<NoxSolutionConfigurationException>(() => NoxYamlSerializer.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Message.Split('\n').Length;

        Assert.Contains("[\"relationship\"]", exception.Message);
        Assert.Contains("[\"name\"]", exception.Message);
        Assert.Contains("[\"serverUri\"]", exception.Message);
        Assert.Contains("dataConnection", exception.Message);
        Assert.Equal(11, errorCount);
    }

    [Theory]
    [InlineData("application.solution.nox.yaml", "TestService")]
    [InlineData("domain.solution.nox.yaml", "TestService")]
    [InlineData("environments.solution.nox.yaml", "TestService")]
    [InlineData("infrastructure.solution.nox.yaml", "TestService")]
    [InlineData("minimal.solution.nox.yaml", "MinimalService")]
    [InlineData("sample.solution.nox.yaml", "SampleService")]
    [InlineData("team.solution.nox.yaml", "TestService")]
    [InlineData("variables.solution.nox.yaml", "TestService")]
    [InlineData("version-control.solution.nox.yaml", "TestService")]
    public void Deserialize_Solution_WithValidation_Success(string yamlFile, string expectedServiceName)
    {
        var yaml = File.ReadAllText($"./files/{yamlFile}");

        var model = NoxYamlSerializer.Deserialize<NoxSolution>(yaml)!;

        model.Name.Should().Be(expectedServiceName);
    }
}