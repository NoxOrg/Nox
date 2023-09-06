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
using Transaction = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application;

public class TransactionMapper : EntityMapperBase<Transaction>
{
    public TransactionMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Transaction entity, Entity entityDefinition, dynamic dto)
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
        /// Transaction for ExactlyOne Customers
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "TransactionForCustomer", dto.TransactionForCustomerId);
        if (noxTypeValue != null)
        {        
            entity.TransactionForCustomerId = noxTypeValue;
        }

        /// <summary>
        /// Transaction for ExactlyOne Bookings
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "TransactionForBooking", dto.TransactionForBookingId);
        if (noxTypeValue != null)
        {        
            entity.TransactionForBookingId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Transaction entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Transaction", "TransactionType");
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
                    throw new EntityAttributeIsNotNullableException("Transaction", "ProcessedOnDateTime");
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
                    throw new EntityAttributeIsNotNullableException("Transaction", "Amount");
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
                    throw new EntityAttributeIsNotNullableException("Transaction", "Reference");
                }
                else
                {
                    entity.Reference = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Transaction for ExactlyOne Customers
        /// </summary>
        if (updatedProperties.TryGetValue("CustomerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "TransactionForCustomer", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.TransactionForCustomerId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// Transaction for ExactlyOne Bookings
        /// </summary>
        if (updatedProperties.TryGetValue("BookingId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "TransactionForBooking", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.TransactionForBookingId = noxRelationshipTypeValue;
            }
        }
    }
}