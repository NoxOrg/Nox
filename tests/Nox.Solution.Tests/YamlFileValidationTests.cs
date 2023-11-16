using FluentAssertions;
using FluentValidation;
using Nox.Solution.Exceptions;
using Nox.Solution.Schema;
using Nox.Yaml.Exceptions;
using Nox.Yaml.Parser;
using System;

namespace Nox.Solution.Tests;

public class YamlFileValidationTests
{
    [Theory]
    [InlineData("unsupported-version-control.solution.nox")]
    [InlineData("not-found.yaml")]
    public void UseYamlFile_ThrowsException_NoxYamlException(string filrName)
    {
        var solutionBuilder = new NoxSolutionBuilder().WithFile($"./files/{filrName}");

        solutionBuilder
            .Invoking(solution => solution.Build())
            .Should().Throw<NoxYamlException>();
    }

    [Theory]
    [InlineData("duplicate-environment-name.solution.nox.yaml", "The collection [environments] contains duplicate for values [\"test\"] based on property [name]. (at line 11 in duplicate-environment-name.solution.nox.yaml)")]
    public void Validate_Solution_ThrowsException_WithMessage(string ymlFileName, string expectedErrorMessage)
    {
        Action act = () => new NoxSolutionBuilder()
            .WithFile($"./files/{ymlFileName}")
            .Build();

        act.Should()
            .Throw<NoxYamlException>()
            .Where(exception => exception.Errors[0].Contains(expectedErrorMessage));
    }

    [Fact]
    public void When_AzureServiceBus_AzureServiceBusConfig_Is_Required()
    {
        var noxConfigBuilder = new NoxSolutionBuilder()
       .WithFile($"./files/invalid-messaging.azureservicebus.solution.nox.yaml");

        Assert.Throws<NoxYamlValidationException>(() => noxConfigBuilder.Build());
    }

    [Fact]
    public void Deserialize_WithNoxYamlSerializer_ThrowsException()
    {
        var files = new Dictionary<string, Func<TextReader>>()
        {
            { "invalid-sample.solution.nox.yaml", () => new StreamReader("./files/invalid-sample.solution.nox.yaml") },
            { "invalid-sample.versionControl.nox.yaml", () => new StreamReader("./files/invalid-sample.versionControl.nox.yaml") },
            { "invalid-sample-Country.entity.nox.yaml", () => new StreamReader("./files/invalid-sample-Country.entity.nox.yaml") },
        };


        var resolvedFiles = new YamlReferenceResolver(files, "invalid-sample.solution.nox.yaml");

        var exception = Assert.Throws<NoxYamlException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(resolvedFiles));

        var errors = exception.Errors;

        var errorCount = errors.Count;

        Assert.Contains("[\"relationship\"]", exception.Message);
        Assert.Contains("[\"name\"]", exception.Message);
        Assert.Contains("[\"serverUri\"]", exception.Message);
        Assert.Contains("dataConnection", exception.Message);
        Assert.Equal(42, errorCount);
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
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/missed-isRequired-keys-for-entity.solution.nox.yaml")
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
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/entity-key-compound-type.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        errors.Length.Should().Be(1);
        errors[0].ErrorMessage.Should().Be("Entity Currency: Key Id cannot be Compound type.", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedRelationship_MultipleUse_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-relationship-used-twice.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("The owned relationship 'CountryLegalCurrencies' for entity 'Country' refers to an entity 'Currency' that is used in other owned relationships. Owned entities must be owned by one parent only.", errors[0].ErrorMessage);
        Assert.Equal("The owned relationship 'StoreAcceptedCurrencies' for entity 'Store' refers to an entity 'Currency' that is used in other owned relationships. Owned entities must be owned by one parent only.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_SetAsAudited_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-set-as-audited.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("The owned entity 'Currency' cannot be auditable.", errors[0].ErrorMessage);
        Assert.Equal("The owned entity 'Country' cannot be auditable.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasRelationships_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-relationships.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("The owned entity 'Country' cannot have relationships to other entities.", errors[0].ErrorMessage);
        Assert.Equal("The owned entity 'Country' cannot be referred by other entities relationships.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasKeysWhenRelationshipIsZeroOrOne_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-keys-when-relationship-is-zeroOrOne.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Owned entity Currency with ZeroOrOne or ExactlyOne relationship can not have key(s).", errors[0].ErrorMessage);
        Assert.Equal("Owned entity Country with ZeroOrOne or ExactlyOne relationship can not have key(s).", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasKeysWhenRelationshipIsExactlyOne_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-keys-when-relationship-is-exactlyOne.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Owned entity Currency with ZeroOrOne or ExactlyOne relationship can not have key(s).", errors[0].ErrorMessage);
        Assert.Equal("Owned entity Country with ZeroOrOne or ExactlyOne relationship can not have key(s).", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_DoesNotHaveKeysWhenRelationshipIsZeroOrMany_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-does-not-have-keys-when-relatonship-is-zeroOrMany.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are mandatory for entity Currency. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity Country. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_DoesNotHaveKeysWhenRelationshipIsOneOrMany_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-does-not-have-keys-when-relatonship-is-oneOrMany.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are mandatory for entity Currency. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity Country. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_Entity_DoesNotHaveKeys_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/entity-does-not-have-keys-defined.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(3, errors.Length);

        Assert.Equal("Keys are mandatory for entity People. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity Currency. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[1].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity Country. Except owned entities with ZeroOrOne or ExactlyOne relationships.", errors[2].ErrorMessage);
    }

    [Fact]
    public void Deserialize_EntityItemsNameAreDuplicated_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .WithFile($"./files/duplicated-items-definition.nox.yaml")
            .Build();

        var errors = action.Should()
             .ThrowExactly<NoxYamlValidationException>()
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
            "The OwnedRelationships 'Id' is duplicated",
            "The dependant entity Currency  in relation Id can only have a single key."
        };
        
        errors.Should()
            .NotBeEmpty()
            .And.HaveCount(20)
            .And.Subject.Select(x => x.ErrorMessage)
           .Should()
           .Contain(x => expectedErrors.Any(t => x.StartsWith(t)));
    }

    [Fact]
    public void Deserialize_WithInvalidUniqueAttributeConstraints_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .WithFile($"./files/invalid-unique-attribute-constraints.solution.nox.yaml")
            .Build();

        var errors = action.Should()
            .ThrowExactly<NoxYamlValidationException>()
            .Subject
            .First()
            .Errors.ToArray();

        var expectedErrors = new[]
        {
            "The unique attribute constraint 'UniqueCountryName' is duplicated. unique attribute constraint must be unique in a domain definition.",
            "The unique attribute constraint attribute names 'AlphaCode2,AlphaCode3,NumericCode' is duplicated. unique attribute constraint attribute names must be unique in a domain definition.",
            "Attribute name 'NonExistentAttribute' in unique attribute constraint not found in neither entity attribute(s)",
        };

        errors.Length.Should().BePositive();

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

        var exception = Assert.Throws<NoxYamlException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(yaml));

        var errorCount = exception.Errors.Count;

        errorCount.Should().BePositive();

        exception.Message.Should().Contain("Missing property [\"name\"]");
        exception.Message.Should().Contain("Missing property [\"attributeNames\"]");
    }

    [Fact]
    public void Deserialize_InvalidRelationshipConfig_ThrowsException()
    {
        var action = () => new NoxSolutionBuilder()
            .WithFile($"./files/invalid-relationship-config.entity.nox.yaml")
            .Build();

        var errors = action.Should()
            .ThrowExactly<NoxYamlValidationException>()
            .Subject
            .First()
            .Errors.ToArray();

        var expectedErrors = new[]
        {
            "The Relationship 'CurrencyInCountries' between 'Currency' and 'Country' must have CanNavigate property set to True at least on one side.",
            "The Relationship 'CountryLegalCurrencies' between 'Country' and 'Currency' must have CanNavigate property set to True at least on one side."
        };

        errors.Length.Should().BePositive();
        errors.Should()
            .NotBeEmpty()
            .And.HaveCount(expectedErrors.Length)
            .And.Subject.Select(x => x.ErrorMessage)
            .Should()
            .Contain(x => Array.Exists(expectedErrors, x.StartsWith));
    }
}
