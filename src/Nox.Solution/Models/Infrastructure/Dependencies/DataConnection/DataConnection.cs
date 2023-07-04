using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for a data connection pertaining to a Nox solution.")]
    [Description("Configure properties pertinent to a data connection in a Nox solution here. Properties include name, serverUri, Port, connection credentials and provider.")]
    [AdditionalProperties(false)]
    public class DataConnection : ServerBase
    {
        [Required]
        [Title("The data connection provider/format.")]
        [Description("The provider/format used for this data connection. Possible data formats include Json, Excel, CSV, XML and Parquet.")]
        [AdditionalProperties(false)]
        public DataConnectionProvider? Provider { get; internal set; }
    }
}