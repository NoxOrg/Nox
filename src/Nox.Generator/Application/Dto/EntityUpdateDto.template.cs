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
/// Patch entity {{entity.Name}}: {{entity.Description  | string.rstrip}}.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class {{entity.Name}}PatchDto: {{className}}
{
    {{# TODO create a subtemplate concept to apply both to Patch and Update Dto }}
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
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>    
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{ end}}
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
    public virtual {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public virtual {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}
{{- # for relationship in entity.Relationships # see NOX-237 to enable relationships in UpdateDto}}
{{- for relationship in entity.OwnedRelationships}}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}
    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.WithSingleEntity }}
    public virtual {{relationship.Entity}}UpsertDto{{- if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}} { get; set; } = null!;
    {{- else }}
    public virtual List<{{relationship.Entity}}UpsertDto> {{relationshipName}} { get; set; } = new();
    {{-end}}
{{- end }}
}