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
using Nox.Exceptions;
using ClientApi.Application.Dto;
using ClientApi.Domain;


namespace ClientApi.Application;

public class OwnedEntityMapper: EntityMapperBase<OwnedEntity>
{
    public  OwnedEntityMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(OwnedEntity entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(OwnedEntity entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        { 
            if (updatedProperties.TryGetValue("Name", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("OwnedEntity", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
    }  
}