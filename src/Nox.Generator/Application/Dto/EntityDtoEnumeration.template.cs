// Generated

#nullable enable

namespace {{codeGeneratorState.DtoNameSpace}};
{{- for enumAtt in enumerationAttributes }}

public partial record {{enumAtt.EntityNameForEnumeration}}: Nox.Application.Dto.EnumerationDtoBase
{    
   
}
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
public partial record {{enumAtt.EntityNameForLocalizedEnumeration}}: Nox.Application.Dto.EnumerationLocalizedDtoBase
{
    
}
    {{- end }}
{{- end }}
