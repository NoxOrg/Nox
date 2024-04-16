using ETLBox.DataFlow;

namespace Nox.Integration.EtlTests.Json;

public class TargetDto: MergeableRow
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? EditDate { get; set; }
    public Guid Etag { get; set; }
}