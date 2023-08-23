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
using IamApi.Application.Dto;
using IamApi.Domain;

namespace IamApi.Application;

public class ApplicationIAMMapper: EntityMapperBase<ApplicationIAM>
{
    public  ApplicationIAMMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(ApplicationIAM entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",dto.FirstName);
        if(noxTypeValue != null)
        {        
            entity.FirstName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",dto.LastName);
        if(noxTypeValue != null)
        {        
            entity.LastName = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(ApplicationIAM entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("FirstName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("ApplicationIAM", "FirstName");
                }
                else
                {
                    entity.FirstName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("ApplicationIAM", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
    }
}