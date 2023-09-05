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
using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using PaymentProvider = Cryptocash.Domain.PaymentProvider;

namespace Cryptocash.Application;

public class PaymentProviderMapper : EntityMapperBase<PaymentProvider>
{
    public PaymentProviderMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(PaymentProvider entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentProviderName", dto.PaymentProviderName);
        if (noxTypeValue != null)
        {        
            entity.PaymentProviderName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentProviderType", dto.PaymentProviderType);
        if (noxTypeValue != null)
        {        
            entity.PaymentProviderType = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(PaymentProvider entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("PaymentProviderName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentProviderName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("PaymentProvider", "PaymentProviderName");
                }
                else
                {
                    entity.PaymentProviderName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PaymentProviderType", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentProviderType", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("PaymentProvider", "PaymentProviderType");
                }
                else
                {
                    entity.PaymentProviderType = noxTypeValue;
                }
            }
        }
    
    
    }
}