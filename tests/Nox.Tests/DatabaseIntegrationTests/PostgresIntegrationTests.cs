namespace Nox.Tests.DatabaseIntegrationTests;

public class PostgresIntegrationTests : PostgresTestBase, IClassFixture<TestFixture>
{
    private readonly TestFixture _testFixture;

    public PostgresIntegrationTests(TestFixture testFixture) : base()
    {
        _testFixture = testFixture;
    }

    // TODO: uncomment when automated and included into pipeline
    [Fact]
    public void GeneratedEntity_SqlServer_CanSaveAndReadFields_AllTypes()
    {
        var newItem = _testFixture.CreateTestEntityForTypes();
        DbContext.TestEntityForTypes.Add(newItem);
        DbContext.SaveChanges();

        // Force the recreation of DBContext and ensure we have fresh data from database
        RecreateDbContext();

        var testEntity = DbContext.TestEntityForTypes.First();

        _testFixture.AssertTestEntityForTypes(testEntity);
    }
}