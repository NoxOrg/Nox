{{- func keyPrimitiveType(key)
	ret (key.Type == "EntityId") ? (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key)
end -}}
{{- func attributeType(attribute)
	ret componentsInfo[attribute.Name].IsSimpleType ? componentsInfo[attribute.Name].ComponentType : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public abstract class {{className}}Base : IEntityDto<DomainNamespace.{{entity.Name}}>
{
{{- for key in entity.Keys }}
    {{- if !IsNoxTypeCreatable key.Type -}}    
    {{ continue; -}}
    {{- else if key.Type == "Guid" -}}
    /// <summary>
    /// {{key.Description  | string.rstrip}}     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    {{- else }}
    /// <summary>
    /// {{key.Description  | string.rstrip}}    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "{{key.Name}} is required")]
    {{- end }}
    public virtual {{keyPrimitiveType key}}? {{key.Name}} { get; set; }
{{- end }}

{{- for attribute in entity.Attributes }}
    {{- if !IsNoxTypeCreatable attribute.Type -}}
    {{ continue; -}}
    {{- end }}
    /// <summary>
    /// {{attribute.Description  | string.rstrip}}     
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}</remarks>
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{ end}}
    public virtual {{attributeType attribute}}? {{attribute.Name}} { get; set; }
{{- end }}

{{- for relationship in entity.Relationships}}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.WithSingleEntity }}
    public {{relationship.ForeignKeyPrimitiveType}}? {{relationshipName}}Id { get; set; } = default!;
    {{#Simplify Avoid complexity by not allowing circular dependency between dtos
    #User Can set a relationship on the creation phase using the id (entity already exists), for single relations}}
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual {{relationship.Entity}}CreateDto? {{relationshipName}} { get; set; } = default!;
    {{- else }}
    public virtual List<{{relationship.ForeignKeyPrimitiveType}}> {{relationshipName}}Id { get; set; } = new();
    {{#Simplify Avoid complexity by not allowing circular dependency between dtos}}
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<{{relationship.Entity}}CreateDto> {{relationshipName}} { get; set; } = new();
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.WithSingleEntity }}
    public virtual {{relationship.Entity}}UpsertDto{{- if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}} { get; set; } = null!;
    {{- else}}
    public virtual List<{{relationship.Entity}}UpsertDto> {{relationshipName}} { get; set; } = new();
    {{-end}}
{{- end }}
}