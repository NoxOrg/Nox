using FluentAssertions;
using FluentValidation;
using Nox.Solution.Exceptions;
using Nox.Solution.Schema;
using System;

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

        var exception = Assert.Throws<NoxSolutionConfigurationException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Message.Split('\n').Length;

        Assert.Contains("[\"relationship\"]", exception.Message);
        Assert.Contains("[\"name\"]", exception.Message);
        Assert.Contains("[\"serverUri\"]", exception.Message);
        Assert.Contains("dataConnection", exception.Message);
        Assert.Equal(20, errorCount);
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

        var model = NoxSchemaValidator.Deserialize<NoxSolution>(yaml)!;

        model.Name.Should().Be(expectedServiceName);
    }

    [Fact]
    public void Deserialize_Solution_ThatDoesntHaveKeysForEntity_Exception()
    {
        var yaml = File.ReadAllText($"./files/has-no-keys-for-entity.solution.nox.yaml");

        var exception = Assert.Throws<NoxSolutionConfigurationException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Message.Split('\n').Length;

        Assert.Contains("[\"keys\"]", exception.Message);
        Assert.Equal(1, errorCount);
    }

    [Fact]
    public void Deserialize_MissedIsRequiredInKeys_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => new NoxSolutionBuilder()
            .UseYamlFile($"./files/missed-isRequired-keys-for-entity.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(4, errors.Length);

        Assert.Equal("Entity Currency: Key property IsRequired should be set to True explicitly in  Id", errors[0].ErrorMessage);
        Assert.Equal("Entity Currency: Key property IsRequired should be set to True explicitly in  Name", errors[1].ErrorMessage);
        Assert.Equal("Entity Country: Key property IsRequired should be set to True explicitly in  Id", errors[2].ErrorMessage);
        Assert.Equal("Entity Country: Key property IsRequired should be set to True explicitly in  Name", errors[3].ErrorMessage);
    }

    [Fact]
    public void Deserialize_EntityKeyIsCompoundType_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => new NoxSolutionBuilder()
            .UseYamlFile($"./files/entity-key-compound-type.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        errors.Length.Should().Be(1);
        errors[0].ErrorMessage.Should().Be("Entity Currency: Key Id should not be Compound type.", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedRelationship_MultipleUse_ThrowsException()
    {
        var exception = Assert.Throws<ValidationException>(() => new NoxSolutionBuilder()
            .UseYamlFile($"./files/owned-relationship-used-twice.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("The owned relationship 'CountryLegalCurrencies' for entity 'Country' refers to an entity 'Currency' that is used in other owned relationships. Owned entities must be owned by one parent only.", errors[0].ErrorMessage);
        Assert.Equal("The owned relationship 'StoreAcceptedCurrencies' for entity 'Store' refers to an entity 'Currency' that is used in other owned relationships. Owned entities must be owned by one parent only.", errors[1].ErrorMessage);
    }
}