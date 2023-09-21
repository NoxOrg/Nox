using Nox.Integration.Tests.Fixtures;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

[Collection("Sequential")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1000:Test classes must be public", Justification = "Disabled")]
internal class SqliteIntegrationTests : NoxIntegrationTestBase<NoxTestSqliteFixture>
{
    private readonly NoxCommonTestCaseFactory _noxCommonTestCases;

    public SqliteIntegrationTests(NoxTestSqliteFixture containerFixture) : base(containerFixture)
    {
        _noxCommonTestCases = new NoxCommonTestCaseFactory(containerFixture);
    }

    [Fact]
    public void GeneratedEntity_Sqlite_CanSaveAndReadFields_AllTypes()
    {
        _noxCommonTestCases.GenerateEntityCanSaveAndReadFieldsAllTypes();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_OneOrMany_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOneOrManyExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ExactlyOne_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipExactlyOneZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_ZeroOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ZeroOrMany_ZeroOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipZeroOrManyZeroOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_OneOrMany_OneOrMany()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedOneOrManyOneOrMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ExactlyOne_ExactlyOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedExactlyOneExactlyOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_Owned_ZeroOrOne_ZeroOrOne()
    {
        _noxCommonTestCases.GeneratedRelationshipOwnedZeroOrOneZeroOrOne();
    }

    [Fact]
    public void UniqueConstraints_SameValue_ShouldThrowException()
    {
        _noxCommonTestCases.UniqueConstraintsSameValueShouldThrowException();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityOneToOne()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToOne();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityManyToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityManyToMany();
    }

    [Fact]
    public void GeneratedRelationship_Sqlite_TwoRelationshipsToTheSameEntityOneToMany()
    {
        _noxCommonTestCases.GeneratedRelationshipTwoRelationshipsToTheSameEntityOneToMany();
    }
}