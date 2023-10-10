// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

/// <summary>
/// {{entity.Name}}{{crudOperation}} integration event.
/// </summary>
internal record {{entity.Name}}{{crudOperation}}({{entity.Name}}Dto {{entity.Name}}) :  IIntegrationEvent;