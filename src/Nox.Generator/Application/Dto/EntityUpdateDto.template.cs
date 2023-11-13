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
/// {{entity.Description  | string.rstrip}}
/// </summary>
public partial class {{className}} : IEntityDto<DomainNamespace.{{entity.Name}}>
{
{{- for attribute in entity.Attributes }}
    {{- if componentsInfo[attribute.Name].IsUpdatable == false -}}
    {{ continue; }}
    {{- end}}
    /// <summary>
    /// {{attribute.Description  | string.rstrip}} 
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>    
    /// </summary>
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{ end}}
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
    public {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}
{{- for relationship in entity.Relationships}}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.WithSingleEntity }}
    {{ if relationship.Relationship == "ExactlyOne" }}[Required(ErrorMessage = "{{relationshipName}} is required")]{{-end}}
    public {{relationship.ForeignKeyPrimitiveType}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}}Id { get; set; } = default!;
    {{-else}}
    public List<{{relationship.ForeignKeyPrimitiveType}}> {{relationshipName}}Id { get; set; } = new();
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships}}
    {{- if relationship.Relationship == "ZeroOrOne" || relationship.Relationship == "ExactlyOne"}}
    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    public {{relationship.Entity}}UpdateDto{{- if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
}