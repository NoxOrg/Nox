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

public class CustomerTransactionMapper : EntityMapperBase<CustomerTransaction>
{
    public CustomerTransactionMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CustomerTransaction entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TransactionType", dto.TransactionType);
        if (noxTypeValue != null)
        {        
            entity.TransactionType = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "ProcessedOnDateTime", dto.ProcessedOnDateTime);
        if (noxTypeValue != null)
        {        
            entity.ProcessedOnDateTime = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", dto.Amount);
        if (noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Reference", dto.Reference);
        if (noxTypeValue != null)
        {        
            entity.Reference = noxTypeValue;
        }
    

        /// <summary>
        /// CustomerTransaction Transaction's customer ExactlyOne Customers
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Customer", dto.CustomerId);
        if (noxTypeValue != null)
        {        
            entity.CustomerId = noxTypeValue;
        }

        /// <summary>
        /// CustomerTransaction Transaction's booking ExactlyOne Bookings
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "Booking", dto.BookingId);
        if (noxTypeValue != null)
        {        
            entity.BookingId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CustomerTransaction entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("TransactionType", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TransactionType", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "TransactionType");
                }
                else
                {
                    entity.TransactionType = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ProcessedOnDateTime", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "ProcessedOnDateTime", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "ProcessedOnDateTime");
                }
                else
                {
                    entity.ProcessedOnDateTime = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Amount", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "Amount");
                }
                else
                {
                    entity.Amount = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Reference", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Reference", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "Reference");
                }
                else
                {
                    entity.Reference = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// CustomerTransaction Transaction's customer ExactlyOne Customers
        /// </summary>
        if (updatedProperties.TryGetValue("CustomerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Customer", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CustomerId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// CustomerTransaction Transaction's booking ExactlyOne Bookings
        /// </summary>
        if (updatedProperties.TryGetValue("BookingId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "Booking", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.BookingId = noxRelationshipTypeValue;
            }
        }
    }
}