using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("The definition namespace for dependencies pertaining to a Nox solution.")]
[Description("Define dependencies pertinent to a Nox solution here. These include translations, data connections, notifications and other.")]
[AdditionalProperties(false)]
public class Dependencies
{
    public UiLocalizations? UiLocalizations { get; internal set; }

    [Title("The definition namespace for data connections pertaining to a Nox solution.")]
    [Description("Define data connections pertinent to a Nox solution here. Possible data formats include Json, Excel, CSV, XML and Parquet.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<DataConnection>? DataConnections { get; internal set; }

    public Notifications? Notifications { get; internal set; }

    public Monitoring? Monitoring { get; internal set; }
}