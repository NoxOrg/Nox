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

        var errors = exception.Message.Split('\n');
        var errorCount = errors.Length;

        Assert.Contains("[\"relationship\"]", exception.Message);
        Assert.Contains("[\"name\"]", exception.Message);
        Assert.Contains("[\"serverUri\"]", exception.Message);
        Assert.Contains("dataConnection", exception.Message);
        Assert.Equal(24, errorCount);
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
        errors[0].ErrorMessage.Should().Be("Entity Currency: Key Id cannot be Compound type.", errors[0].ErrorMessage);
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

    [Fact]
    public void Deserialize_EntityItemsNameAreDuplicated_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .UseYamlFile($"./files/duplicated-items-definition.nox.yaml")
            .Build();

        var errors = action.Should()
             .ThrowExactly<ValidationException>()
             .Subject
             .First()
             .Errors;

        var expectedErrors = new string[]
        {
            "The entity relation  'CurrenciesCountryLegal' is duplicated",
            "The entity owned relation  'CountryLegalCurrencies' is duplicated",
            "The entity key 'Id' is duplicated",
            "The entity attribute 'Id' is duplicated",
            "The Keys 'Id' is duplicated",
            "The Attributes 'Id' is duplicated",
            "The Attributes 'CurrenciesCountryLegal' is duplicated",
            "The Relationships 'CurrenciesCountryLegal' is duplicated",
            "The OwnedRelationships 'Id' is duplicated"
        };

        errors.Should()
            .NotBeEmpty()
            .And.HaveCount(14)
            .And.Subject.Select(x => x.ErrorMessage)
           .Should()
           .Contain(x => expectedErrors.Any(t => x.StartsWith(t)));
    }
    
    [Fact]
    public void Deserialize_WithInvalidUniqueAttributeConstraints_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .UseYamlFile($"./files/invalid-unique-attribute-constraints.solution.nox.yaml")
            .Build();
        
        var errors = action.Should()
            .ThrowExactly<ValidationException>()
            .Subject
            .First()
            .Errors.ToArray();

        var expectedErrors = new[]
        {
            "The unique attribute constraint 'UniqueCountryName' is duplicated. unique attribute constraint must be unique in a domain definition.",
            "The unique attribute constraint attribute names 'AlphaCode2,AlphaCode3,NumericCode' is duplicated. unique attribute constraint attribute names must be unique in a domain definition.",
            "Attribute name 'NonExistentAttribute' in unique attribute constraint not found in neither entity attribute(s)",
        };
        
        
        errors.Count().Should().BePositive();

        errors.Should()
            .NotBeEmpty()
            .And.HaveCount(5)
            .And.Subject.Select(x => x.ErrorMessage)
            .Should()
            .Contain(x => Array.Exists(expectedErrors, x.StartsWith));
    }
    
    [Fact]
    public void Deserialize_WithNoxYamlSerializer_ForInvalidUniqueAttributeConstraints_ThrowsException()
    {
        var yaml = File.ReadAllText("./files/invalid-structure-unique-attribute-constraints.solution.nox.yaml");

        var exception = Assert.Throws<NoxSolutionConfigurationException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Message.Split('\n').Length;

        errorCount.Should().BePositive();

        exception.Message.Should().Contain("Missing property [\"name\"]");
        exception.Message.Should().Contain("Missing property [\"attributeNames\"]");
    }

}