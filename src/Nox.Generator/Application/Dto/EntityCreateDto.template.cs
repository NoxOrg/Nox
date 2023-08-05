// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto; 

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}}
{
{{- for attribute in entity.Attributes }}
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
    public {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}= default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}= default!;{{end}}
    {{- end}}
{{- end }}
}