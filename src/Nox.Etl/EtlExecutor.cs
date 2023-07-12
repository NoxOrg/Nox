using Nox.Etl.Abstractions;

namespace Nox.Etl;

public class EtlExecutor: IEtlExecutor
{
    public async Task<bool> ExecuteAsync(string integrationName)
    {
        return false;
    }
}