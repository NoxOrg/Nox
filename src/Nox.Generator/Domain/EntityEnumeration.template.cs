// Generated

#nullable enable

namespace {{codeGeneratorState.DomainNameSpace}};
{{- for enumAtt in enumerationAttributes }}

public partial class {{entity.Name}}{{enumAtt.Name}}: Nox.Domain.EnumTypeBase
{    
   
}
    {{- if enumAtt.EnumerationTypeOptions.IsLocalized}}
public partial class {{entity.Name}}{{enumAtt.Name}}Localized: Nox.Domain.EnumTypeLocalizedBase
{
    
}
    {{- end }}
{{- end }}
