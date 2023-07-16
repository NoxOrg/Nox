using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow.Connectors;
using Nox.IntegrationTarget.SqlServer;
using Nox.Solution;

namespace Nox.IntegrationTarget.Tests;

public class SqlServerTargetTests
{
    [Fact]
    public void Can_Create_Arbitrary_Sql_Target()
    {
        var config = new Solution.IntegrationTarget
        {
            Name = "TestSqlTarget",
            Description = "Test SqlServer source description",
            DataConnectionName = "TestSqlConnection",
            TargetType = IntegrationTargetType.Database
        };

        var dataConnection = new DataConnection
        {
            Name = "TestSqlConnection",
            Provider = DataConnectionProvider.SqlServer,
            ServerUri = "localhost",
            Port = 1433,
            User = "sa",
            Password = "Developer*123"
        };

        var target = new SqlServerIntegrationTarget(config.Name, dataConnection, "TestIntegration");
        var dfSource = target.DataFlowSource();
        Assert.NotNull(dfSource);
        Assert.IsType<DbSource<ExpandoObject>>(dfSource);
        Assert.NotNull(target.ConnectionManager);
        Assert.IsType<SqlConnectionManager>(target.ConnectionManager);
        var tableName = target.ToTableNameForSql("TestTable", "TestSchema");
        Assert.Equal("[TestSchema].[TestTable]", tableName);
        var rawTableName = target.ToTableNameForSqlRaw("TestTable", "TestSchema");
        Assert.Equal("TestSchema.TestTable", rawTableName);
    }
    
    [Fact]
    public void Can_Create_a_Sql_Target_to_Entity_store()
    {
        var config = new Solution.IntegrationTarget
        {
            Name = "TestSqlTarget",
            Description = "Test SqlServer source description",
            TargetType = IntegrationTargetType.Entity,
        };

        var dbServer = new DatabaseServer
        {
            Name = "TestDb",
            Provider = DatabaseServerProvider.SqlServer,
            ServerUri = "localhost",
            Port = 1433,
            User = "sa",
            Password = "Developer*123"
        };

        var target = new SqlServerIntegrationTarget(config.Name, dbServer, "TestIntegration");
        var dfSource = target.DataFlowSource();
        Assert.NotNull(dfSource);
        Assert.IsType<DbSource<ExpandoObject>>(dfSource);
        Assert.NotNull(target.ConnectionManager);
        Assert.IsType<SqlConnectionManager>(target.ConnectionManager);
    }
}