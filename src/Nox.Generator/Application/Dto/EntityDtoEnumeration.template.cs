// Generated
{{- cultureCode = ToLowerFirstChar codeGenConventions.LocalizationCultureField }}
#nullable enable

using System.Data.Common;
namespace {{codeGenConventions.DtoNameSpace}};
{{- for enumAtt in enumerationAttributes }}

public partial record {{enumAtt.EntityNameForEnumeration}}: Nox.Application.Dto.EnumerationDtoBase
{    
   
}
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}

public record {{enumAtt.EntityNameForLocalizedEnumeration}}KeyDto(System.Int32 Id, System.String {{cultureCode}});

public partial record {{enumAtt.EntityDtoNameForLocalizedEnumeration}}: Nox.Application.Dto.EnumerationLocalizedDtoBase
{
    
}

public partial record {{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}: Nox.Application.Dto.EnumerationLocalizedUpsertDtoBase
{

}

    {{- end }}
{{- end }}
