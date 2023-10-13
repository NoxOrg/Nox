// Generated
{{func toLower(text)
	if text == ""
        ret ""
    end
    ret text | string.downcase
end}}
#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.IntegrationEvents;

/// <summary>
/// {{entity.Name}}{{operation}} integration event.
/// </summary>
[IntegrationEventType("{{operation | toLower}}", nameof({{entity.Name}}))]
internal record {{entity.Name}}{{operation}}({{entity.Name}}Dto {{entity.Name}}) :  IIntegrationEvent;