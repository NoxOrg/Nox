namespace Nox.Integration.EtlTests;

public class DbContextTests
{
    [Fact (Skip = "This test can only be run locally if you have a local sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
    //[Fact]
    public void Can_Use_standalone_db_for_integration_data()
    {
        
    }
}