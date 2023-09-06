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
using {{entity.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}};

public partial class {{className}} : EntityMapperBase<{{entity.Name}}>
{
    public {{className}}(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity({{entity.Name}} entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    {{ for key in entity.Keys -}}
    {{- if key.Type == "Nuid" || key.Type == "DatabaseNumber" || key.Type == "DatabaseGuid" || key.Type == "Formula" -}}
    {{ continue; -}}
    {{- end }}        
    {{ if key.Type == "EntityId" -}}
        noxTypeValue = CreateNoxType<Nox.Types.{{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}}>(entityDefinition, "{{key.Name}}", dto.{{key.Name}});
    {{- else -}}
        noxTypeValue = CreateNoxType<Nox.Types.{{key.Type}}>(entityDefinition, "{{key.Name}}", dto.{{key.Name}});
    {{- end}}        
        if (noxTypeValue != null)
        {        
            entity.{{key.Name}} = noxTypeValue;
        }
    {{- end -}}

    {{ for attribute in entity.Attributes }}  
    {{- if attribute.Type == "Formula" -}}
    {{ continue; -}}
    {{- end }}        
        noxTypeValue = CreateNoxType<Nox.Types.{{attribute.Type}}>(entityDefinition, "{{attribute.Name}}", dto.{{attribute.Name}});
        if (noxTypeValue != null)
        {        
            entity.{{attribute.Name}} = noxTypeValue;
        }        
    {{- end }}
    {{ for relationship in entity.Relationships }}
    {{- if relationship.WithSingleEntity && relationship.ShouldGenerateForeignOnThisSide}}

        /// <summary>
        /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.{{relationship.Related.Entity.Keys[0].Type}}>(entityDefinition, "{{relationship.Name}}", dto.{{relationship.Name}}Id);
        if (noxTypeValue != null)
        {        
            entity.{{relationship.Name}}Id = noxTypeValue;
        }
    {{-end}}
    {{- end }}
    }

    public override void PartialMapToEntity({{entity.Name}} entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
    {{- for attribute in entity.Attributes
        if !IsNoxTypeUpdatable attribute.Type
            continue
        end
    }}
        {
            if (updatedProperties.TryGetValue("{{attribute.Name}}", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.{{attribute.Type}}>(entityDefinition, "{{attribute.Name}}", value);
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
    
    {{ for relationship in entity.Relationships }}

    {{- if relationship.WithSingleEntity && relationship.ShouldGenerateForeignOnThisSide}}
        /// <summary>
        /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
        /// </summary>
        if (updatedProperties.TryGetValue("{{relationship.Entity}}Id", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.{{relationship.Related.Entity.Keys[0].Type}}>(entityDefinition, "{{relationship.Name}}", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.{{relationship.Name}}Id = noxRelationshipTypeValue;
            }
        }
    {{-end}}
    {{- end }}
    }
}