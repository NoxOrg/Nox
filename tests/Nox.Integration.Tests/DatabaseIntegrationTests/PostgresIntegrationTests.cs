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

    [Fact(Skip = "Fix 42P07 error when create db in container")]
    public void GeneratedEntity_Postgres_CanSaveAndReadFields_AllTypes()
    {
        _noxCommonTestCases.GenerateEntityCanSaveAndReadFieldsAllTypes();
    }

    [Fact(Skip = "Fix 42P07 error when create db in container")]
    public void UniqueConstraints_SameValue_ShouldThrowException()
    {
        _noxCommonTestCases.UniqueConstraintsSameValueShouldThrowException();
    }
}