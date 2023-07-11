using System.ComponentModel.Design;
using Nox.Solution;

namespace Nox.Etl.Abstractions;

public interface IEtlExecutor
{
    Task<bool> ExecuteAsync(string integrationName);
}