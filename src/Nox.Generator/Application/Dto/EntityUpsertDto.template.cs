// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

/// <summary>
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description  | string.rstrip}}
/// </summary>
public abstract class {{className}}Base: EntityDtoBase, IEntityDto<DomainNamespace.{{entity.Name}}>
{
{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description  | string.rstrip}}
    /// </summary>    
    {{- if key.Type == "EntityId" }}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}}? {{key.Name}}
    {{- else }}
    public {{SinglePrimitiveTypeForKey key}}? {{key.Name}} { get; set; }
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}
    {{- if componentsInfo[attribute.Name].IsCreatable == false || componentsInfo[attribute.Name].IsUpdatable == false -}}
    {{ continue; }}
    {{- end}}

    /// <summary>
    /// {{attribute.Description  | string.rstrip}}     
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>    
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{- end}}
    {{- if componentsInfo[attribute.Name].IsSimpleType }}
    public virtual {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else }}
    public virtual {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}
}