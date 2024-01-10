using Nox.Domain;
using {{codeGeneratorState.DomainNameSpace}};
using MediatR;

{{ for event in entity.Events }}
/// <summary>
{{~ if event.Description ~}}
/// {{event.Description | string.rstrip}}
{{~else~}}
/// {{event.Name}}
{{~end~}}
/// </summary>
internal record {{event.Name}}({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{ end }}