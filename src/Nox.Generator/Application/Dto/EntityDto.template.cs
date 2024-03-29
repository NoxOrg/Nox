{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace {{codeGenConventions.ApplicationNameSpace}}.Dto;

public record {{entity.Name}}KeyDto({{primaryKeys}});

/// <summary>
/// Update {{entity.Name}}
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description  | string.rstrip}}.
/// </summary>
public abstract class {{className}}Base : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    {{ for key in entity.Keys }}
    {{- if key.Type == "EntityId" }}
        {{- if key.IsRequired }}        
            {{- if IsValueType (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) }}
        if(this.{{key.Name}} != default({{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}}))
            CollectValidationExceptions("{{key.Name}}", () => {{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        else
            result.Add("{{key.Name}}", new [] { "{{key.Name}} is Required." });
            {{- else }}
        if (this.{{key.Name}} is not null)
            CollectValidationExceptions("{{key.Name}}", () => {{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        else
            result.Add("{{key.Name}}", new [] { "{{key.Name}} is Required." });
            {{- end }}
        {{- else }}
        if (this.{{attribute.Name}} is not null)
            CollectValidationExceptions("{{key.Name}}", () => {{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        {{- end }}
    {{- end }}
    {{- end }}

    {{- for attribute in entity.Attributes }}
    {{- if attribute.Type == "Formula" || !IsNoxTypeReadable attribute.Type}} {{ continue; }} {{ end }}

    {{- if attribute.IsRequired }}
        {{- if IsValueType (attributeType attribute) }}
        CollectValidationExceptions("{{attribute.Name}}", () => {{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}), result);
        {{- else }}
        if (this.{{attribute.Name}} is not null)
            CollectValidationExceptions("{{attribute.Name}}", () => {{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{attributeType attribute}}>()), result);
        else
            result.Add("{{attribute.Name}}", new [] { "{{attribute.Name}} is Required." });
        {{- end }}
    {{ else }}
        if (this.{{attribute.Name}} is not null)
            CollectValidationExceptions("{{attribute.Name}}", () => {{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{attributeType attribute}}>()), result);
    {{- end }}
    {{- end}}

        return result;
    }
    #endregion

{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description  | string.rstrip}}
    /// </summary>    
    {{ if key.Type == "EntityId" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
    {{- else -}}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}
    {{- if !IsNoxTypeReadable attribute.Type -}}
        {{ continue; }}
    {{- end}}

    /// <summary>
    /// {{attribute.Description  | string.rstrip}}     
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>
    {{- type = (attribute.Type == "Formula") ? attribute.FormulaTypeOptions.Returns : (attributeType attribute) }}
    public {{type}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- if attribute.Type == "Enumeration"}}
    public string{{ if !attribute.IsRequired}}?{{end}} {{ attribute.Name}}Name { get; set; } = default!;
    {{- end}}
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationshipName}} { get; set; } = new();
    {{- else}}
        {{- if relationship.IsForeignKeyOnThisSide}}
    //EF maps ForeignKey Automatically
    public {{relationship.ForeignKeyPrimitiveType}}? {{relationshipName}}Id { get; set; } = default!;
        {{- end}}
    public virtual {{relationship.Entity}}Dto? {{relationshipName}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationshipName}} { get; set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}Dto{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationshipName}} { get; set; } = null!;
    {{-end}}
{{- end }}

{{- if !entity.IsOwnedEntity && entity.Persistence?.IsAudited == true}}
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }
{{- end }}
{{- if !entity.IsOwnedEntity }}

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
{{- end }}
}