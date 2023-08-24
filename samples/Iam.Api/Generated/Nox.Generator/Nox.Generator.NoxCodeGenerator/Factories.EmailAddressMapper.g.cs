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

public class EmailAddressMapper: EntityMapperBase<EmailAddress>
{
    public  EmailAddressMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(EmailAddress entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "Email", dto.Email);        
        if(noxTypeValue != null)
        {        
            entity.Email = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"IsVerified",dto.IsVerified);
        if(noxTypeValue != null)
        {        
            entity.IsVerified = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(EmailAddress entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
    }
}