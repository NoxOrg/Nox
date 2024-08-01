// Generated
#nullable enable

using ETLBox.DataFlow;

namespace CryptocashIntegration.Application.Integration.CustomTransform;

public sealed class JsonToTableSourceDto
{
    public System.Int64? CountryId { get; set; }
    public System.String? CountryName { get; set; }
    public System.Int64? NoOfInhabitants { get; set; }
    public System.DateTimeOffset CreateDate { get; set; }
    public System.DateTimeOffset? EditDate { get; set; }
    public System.Int32? PopulationMillions { get; set; }
    public System.String? NameWithConcurrency { get; set; }
    public System.String? ConcurrencyStamp { get; set; }
}