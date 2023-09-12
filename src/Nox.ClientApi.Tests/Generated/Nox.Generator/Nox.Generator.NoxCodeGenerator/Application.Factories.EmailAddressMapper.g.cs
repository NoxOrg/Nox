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
using EmailAddress = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application;

public partial class EmailAddressMapper : EntityMapperBase<EmailAddress>
{
    public EmailAddressMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(EmailAddress entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used        
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "Email", dto.Email);     
        entity.Email = noxTypeValue;        
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "IsVerified", dto.IsVerified);     
        entity.IsVerified = noxTypeValue;
    
    }

    public override void PartialMapToEntity(EmailAddress entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Email", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition, "Email", value);
                if(noxTypeValue == null)
                {
                    entity.Email = null;
                }
                else
                {
                    entity.Email = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("IsVerified", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "IsVerified", value);
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