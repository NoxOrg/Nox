using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Solution;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerProcedureSource<TOutput>: DatabaseProcedureSource<TOutput>, IDatabaseProcedureSource<TOutput> where TOutput: new()
{
    public void CreateParameters(List<IntegrationSourceProcedureParameter>? parameters)
    {
        if (parameters == null || !parameters.Any()) return;
        Parameters = new List<DbParameter>();
        foreach (var param in parameters)
        {
            var dbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), param.DataType, true);
            Parameters.Add(new SqlParameter
            {
                ParameterName = param.Name.StartsWith('@') ? param.Name : '@' + param.Name,
                Direction = ParameterDirection.Input,
                SqlDbType = dbType
            });
        }
    }
}