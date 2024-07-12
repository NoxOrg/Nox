using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Models;
using Nox.Solution;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerProcedureSourceAdapterBase
{
    internal readonly SqlConnectionManager BaseConnectionManager;
    internal string BaseProcedureName;
    internal List<IntegrationSourceProcedureParameter> BaseParameters;

    public static IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseProcedure;

    protected SqlServerProcedureSourceAdapterBase(string procedureName, List<IntegrationSourceProcedureParameter> parameters, string connectionString)
    {
        BaseProcedureName = procedureName;
        BaseParameters = parameters;
        BaseConnectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }

}