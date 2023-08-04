// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace {{codeGeneratorState.ODataNameSpace }};

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}}
{
{{- for attribute in entity.Attributes }}
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{keysFlattenComponentsTypeName[attribute.Name]}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}=default!;{{end}}
{{- end }}
}