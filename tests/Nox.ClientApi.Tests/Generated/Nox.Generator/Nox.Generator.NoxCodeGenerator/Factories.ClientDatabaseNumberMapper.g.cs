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
using ClientApi.Application.Dto;
using ClientApi.Domain;


namespace ClientApi.Application;

public class ClientDatabaseNumberMapper: EntityMapperBase<ClientDatabaseNumber>
{
    public  ClientDatabaseNumberMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(ClientDatabaseNumber entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"Number",dto.Number);
        if(noxTypeValue != null)
        {        
            entity.Number = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(ClientDatabaseNumber entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames)
    {    
        if(deletedPropertyNames.Contains("Name"))
        {
            throw new EntityAttributeIsNotNullableException("ClientDatabaseNumber", "Name");
        }
        else if (updatedProperties.TryGetValue("Name", out dynamic? value))
        {
            var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",value);
            if(noxTypeValue == null)
            {
                throw new EntityAttributeIsNotNullableException("ClientDatabaseNumber", "Name");
            }
            else
            {
                entity.Name = noxTypeValue;
            }
        }    
        if(deletedPropertyNames.Contains("Number"))
        {
            entity.Number = null;
        }
        else if (updatedProperties.TryGetValue("Number", out dynamic? value))
        {
            var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"Number",value);
            if(noxTypeValue == null)
            {
                entity.Number = null;
            }
            else
            {
                entity.Number = noxTypeValue;
            }
        }
    }
}