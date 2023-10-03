{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

public record {{entity.Name}}KeyDto({{primaryKeys}});

public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description}}.
/// </summary>
public abstract class {{className}}Base : EntityDtoBase, IEntityDto<{{entity.Name}}>
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
            ExecuteActionAndCollectValidationExceptions("{{key.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        else
            result.Add("{{key.Name}}", new [] { "{{key.Name}} is Required." });
            {{- else }}
        if (this.{{key.Name}} is not null)
            ExecuteActionAndCollectValidationExceptions("{{key.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        else
            result.Add("{{key.Name}}", new [] { "{{key.Name}} is Required." });
            {{- end }}
        {{- else }}
        if (this.{{attribute.Name}} is not null)
            ExecuteActionAndCollectValidationExceptions("{{key.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(this.{{key.Name}}), result);
        {{- end }}
    {{- end }}
    {{- end }}

    {{- for attribute in entity.Attributes }}
    {{- if attribute.Type == "Formula" || !IsNoxTypeReadable attribute.Type}} {{ continue; }} {{ end }}

    {{- if attribute.IsRequired }}
        {{- if IsValueType (attributeType attribute) }}
        ExecuteActionAndCollectValidationExceptions("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}), result);
        {{- else }}
        if (this.{{attribute.Name}} is not null)
            ExecuteActionAndCollectValidationExceptions("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{attributeType attribute}}>()), result);
        else
            result.Add("{{attribute.Name}}", new [] { "{{attribute.Name}} is Required." });
        {{- end }}
    {{ else }}
        if (this.{{attribute.Name}} is not null)
            ExecuteActionAndCollectValidationExceptions("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{attributeType attribute}}>()), result);
    {{- end }}
    {{- end}}

        return result;
    }
    #endregion

{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description}} (Required).
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
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{attributeType attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationship.Name}} { get; set; } = new();
    {{- else}}
        {{- if relationship.ShouldGenerateForeignOnThisSide}}
    //EF maps ForeignKey Automatically
    public {{relationship.ForeignKeyPrimitiveType}}? {{relationship.Name}}Id { get; set; } = default!;
        {{- end}}
    public virtual {{relationship.Entity}}Dto? {{relationship.Name}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationship.Name}} { get; set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}Dto{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}} { get; set; } = null!;
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