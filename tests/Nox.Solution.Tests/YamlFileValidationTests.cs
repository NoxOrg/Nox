using FluentAssertions;
using FluentValidation;
using Nox.Solution.Exceptions;
using Nox.Solution.Schema;
using Nox.Yaml.Exceptions;
using Nox.Yaml.Parser;
using System;
using System.IO;
using Xunit.Sdk;

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
            .Throw<NoxYamlValidationException>()
            .Where(exception => exception.Errors[0].ErrorMessage.Contains(expectedErrorMessage));
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

        var exception = Assert.Throws<NoxYamlValidationException>(
            () => NoxSchemaValidator.Deserialize<NoxSolution>(resolvedFiles)
        );

        var errors = exception.Errors.Select(e => e.ErrorMessage).ToArray();

        errors.Length.Should().Be(39);
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

        var model = NoxSchemaValidator.Deserialize<NoxSolution>(yaml, yamlFile)!;

        model.Name.Should().Be(expectedServiceName);
    }


    [Fact]
    public void Deserialize_InvalidServerPort_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/invalid-server-port-numbers.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Invalid value [99999] for property [port] is more than maximum [0]. (at line 25 in invalid-server-port-numbers.solution.nox.yaml)", errors[0].ErrorMessage);
        Assert.Equal("Invalid value [-1] for property [port] is less than minumum [0]. (at line 33 in invalid-server-port-numbers.solution.nox.yaml)", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_EntityKeyIsCompoundType_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/entity-key-compound-type.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        errors.Length.Should().Be(1);

        errors[0].ErrorMessage
            .Should().Be("Key [Id] on entity [Currency] can not be a compound type.", errors[0].ErrorMessage);
        
    }

    [Fact]
    public void Deserialize_OwnedRelationship_MultipleUse_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-relationship-used-twice.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Single(errors);

        Assert.Equal("Entity [Currency] owned multiple times or by multiple entities [Country,Store].", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_SetAsAudited_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-set-as-audited.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Entity [Currency] is owned and can't therefore be auditable. [Persistence.IsAudited=true]", errors[0].ErrorMessage);
        Assert.Equal("Entity [Country] is owned and can't therefore be auditable. [Persistence.IsAudited=true]", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasRelationships_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-relationships.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2,errors.Length);

        Assert.Equal("Entity [Country] owned multiple times or by multiple entities [People,Continent].", errors[0].ErrorMessage);
        Assert.Equal("Entity [Country] is owned and can't have relationships.", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasKeysWhenRelationshipIsZeroOrOne_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-keys-when-relationship-is-zeroOrOne.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are invalid for owned entity [Currency] with ZeroOrOne/ExactlyOne relationship from [Country].", errors[0].ErrorMessage);
        Assert.Equal("Keys are invalid for owned entity [Country] with ZeroOrOne/ExactlyOne relationship from [Continent].", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_HasKeysWhenRelationshipIsExactlyOne_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-keys-when-relationship-is-exactlyOne.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are invalid for owned entity [Currency] with ZeroOrOne/ExactlyOne relationship from [Country].", errors[0].ErrorMessage);
        Assert.Equal("Keys are invalid for owned entity [Country] with ZeroOrOne/ExactlyOne relationship from [Continent].", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_DoesNotHaveKeysWhenRelationshipIsZeroOrMany_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-does-not-have-keys-when-relatonship-is-zeroOrMany.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are mandatory for owned entity [Currency] with ZeroOrMany/OneOrMany relationship from [Country].", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for owned entity [Country] with ZeroOrMany/OneOrMany relationship from [Continent].", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnedEntity_DoesNotHaveKeysWhenRelationshipIsOneOrMany_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-does-not-have-keys-when-relatonship-is-oneOrMany.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(2, errors.Length);

        Assert.Equal("Keys are mandatory for owned entity [Currency] with ZeroOrMany/OneOrMany relationship from [Country].", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for owned entity [Country] with ZeroOrMany/OneOrMany relationship from [Continent].", errors[1].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnerEntity_CompositeKeys_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owner-entity-has-composite-keys.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Single(errors);

        Assert.Equal("Relationship [ContinentIncludesCountries] on entity [Continent] refers to related entity [Country] with composite key. Must be simple key on Country.", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_Entity_DoesNotHaveKeys_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/entity-does-not-have-keys-defined.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(3, errors.Length);

        Assert.Equal("Keys are mandatory for entity [People].", errors[0].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity [Currency].", errors[1].ErrorMessage);
        Assert.Equal("Keys are mandatory for entity [Country].", errors[2].ErrorMessage);
    }

    [Fact]
    public void Deserialize_EntityItemsNameAreDuplicated_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .WithFile($"./files/duplicated-items-definition.nox.yaml")
            .Build();

    
        var expectedErrors = new string[]
        {
            "Duplicate name [Id] on entity [Currency] found in [Key,Key,Attribute,OwnedRelationship,OwnedRelationship]",
            "Duplicate name [CurrenciesCountryLegal] on entity [Currency] found in [Attribute,Relationship,Relationship]",
            "Multiple ownerships of entity [Currency] exists on entity [Currency].",
            "Entity [Currency] owned multiple times or by multiple entities [Currency,Currency,Currency,Currency].",
            "Entity [Currency] is owned and can't have relationships.",
            "Relationship [CurrenciesCountryLegal] on entity [Currency] refers to related entity [Currency] with composite key. Must be simple key on Currency.",
            "Relationship [CurrenciesCountryLegal] on entity [Currency] refers to related entity [Currency] with composite key. Must be simple key on Currency.",
            "Relationship [Id] on entity [Currency] refers to related entity [Currency] with composite key. Must be simple key on Currency.",
            "Relationship [Id] on entity [Currency] refers to related entity [Currency] with composite key. Must be simple key on Currency.",
        };

        action.Should()
            .ThrowExactly<NoxYamlValidationException>()
            .Which
            .Errors
            .Should().NotBeEmpty()
            .And.Subject.Select(x => x.ErrorMessage)
            .Should().BeEquivalentTo(expectedErrors);
    
    }

    [Fact]
    public void Deserialize_WithInvalidUniqueAttributeConstraints_ThrowsException()
    {
        Action action = () => new NoxSolutionBuilder()
            .WithFile($"./files/invalid-unique-attribute-constraints.solution.nox.yaml")
            .Build();


        var expectedErrors = new[]
        {
            "Duplicate name [UniqueCountryName] on entity [Country] found in [UniqueConstraint,UniqueConstraint]",
            "Unique constraint [UniqueConstraintWithNonExistentAttribute] refers to non-existing attribute [NonExistentAttribute] on entity [Country]",
            "Unique constraints [UniqueCountry,Unique] refers to non-unique keys [AlphaCode2,AlphaCode3,NumericCode] on entity [Country]",
        };

        var errors = action.Should()
            .ThrowExactly<NoxYamlValidationException>()
            .Which.Errors
            .Should().NotBeEmpty()
            .And.HaveCount(3)
            .And.Subject.Select(x => x.ErrorMessage)
            .Should().BeEquivalentTo(expectedErrors);
    }

    [Fact]
    public void Deserialize_WithNoxYamlSerializer_ForInvalidUniqueAttributeConstraints_ThrowsException()
    {
        var yaml = File.ReadAllText("./files/invalid-structure-unique-attribute-constraints.solution.nox.yaml");

        var exception = Assert
            .Throws<NoxYamlValidationException>(() => NoxSchemaValidator.Deserialize<NoxSolution>(yaml));

        var errors = exception.Errors.Select(e => e.ErrorMessage).ToArray();

        errors.Length.Should().Be(2);

        errors[0].Should().Match("Missing property [\"name\"] is required.*");
        errors[1].Should().Match("Missing property [\"attributeNames\"] is required.*");
    }

}
