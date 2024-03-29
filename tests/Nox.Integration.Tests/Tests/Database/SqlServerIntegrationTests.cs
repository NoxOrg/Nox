using Nox.Integration.Tests.Fixtures;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

[Collection("Sequential")]
public class SqlServerIntegrationTests : NoxIntegrationContainerTestBase<NoxTestMsSqlContainerFixture>
{
    private readonly DatabaseTests _noxCommonTestCases;
    private readonly ReferenceNumberTests _referenceNumberTests;


    public SqlServerIntegrationTests(NoxTestMsSqlContainerFixture fixture) : base(fixture)
    {
        _noxCommonTestCases = new DatabaseTests(fixture);
        _referenceNumberTests = new ReferenceNumberTests(fixture);
    }

    [Fact]
    public async Task WhenGetSequenceNextValue_ShouldSucceed()
    {
        await _referenceNumberTests.WhenGetSequenceNextValue_ShouldSucceed();
    }

    [Fact]
    public async Task WhenCreateReferenceNumberAttribute_ShouldBeUnique()
    {
        await _referenceNumberTests.WhenCreateReferenceNumberAttribute_ShouldBeUnique();
    }

    

    [Fact]
    public void GeneratedEntity_SqlServer_CanSaveAndReadFields_AllTypes()
    {
        _noxCommonTestCases.GenerateEntityCanSaveAndReadFieldsAllTypes();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrOne_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_OneOrMany_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrManyExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ExactlyOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_ZeroOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_Owned_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_Owned_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedOneOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_Owned_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedExactlyOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_Owned_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedZeroOrOneZeroOrOne();
    }

    [Fact]
    public void UniqueConstraints_SameValue_ShouldThrowException()
    {
        _noxCommonTestCases.UniqueConstraintsSameValueShouldThrowException();
    }

    [Fact]
    public void WhenUniqueConstraintsWithRelation_ShouldBeValid()
    {
        _noxCommonTestCases.WhenUniqueConstraintsWithRelation_ShouldBeValid();
    }

    [Fact]
    public void WhenUniqueConstraintsWithRelationIsViolated_ShouldThrow()
    {
        _noxCommonTestCases.WhenUniqueConstraintsWithRelationIsViolated_ShouldThrowException();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_TwoRelationshipsToTheSameEntityOneToOne()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToOne();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_TwoRelationshipsToTheSameEntityManyToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityManyToMany();
    }

    [Fact]
    public void GeneratedRelationship_SqlServer_TwoRelationshipsToTheSameEntityOneToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToMany();
    }

    [Fact]
    public void GeneratedEntities_SqlServer_LocalizedEntitiesBeingGenerated()
    {
        _noxCommonTestCases.LocalizedEntitiesBeingGenerated();
    }
    
    [Fact]
    public async Task GeneratedEntities_SqlServer_AutoNumberedEntitiesBeingGenerated()
    {
        await _noxCommonTestCases.AutoNumberedEntitiesBeingGenerated();
    }
}