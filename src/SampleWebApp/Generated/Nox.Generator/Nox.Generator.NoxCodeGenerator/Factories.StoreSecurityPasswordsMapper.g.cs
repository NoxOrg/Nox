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
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class StoreSecurityPasswordsMapper: EntityMapperBase<StoreSecurityPasswords>
{
    public  StoreSecurityPasswordsMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(StoreSecurityPasswords entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"SecurityCamerasPassword",dto.SecurityCamerasPassword);
        if(noxTypeValue != null)
        {        
            entity.SecurityCamerasPassword = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(StoreSecurityPasswords entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, List<string> deletedPropertyNames)
    {

    }
}