﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Booking class.
/// </summary>
public partial class BookingMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'AmountFrom'
        /// </summary>
        public static Nox.Types.Money CreateAmountFrom(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'AmountTo'
        /// </summary>
        public static Nox.Types.Money CreateAmountTo(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'RequestedPickUpDate'
        /// </summary>
        public static Nox.Types.DateTimeRange CreateRequestedPickUpDate(IDateTimeRange value)
            => Nox.Types.DateTimeRange.From(value);
        
    
        /// <summary>
        /// Factory for property 'PickedUpDateTime'
        /// </summary>
        public static Nox.Types.DateTimeRange CreatePickedUpDateTime(IDateTimeRange value)
            => Nox.Types.DateTimeRange.From(value);
        
    
        /// <summary>
        /// Factory for property 'ExpiryDateTime'
        /// </summary>
        public static Nox.Types.DateTime CreateExpiryDateTime(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Factory for property 'CancelledDateTime'
        /// </summary>
        public static Nox.Types.DateTime CreateCancelledDateTime(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Type options for property 'Status'
        /// </summary>
        public static Nox.Types.FormulaTypeOptions StatusTypeOptions {get; private set;} = new ()
        {
            Expression = "CancelledDateTime != null ? \"cancelled\" : (PickedUpDateTime != null ? \"picked-up\" : (ExpiryDateTime != null ? \"expired\" : \"booked\"))",
            Returns = Nox.Types.FormulaReturnType.@string,
        };
    
    
        /// <summary>
        /// Factory for property 'Status'
        /// </summary>
        public static Nox.Types.Formula CreateStatus(System.String value)
            => Nox.Types.Formula.From(value, StatusTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'VatNumber'
        /// </summary>
        public static Nox.Types.VatNumber CreateVatNumber(IVatNumber value)
            => Nox.Types.VatNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'CustomerId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCustomerId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'VendingMachineId'
        /// </summary>
        public static Nox.Types.Guid CreateVendingMachineId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'CommissionId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCommissionId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        

        /// <summary>
        /// User Interface for property 'AmountFrom'
        /// </summary>
        public TypeUserInterface? AmountFromUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "AmountFrom")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'AmountTo'
        /// </summary>
        public TypeUserInterface? AmountToUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "AmountTo")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'RequestedPickUpDate'
        /// </summary>
        public TypeUserInterface? RequestedPickUpDateUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "RequestedPickUpDate")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PickedUpDateTime'
        /// </summary>
        public TypeUserInterface? PickedUpDateTimeUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "PickedUpDateTime")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ExpiryDateTime'
        /// </summary>
        public TypeUserInterface? ExpiryDateTimeUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "ExpiryDateTime")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CancelledDateTime'
        /// </summary>
        public TypeUserInterface? CancelledDateTimeUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "CancelledDateTime")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Status'
        /// </summary>
        public TypeUserInterface? StatusUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "Status")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'VatNumber'
        /// </summary>
        public TypeUserInterface? VatNumberUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Booking")?
                .Attributes?.FirstOrDefault(a => a.Name == "VatNumber")?
                .UserInterface;
}