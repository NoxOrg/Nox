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
internal abstract partial class {{className}} : IEntityConcurrent
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "EntityId" -}}
    public Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;
    {{- # Navigation Property }}

    public virtual {{key.EntityIdTypeOptions.Entity}} {{key.EntityIdTypeOptions.Entity}} { get; set; } = null!;

    {{- else -}}

    public Nox.Types.{{key.Type}} {{key.Name}} { get; set; } = null!;
    {{- end}}
{{- end }}

      public Nox.Types.CultureCode CultureCode { get; set; } = null!;
{{- for attribute in entityAttributesToLocalize }}
    {{ if attribute.Type == "Text" && attribute.TextTypeOptions.IsLocalized }}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public Nox.Types.{{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
    {{- end}}
{{- end }}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}