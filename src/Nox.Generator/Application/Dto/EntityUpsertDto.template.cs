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

using DomainNamespace = {{codeGeneratorState.DomainNameSpace}};

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
public abstract class {{className}}Base: EntityDtoBase, IEntityDto<DomainNamespace.{{entity.Name}}>
{
{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description  | string.rstrip}}
    /// </summary>    
    {{- if key.Type == "EntityId" }}
    public virtual {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}}? {{key.Name}} { get; set; }
    {{- else }}
    public virtual {{SinglePrimitiveTypeForKey key}}? {{key.Name}} { get; set; }
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}
    {{- if componentsInfo[attribute.Name].IsCreatable == false || componentsInfo[attribute.Name].IsUpdatable == false -}}
    {{ continue; }}
    {{- end}}

    /// <summary>
    /// {{attribute.Description  | string.rstrip}}     
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>    
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{- end}}
    public virtual {{attributeType attribute}}? {{attribute.Name}} { get; set; }
{{- end }}
}