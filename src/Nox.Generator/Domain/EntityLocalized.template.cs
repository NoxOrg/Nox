// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.DomainNameSpace}};

/// <summary>
/// {{entity.Description}}.
/// </summary>
internal partial class {{className}} : IEntityConcurrent
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
{{- if key.Type == "EntityId" -}}
    public Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;    
{{- else }}
    public Nox.Types.{{key.Type}} {{key.Name}} { get; set; } = null!;    
{{- end }}
{{- end }}

    public Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}} { get; set; } = null!;
{{ for attribute in entityAttributesToLocalize }}
    /// <summary>
    /// {{attribute.Description}} (Optional).
    /// </summary>
    public Nox.Types.{{attribute.Type}}? {{attribute.Name}} { get; set; } = null!;
{{ end }}
    public virtual {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}} {{entity.Name}} { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}