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
{{- for key in entityKeys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
{{- if key.Type == "EntityId" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
{{- else }}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
{{- end}}
{{ end }}
    public System.String {{codeGeneratorState.LocalizationCultureField}} { get; set; } = default!;
{{ for attribute in entityLocalizedAttributes }}
    /// <summary>
    /// {{attribute.Description}} (Optional).
    /// </summary>
    public {{attributeType attribute}}? {{attribute.Name}} { get; set; }
{{ end }}
    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}