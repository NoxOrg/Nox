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
using Booking = Cryptocash.Domain.Booking;

namespace Cryptocash.Application;

public partial class BookingMapper : EntityMapperBase<Booking>
{
    public BookingMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Booking entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "AmountFrom", dto.AmountFrom);
        if (noxTypeValue != null)
        {        
            entity.AmountFrom = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "AmountTo", dto.AmountTo);
        if (noxTypeValue != null)
        {        
            entity.AmountTo = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.DateTimeRange>(entityDefinition, "RequestedPickUpDate", dto.RequestedPickUpDate);
        if (noxTypeValue != null)
        {        
            entity.RequestedPickUpDate = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.DateTimeRange>(entityDefinition, "PickedUpDateTime", dto.PickedUpDateTime);
        if (noxTypeValue != null)
        {        
            entity.PickedUpDateTime = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "ExpiryDateTime", dto.ExpiryDateTime);
        if (noxTypeValue != null)
        {        
            entity.ExpiryDateTime = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "CancelledDateTime", dto.CancelledDateTime);
        if (noxTypeValue != null)
        {        
            entity.CancelledDateTime = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition, "VatNumber", dto.VatNumber);
        if (noxTypeValue != null)
        {        
            entity.VatNumber = noxTypeValue;
        }
    

        /// <summary>
        /// Booking for ExactlyOne Customers
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "BookingForCustomer", dto.BookingForCustomerId);
        if (noxTypeValue != null)
        {        
            entity.BookingForCustomerId = noxTypeValue;
        }

        /// <summary>
        /// Booking related to ExactlyOne VendingMachines
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "BookingRelatedVendingMachine", dto.BookingRelatedVendingMachineId);
        if (noxTypeValue != null)
        {        
            entity.BookingRelatedVendingMachineId = noxTypeValue;
        }

        /// <summary>
        /// Booking fees for ExactlyOne Commissions
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "BookingFeesForCommission", dto.BookingFeesForCommissionId);
        if (noxTypeValue != null)
        {        
            entity.BookingFeesForCommissionId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Booking entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("AmountFrom", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "AmountFrom", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Booking", "AmountFrom");
                }
                else
                {
                    entity.AmountFrom = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("AmountTo", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "AmountTo", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Booking", "AmountTo");
                }
                else
                {
                    entity.AmountTo = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("RequestedPickUpDate", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTimeRange>(entityDefinition, "RequestedPickUpDate", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Booking", "RequestedPickUpDate");
                }
                else
                {
                    entity.RequestedPickUpDate = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PickedUpDateTime", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTimeRange>(entityDefinition, "PickedUpDateTime", value);
                if(noxTypeValue == null)
                {
                    entity.PickedUpDateTime = null;
                }
                else
                {
                    entity.PickedUpDateTime = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ExpiryDateTime", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "ExpiryDateTime", value);
                if(noxTypeValue == null)
                {
                    entity.ExpiryDateTime = null;
                }
                else
                {
                    entity.ExpiryDateTime = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CancelledDateTime", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "CancelledDateTime", value);
                if(noxTypeValue == null)
                {
                    entity.CancelledDateTime = null;
                }
                else
                {
                    entity.CancelledDateTime = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("VatNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition, "VatNumber", value);
                if(noxTypeValue == null)
                {
                    entity.VatNumber = null;
                }
                else
                {
                    entity.VatNumber = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Booking for ExactlyOne Customers
        /// </summary>
        if (updatedProperties.TryGetValue("CustomerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "BookingForCustomer", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.BookingForCustomerId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// Booking related to ExactlyOne VendingMachines
        /// </summary>
        if (updatedProperties.TryGetValue("VendingMachineId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "BookingRelatedVendingMachine", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.BookingRelatedVendingMachineId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// Booking fees for ExactlyOne Commissions
        /// </summary>
        if (updatedProperties.TryGetValue("CommissionId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "BookingFeesForCommission", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.BookingFeesForCommissionId = noxRelationshipTypeValue;
            }
        }
    }
}