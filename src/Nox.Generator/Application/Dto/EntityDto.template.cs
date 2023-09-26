// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

public record {{entity.Name}}KeyDto({{primaryKeys}});

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}}
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();

    {{- for attribute in entity.Attributes }}

        {{- if attribute.Type == "Formula" || !IsNoxTypeReadable attribute.Type}} {{ continue; }} {{ end }}

        {{- if attribute.IsRequired }}
        ValidateField("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}.Create{{attribute.Name}}(this.{{attribute.Name}}), result);
        {{- else }}
        if (this.{{attribute.Name}} is not null)
        {{- if IsNoxTypeSimpleType attribute.Type }}
            ValidateField("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>()), result);
        {{- else }}
            ValidateField("{{attribute.Name}}", () => {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}.Create{{attribute.Name}}(this.{{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>()), result);
        {{- end}}
        {{- end }}
    {{- end}}

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
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
    {{ if IsNoxTypeSimpleType attribute.Type -}}
    public {{SinglePrimitiveTypeForKey attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
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
    public System.{{relationship.ForeignKeyPrimitiveType}}? {{relationship.Name}}Id { get; set; } = default!;
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
    public System.DateTime? DeletedAtUtc { get; set; }
{{- end }}
{{- if !entity.IsOwnedEntity }}

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
{{- end }}
}