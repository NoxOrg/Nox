using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Integration.Options;
using Nox.Integration.Services;

namespace Nox.Integration.Tests;

public class IntegrationTests
{
    public async Task Can_Execute_an_integration()
    {
        var integration = new NoxIntegration("EtlTest", "This is a test Integration")
        {
            SendAdapter = new SqlServerSendAdapter
            {
                DatabaseOptions = new NoxSendAdapterDatabaseOptions
                {
                    StoredProcedure = "up_CreateTestRecord"
                }
            }
        };
    }
}