// Generated
 
#nullable enable

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.DomainNameSpace}};

{{-keyAnnotation = '[PrimaryKey('}}
{{- for key in entity.Keys }}

    {{-keyAnnotation = keyAnnotation + 'nameof(' + key.Name + '),'}}

{{- end }}
{{-keyAnnotation = keyAnnotation + 'nameof(' + codeGeneratorState.LocalizationCultureField + '))]'}}
/// <summary>
/// {{entity.Description}}.
/// </summary>
{{keyAnnotation}}
internal partial class {{className}} : IEntity, IEntityConcurrent
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "EntityId" -}}
    public Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;    
    {{- else -}}
    public Nox.Types.{{key.Type}} {{key.Name}} { get; set; } = null!;    
    {{- end}}
{{- end }}

    public Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}} { get; set; } = null!;
{{- for attribute in entityAttributesToLocalize }}
    {{ if attribute.Type == "Text" }}

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