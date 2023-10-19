using Nox.Integration.Tests.Fixtures;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

[Collection("Sequential")]
public class PostgresIntegrationTests : NoxIntegrationContainerTestBase<NoxTestPostgreContainerFixture>
{
    private readonly NoxCommonTestCaseFactory _noxCommonTestCases;

    public PostgresIntegrationTests(NoxTestPostgreContainerFixture containerFixture) : base(containerFixture)
    {
        _noxCommonTestCases = new NoxCommonTestCaseFactory(containerFixture);
    }

    [Fact]
    public void GeneratedEntity_Postgres_CanSaveAndReadFields_AllTypes()
    {
        _noxCommonTestCases.GenerateEntityCanSaveAndReadFieldsAllTypes(false);
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrOne_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_OneOrMany_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrManyExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ExactlyOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_ZeroOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_Owned_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_Owned_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedOneOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_Owned_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedExactlyOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_Owned_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedZeroOrOneZeroOrOne();
    }

    [Fact]
    public void UniqueConstraints_SameValue_ShouldThrowException()
    {
        _noxCommonTestCases.UniqueConstraintsSameValueShouldThrowException();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_TwoRelationshipsToTheSameEntityOneToOne()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToOne();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_TwoRelationshipsToTheSameEntityManyToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityManyToMany();
    }

    [Fact]
    public void GeneratedRelationship_Postgres_TwoRelationshipsToTheSameEntityOneToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToMany();
    }

    [Fact]
    public void GeneratedEntities_Postgres_LocalizedEntitiesBeingGenerated()
    {
        _noxCommonTestCases.LocalizedEntitiesBeingGenerated();
    }
}