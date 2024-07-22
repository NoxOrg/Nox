using System.Dynamic;
using ETLBox.DataFlow;
using Nox.Integration.Adapters.Message.RabbitMq;
using Nox.Integration.Adapters.SqlServer;

namespace Nox.Integration.EtlTests.Messaging;

public class RabbitMqTargetTests
{
    //[Fact (Skip = "This test can only be run locally if you have a local sql server instance, have created the CountrySource database and have a local rabbitMq instance running using ./files/Create_CountrySource.sql")]
    [Fact]
    public async Task Can_Execute_Sql_to_rabbitMq()
    {
        var sourceAdapter = new SqlServerQuerySourceAdapter("SELECT CountryId AS Id, Name, Population, CreateDate, EditDate, NEWID() AS Etag FROM CountryMaster", 5, 
            "data source=LocalHost;user id=sa; password=Developer*123; database=CountrySource; pooling=false;encrypt=false");
        
        var targetAdapter = new RabbitMqTargetAdapter<ExpandoObject>(new Uri("rabbitmq://guest:guest@localhost:5672"),null!);
        
        var source = sourceAdapter.DataFlowSource;

        var idCols = new List<string> { "Id" };
        var compCols = new List<string> { "CreateDate", "EditDate" };

        var target = targetAdapter.Target;
        
        var metricsTarget = targetAdapter.MetricsTarget;
        
        // source
        //     .LinkTo(target)
        //     .LinkTo(metricsTarget);

        var level1 = source.LinkTo(target);
        var level2 = source.LinkTo(metricsTarget);
        
        
        await Network.ExecuteAsync(source);
    }
}