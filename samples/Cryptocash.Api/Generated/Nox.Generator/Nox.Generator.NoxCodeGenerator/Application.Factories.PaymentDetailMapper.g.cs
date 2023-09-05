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
using PaymentDetail = Cryptocash.Domain.PaymentDetail;

namespace Cryptocash.Application;

public class PaymentDetailMapper : EntityMapperBase<PaymentDetail>
{
    public PaymentDetailMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(PaymentDetail entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountName", dto.PaymentAccountName);
        if (noxTypeValue != null)
        {        
            entity.PaymentAccountName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountNumber", dto.PaymentAccountNumber);
        if (noxTypeValue != null)
        {        
            entity.PaymentAccountNumber = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountSortCode", dto.PaymentAccountSortCode);
        if (noxTypeValue != null)
        {        
            entity.PaymentAccountSortCode = noxTypeValue;
        }
    

        /// <summary>
        /// PaymentDetail used by ExactlyOne Customers
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "PaymentDetailsUsedByCustomer", dto.PaymentDetailsUsedByCustomerId);
        if (noxTypeValue != null)
        {        
            entity.PaymentDetailsUsedByCustomerId = noxTypeValue;
        }

        /// <summary>
        /// PaymentDetail related to ExactlyOne PaymentProviders
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "PaymentDetailsRelatedPaymentProvider", dto.PaymentDetailsRelatedPaymentProviderId);
        if (noxTypeValue != null)
        {        
            entity.PaymentDetailsRelatedPaymentProviderId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(PaymentDetail entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("PaymentAccountName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("PaymentDetail", "PaymentAccountName");
                }
                else
                {
                    entity.PaymentAccountName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PaymentAccountNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountNumber", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("PaymentDetail", "PaymentAccountNumber");
                }
                else
                {
                    entity.PaymentAccountNumber = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PaymentAccountSortCode", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PaymentAccountSortCode", value);
                if(noxTypeValue == null)
                {
                    entity.PaymentAccountSortCode = null;
                }
                else
                {
                    entity.PaymentAccountSortCode = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// PaymentDetail used by ExactlyOne Customers
        /// </summary>
        if (updatedProperties.TryGetValue("CustomerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "PaymentDetailsUsedByCustomer", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.PaymentDetailsUsedByCustomerId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// PaymentDetail related to ExactlyOne PaymentProviders
        /// </summary>
        if (updatedProperties.TryGetValue("PaymentProviderId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "PaymentDetailsRelatedPaymentProvider", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.PaymentDetailsRelatedPaymentProviderId = noxRelationshipTypeValue;
            }
        }
    }
}