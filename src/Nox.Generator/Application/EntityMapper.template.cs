// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.DomainNameSpace}};


namespace {{codeGeneratorState.ApplicationNameSpace}};

public class {{className}}: EntityMapperBase<{{entity.Name}}>
{
    public  {{className}}(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity({{entity.Name}} entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    {{ for attribute in entity.Attributes }}
    {{- #to be removed when we support all types -}}
    {{- if attribute.Type == "Year" || attribute.Type == "DateTime" || attribute.Type == "Formula" || attribute.Type == "Html" || attribute.Type == "Guid" || attribute.Type == "CurrencyCode3" ||  attribute.Type == "CultureCode"|| attribute.Type == "IpAddress" || attribute.Type == "Markdown" ||  attribute.Type == "CountryNumber" || attribute.Type == "Distance" || attribute.Type == "Boolean" || attribute.Type == "LatLong" || attribute.Type == "TranslatedText" || attribute.Type == "File" || attribute.Type == "VatNumber" || attribute.Type == "StreetAddress" || attribute.Type == "Money" || attribute.Type == "Text" || attribute.Type == "Number" || attribute.Type == "Length" || attribute.Type == "Area"  || attribute.Type == "Email" || attribute.Type == "TimeZoneCode" || attribute.Type == "MacAddress" || attribute.Type == "Uri" || attribute.Type == "Url" || attribute.Type == "User" || attribute.Type == "Volume" || attribute.Type == "Weight" || attribute.Type == "Yaml" || attribute.Type == "PhoneNumber" || attribute.Type == "Temperature" || attribute.Type == "Percentage" || attribute.Type == "CountryCode2" || attribute.Type == "CountryCode3" }}
        noxTypeValue = CreateNoxType<Nox.Types.{{attribute.Type}}>(entityDefinition,"{{attribute.Name}}",dto.{{attribute.Name}});
        if(noxTypeValue != null)
        {        
            entity.{{attribute.Name}} = noxTypeValue;
        }
    {{- else }}

        // TODO map {{attribute.Name}} {{attribute.Type}} remaining types and remove if else
    {{- end}}        
    {{- end }}
    }

    public override void PartialMapToEntity({{entity.Name}} entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
    {{- for attribute in entity.Attributes
        if !IsNoxTypeUpdatable attribute.Type
            continue
        end
    }}
        { 
            if (updatedProperties.TryGetValue("{{attribute.Name}}", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.{{attribute.Type}}>(entityDefinition,"{{attribute.Name}}",value);
                if(noxTypeValue == null)
                {       
                    {{- if attribute.IsRequired }}
                    throw new EntityAttributeIsNotNullableException("{{entity.Name}}", "{{attribute.Name}}");
                    {{- else }}
                    entity.{{attribute.Name}} = null;
                    {{- end}}
                }
                else
                {
                    entity.{{attribute.Name}} = noxTypeValue;
                }
            }
        }
    {{- end }}
    }  
}