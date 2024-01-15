{{- func attributeType(attribute)
	ret componentsInfo[attribute.Name].IsSimpleType ? componentsInfo[attribute.Name].ComponentType : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class {{className}}Base: EntityDtoBase
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
    public virtual {{attributeType attribute}}? {{attribute.Name}} { get; set; }
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