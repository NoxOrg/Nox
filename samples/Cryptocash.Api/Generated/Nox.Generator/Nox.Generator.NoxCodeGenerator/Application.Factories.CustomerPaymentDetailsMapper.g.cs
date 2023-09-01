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

namespace Cryptocash.Application;

public class CustomerPaymentDetailsMapper : EntityMapperBase<CustomerPaymentDetails>
{
    public CustomerPaymentDetailsMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CustomerPaymentDetails entity, Entity entityDefinition, dynamic dto)
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
        /// CustomerPaymentDetails Customer's payment account ExactlyOne Customers
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Customer", dto.CustomerId);
        if (noxTypeValue != null)
        {        
            entity.CustomerId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CustomerPaymentDetails entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CustomerPaymentDetails", "PaymentAccountName");
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
                    throw new EntityAttributeIsNotNullableException("CustomerPaymentDetails", "PaymentAccountNumber");
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
        /// CustomerPaymentDetails Customer's payment account ExactlyOne Customers
        /// </summary>
        if (updatedProperties.TryGetValue("CustomerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Customer", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CustomerId = noxRelationshipTypeValue;
            }
        }
    }
}