// Generated

#nullable enable

namespace {{codeGeneratorState.DomainNameSpace}};
{{- for enumAtt in enumerationAttributes }}

public partial class {{enumAtt.EntityNameForEnumeration}}: Nox.Domain.EnumerationBase
{    
   
}
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
public partial class {{enumAtt.EntityNameForLocalizedEnumeration}}: Nox.Domain.EnumerationLocalizedBase
{
    
}
    {{- end }}
{{- end }}
