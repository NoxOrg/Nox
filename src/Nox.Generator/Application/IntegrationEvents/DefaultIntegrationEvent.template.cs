// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

{{ if entity.Persistence.Create.RaiseIntegrationEvents -}}
/// <summary>
/// {{entity.Name}} created integration event.
/// </summary>
internal record {{entity.Name}}Created({{entity.Name}}Dto {{entity.Name}}) :  IIntegrationEvent;
{{- end }}

{{ if entity.Persistence.Update.RaiseIntegrationEvents -}}
/// <summary>
/// {{entity.Name}} updated integration event.
/// </summary>
internal record {{entity.Name}}Updated({{entity.Name}}Dto {{entity.Name}}) : IIntegrationEvent;
{{- end }}

{{ if entity.Persistence.Delete.RaiseIntegrationEvents -}}
/// <summary>
/// {{entity.Name}} deleted integration event.
/// </summary>
internal record {{entity.Name}}Deleted({{entity.Name}}Dto {{entity.Name}}) : IIntegrationEvent;
{{ end -}}