// Generated

#nullable enable

using ETLBox.DataFlow;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public sealed class JsonToTableTargetDto: MergeableRow
{
    public System.Int32 Id { get; set; }
    public System.String Name { get; set; } = String.Empty;
    public System.Int32 Population { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.DateTime? EditDate { get; set; }
    public System.Int32? PopulationMillions { get; set; }
}