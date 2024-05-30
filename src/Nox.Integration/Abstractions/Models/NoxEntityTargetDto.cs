using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Models;

public class NoxEntityTargetDto: MergeableRow
{
    public Guid Etag { get; } = Guid.NewGuid();
}