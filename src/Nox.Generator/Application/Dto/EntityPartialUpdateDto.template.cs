// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

{{ #We Split Partial from Update Dto, so this one gets registered as a complextype in Odata for Delta to work properly }}

/// <summary>
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description  | string.rstrip}}
/// </summary>
public partial class {{className}}Base: EntityDtoBase, IEntityDto<DomainNamespace.{{entity.Name}}>
{
{{- for attribute in entity.Attributes }}
    {{- if componentsInfo[attribute.Name].IsUpdatable == false -}}
    {{ continue; }}
    {{- end}}
    /// <summary>
    /// {{attribute.Description  | string.rstrip}}
    /// </summary>
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
    public virtual {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public virtual {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}
}