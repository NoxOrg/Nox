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

public class PhoneMapper: EntityMapperBase<Phone>
{
    public  PhoneMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Phone entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition, "PhoneNumber", dto.PhoneNumber);        
        if(noxTypeValue != null)
        {        
            entity.PhoneNumber = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"IsVerified",dto.IsVerified);
        if(noxTypeValue != null)
        {        
            entity.IsVerified = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryCode",dto.CountryCode);
        if(noxTypeValue != null)
        {        
            entity.CountryCode = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Phone entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("IsVerified", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"IsVerified",value);
                if(noxTypeValue == null)
                {
                    entity.IsVerified = null;
                }
                else
                {
                    entity.IsVerified = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryCode", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition,"CountryCode",value);
                if(noxTypeValue == null)
                {
                    entity.CountryCode = null;
                }
                else
                {
                    entity.CountryCode = noxTypeValue;
                }
            }
        }
    }
}