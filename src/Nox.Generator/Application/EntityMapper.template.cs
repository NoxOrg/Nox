// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
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
    {{- if attribute.Type == "DateTimeDuration" || attribute.Type == "CountryNumber" || attribute.Type == "Boolean" || attribute.Type == "LatLong" || attribute.Type == "TranslatedText" || attribute.Type == "File" || attribute.Type == "VatNumber" || attribute.Type == "StreetAddress" || attribute.Type == "Money" || attribute.Type == "Text" || attribute.Type == "Number" || attribute.Type == "Area"  || attribute.Type == "TimeZoneCode" || attribute.Type == "Uri" || attribute.Type == "Url" || attribute.Type == "User" || attribute.Type == "Volume" || attribute.Type == "Weight" || attribute.Type == "Yaml" || attribute.Type == "PhoneNumber" || attribute.Type == "Temperature" || attribute.Type == "Percentage" }}
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
}