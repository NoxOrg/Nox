// Generated

namespace {{codeGeneratorState.DomainNameSpace}};
{{ for enumAttribute in enumAttributes }}
/// <summary>
/// {{enumAttribute.Description | string.rstrip}}{{if !(enumAttribute.Description | string.ends_with ".")}}.{{end}}
/// </summary> 
public enum {{ entity.Name }}{{ enumAttribute.Name }}Enum
{
    {{- for value in enumAttribute.Values }}
    /// <summary>
    /// {{ value.Name }}
    /// </summary>
    {{ value.SanitizedName }} = {{ value.Id }},
    {{ end }}
}
{{ end }}