{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Description}} Localized DTO.
/// </summary>
public partial class {{className}}
{ 
{{- keys = '' -}}
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
{{- if key.Type == "EntityId" -}}
    {{ keys = keys | string.append (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) + " " + key.Name + ", " }}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
{{- else }}
    {{ keys = keys | string.append (SinglePrimitiveTypeForKey key) + " " + key.Name + ", "  }}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
{{- end}}
{{ end }}
    public System.String {{codeGeneratorState.LocalizationCultureField}} { get; set; } = default!;
{{ for attribute in entityAttributesToLocalize }}
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{attributeType attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{ end }}
    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}

/// <summary>
/// Record for {{entity.Name}} Localized Key DTO.
/// </summary>
public record {{entity.Name}}LocalizedKeyDto({{keys}}System.String {{codeGeneratorState.LocalizationCultureField}});