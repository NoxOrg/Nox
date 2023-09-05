// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace {{codeGeneratorState.DomainNameSpace}};

/// <summary>
/// Static methods for the {{entity.Name}} class.
/// </summary>
public partial class {{className}}
{
{{- for entry in propertiesWithSource }}
    /// <summary>
    /// Type options and factory for property '{{entry.TypeDef.Name}}'
    /// </summary>
    {{entry.Source}}

{{- end }}
}