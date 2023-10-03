
{{- if integrationEvent.ArrayTypeOptions -}}
{{ isArray = true -}}
{{ nestedClassName = integrationEvent.ArrayTypeOptions.Name -}}
{{ attributes = integrationEvent.ArrayTypeOptions.ObjectTypeOptions.Attributes -}}
{{- else if integrationEvent.CollectionTypeOptions -}}
{{ isCollection = true -}}
{{ nestedClassName = integrationEvent.CollectionTypeOptions.Name -}}
{{ attributes = integrationEvent.CollectionTypeOptions.ObjectTypeOptions.Attributes -}}
{{- else if integrationEvent.ObjectTypeOptions -}}
{{ isObject = true -}}
{{ attributes = integrationEvent.ObjectTypeOptions.Attributes -}}
{{- end -}}
// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

{{ if isCollection -}}using System.Collections.Generic;{{ end}}

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

{{ if integrationEvent.Description -}}
/// <summary>
/// {{integrationEvent.Description}}{{if !(integrationEvent.Description | string.ends_with ".")}}.{{end}}
/// </summary>
{{ end -}}
public partial class {{className}} : IIntegrationEvent
{
{{- if isObject -}}
{{- for attribute in attributes -}}
{{- if attribute.Description }} 
    /// <summary>
    /// {{attribute.Description}}{{if !(attribute.Description | string.ends_with ".")}}.{{end}}
    /// </summary>
{{- end }}
{{- if IsNoxTypeSimpleType attribute.Type }}
    public {{SinglePrimitiveTypeForKey attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- else }}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
{{ end -}}
{{ else }}
    public {{if isArray}}{{nestedClassName}}[]{{else}}IEnumerable<{{nestedClassName}}>{{end}} {{nestedClassName}}s { get; set; } = default!;
{{ end -}}
}
{{- if isArray || isCollection }}

public class {{nestedClassName}}
{
{{- for attribute in attributes -}}
{{- if attribute.Description }} 
    /// <summary>
    /// {{attribute.Description}}{{if !(attribute.Description | string.ends_with ".")}}.{{end}}
    /// </summary>
{{- end }}
{{- if IsNoxTypeSimpleType attribute.Type }}
    public {{SinglePrimitiveTypeForKey attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- else }}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
{{ end -}}
}
{{ end -}}