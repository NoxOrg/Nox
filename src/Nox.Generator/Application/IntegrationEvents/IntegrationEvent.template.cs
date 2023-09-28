// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

{{ if integrationEvent.Description -}}
/// <summary>
/// {{integrationEvent.Description}}{{if !(integrationEvent.Description | string.ends_with ".")}}.{{end}}
/// </summary>
{{ end -}}
public partial class {{integrationEvent.Name}} : IIntegrationEvent
{
{{- if integrationEvent.ObjectTypeOptions -}}
{{- for attribute in integrationEvent.ObjectTypeOptions.Attributes -}}
{{- if attribute.Description }} 
    /// <summary>
    /// {{attribute.Description}}{{if !(attribute.Description | string.ends_with ".")}}.{{end}}
    /// </summary>
{{- end }}
    public Nox.Types.{{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
{{ end -}}
{{ end -}}
}
