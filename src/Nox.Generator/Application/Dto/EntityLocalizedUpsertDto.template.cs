{{- func keyPrimitiveType(key)
	ret (key.Type == "EntityId") ? (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key)
end -}}
{{- func attributeType(attribute)
	ret componentsInfo[attribute.Name].IsSimpleType ? componentsInfo[attribute.Name].ComponentType : (attribute.Type + "Dto")
end -}}
{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGenConventions.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Name}} Localized Upsert DTO.
/// </summary>
public partial class {{className}}
{
    {{- if entity.OwningRelationship?.WithMultiEntity }}
    {{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description  | string.rstrip}}
    /// </summary>
    [Required(ErrorMessage = "{{key.Name}} is required")]
    public {{keyPrimitiveType key}}? {{key.Name}} { get; set; }

    {{- end }}
    {{- end }}
    {{- for attribute in entityAttributesToLocalize }}
    /// <summary>
    /// {{attribute.Description |  string.rstrip}}
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>
    public {{attributeType attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
}