using Nox.Domain;
using {{codeGeneratorState.DomainNameSpace}};
using MediatR;

{{-for event in entity.Events}}
/// <summary>
/// {{event.Description}}
/// </summary>
internal record {{event.Name}}({{entity.Name}} {{entity.Name}}) : IDomainEvent, INotification;
{{-end-}}