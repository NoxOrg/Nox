// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

{{ if integrationEvent.Description -}}
/// <summary>
/// {{integrationEvent.Description}}{{if !(integrationEvent.Description | string.ends_with ".")}}.{{end}}
/// </summary>
{{ end -}}
public partial class {{className}} : IIntegrationEvent
{
{{- if integrationEvent.ObjectTypeOptions -}}
{{- for attribute in integrationEvent.ObjectTypeOptions.Attributes -}}
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
{{ end -}}
}
