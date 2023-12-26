using FluentAssertions;
using Nox.Solution.Schema;
using Nox.Yaml.Exceptions;
using Nox.Yaml.Parser;

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

        errors.Length.Should().Be(38);
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
    [InlineData("localization-without-default-culture-in-supported-cultures.solution.nox.yaml", "MinimalService")]
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

        Assert.Equal("Invalid value [99999] for property [port] is more than maximum [65535]. (at line 25 in invalid-server-port-numbers.solution.nox.yaml)", errors[0].ErrorMessage);
        Assert.Equal("Invalid value [-1] for property [port] is less than minimum [0]. (at line 33 in invalid-server-port-numbers.solution.nox.yaml)", errors[1].ErrorMessage);
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
    public void Deserialize_OwnedEntity_HasOverlappingAttributeNameWithOwnerEntityKeyName_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owned-entity-has-attribute-name-overlapped-with-owner-entity-key.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Single(errors);

        Assert.Equal("Attribute [Name] on owned entity [Country] has conflicting name with owner entity [Continent] key.", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_OwnerEntity_CompositeKeys_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/owner-entity-has-composite-keys.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(3, errors.Length);

        Assert.Equal("Entity [Country] is an owner entity and can't have composite key.", errors[0].ErrorMessage);
        Assert.Equal("Entity [Continent] is an owner entity and can't have composite key.", errors[1].ErrorMessage);
        Assert.Equal("Relationship [ContinentIncludesCountries] on entity [Continent] refers to related entity [Country] with composite key. Must be simple key on Country.", errors[2].ErrorMessage);
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
            "Entity [Currency] is an owner entity and can't have composite key.",
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
            "Unique constraint [UniqueConstraintWithNonExistentRelationship] refers to non-existing relationship [NonExistentRelationship] on entity [Country]",
            "Unique constraint [UniqueConstraintWithInvalidRelationshipType] refers to a relationship [CountryAcceptsCurrency] which isn't zero/one to many from single side",
            "Unique constraint [UniqueConstraintWithDuplicateAttributeName] has duplicate attribute name: [Name]",
            "Unique constraint [UniqueConstraintWithDuplicateRelationshipName] has duplicate relationship name: [BelongsToCountry]"
        };

        action.Should()
            .ThrowExactly<NoxYamlValidationException>()
            .Which.Errors
            .Should().NotBeEmpty()
            .And.HaveCount(7)
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

    [Fact]
    public void Deserialize_WithInvalidLocalizationDefaultCulture_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/localization-invalid-default-culture.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Single(errors);

        Assert.Equal("Invalid value [\"eng\"] for property [defaultCulture]. (at line 12 in localization-invalid-default-culture.solution.nox.yaml)", errors[0].ErrorMessage);
    }

    [Fact]
    public void Deserialize_WithInvalidLocalizationSupportedCultures_ThrowsException()
    {
        var exception = Assert.Throws<NoxYamlValidationException>(() => new NoxSolutionBuilder()
            .WithFile($"./files/localization-invalid-supported-cultures.solution.nox.yaml")
            .Build());

        var errors = exception.Errors.ToArray();

        Assert.Equal(5, errors.Length);

        Assert.Equal("Invalid value [\"tR\"] for property [supportedCultures]. (at line 13 in localization-invalid-supported-cultures.solution.nox.yaml)", errors[0].ErrorMessage);
        Assert.Equal("Invalid value [\"eng\"] for property [supportedCultures]. (at line 13 in localization-invalid-supported-cultures.solution.nox.yaml)", errors[1].ErrorMessage);
        Assert.Equal("Invalid value [\"Sr-SR\"] for property [supportedCultures]. (at line 13 in localization-invalid-supported-cultures.solution.nox.yaml)", errors[2].ErrorMessage);
        Assert.Equal("Invalid value [\"sr-SR-Cyrl\"] for property [supportedCultures]. (at line 13 in localization-invalid-supported-cultures.solution.nox.yaml)", errors[3].ErrorMessage);
        Assert.Equal("Invalid value [\"invalid\"] for property [supportedCultures]. (at line 13 in localization-invalid-supported-cultures.solution.nox.yaml)", errors[4].ErrorMessage);
    }

    [Fact]
    public void WhenCreateEntity_ShouldValidateManageRelationshipDepth()
    {
        var minValidationSolution = () => new NoxSolutionBuilder()
            .WithFile($"./files/endpoints.depth.minvalidation.solution.nox.yaml")
            .Build();
        var maxValidationSolution = () => new NoxSolutionBuilder()
            .WithFile($"./files/endpoints.depth.maxvalidation.solution.nox.yaml")
            .Build();

        var minError = "Invalid value [0] for property [apiGenerateRelatedEndpointsMaxDepth] is less than minimum [1]. (at line 22 in endpoints.depth.minvalidation.solution.nox.yaml)";
        var maxError = "Invalid value [7] for property [apiGenerateRelatedEndpointsMaxDepth] is more than maximum [5]. (at line 22 in endpoints.depth.maxvalidation.solution.nox.yaml)";

        minValidationSolution.Should()
           .ThrowExactly<NoxYamlValidationException>()
           .Which.Errors
           .Should().NotBeEmpty()
           .And.HaveCount(1)
           .And.Subject.Select(x => x.ErrorMessage)
           .Should().BeEquivalentTo(minError);

        maxValidationSolution.Should()
           .ThrowExactly<NoxYamlValidationException>()
           .Which.Errors
           .Should().NotBeEmpty()
           .And.HaveCount(1)
           .And.Subject.Select(x => x.ErrorMessage)
           .Should().BeEquivalentTo(maxError);
    }
}
