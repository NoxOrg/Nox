using Nox.Integration.Abstractions.Models;
using Nox.Solution;

namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseProcedureSourceAdapter: INoxSourceAdapter
{
    string ProcedureName { get; }
    List<IntegrationSourceProcedureParameter> Parameters { get; }
}

public interface INoxDatabaseProcedureSourceAdapter<TSource> : INoxSourceAdapter<TSource>
{
    string ProcedureName { get; }
    List<IntegrationSourceProcedureParameter> Parameters { get; }
}