// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the CashStockOrder class.
/// </summary>
public partial class CashStockOrderMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'Amount'
        /// </summary>
        public static Nox.Types.Money CreateAmount(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'RequestedDeliveryDate'
        /// </summary>
        public static Nox.Types.Date CreateRequestedDeliveryDate(System.DateTime value)
            => Nox.Types.Date.From(value);
        
    
        /// <summary>
        /// Factory for property 'DeliveryDateTime'
        /// </summary>
        public static Nox.Types.DateTime CreateDeliveryDateTime(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Type options for property 'Status'
        /// </summary>
        public static Nox.Types.FormulaTypeOptions StatusTypeOptions {get; private set;} = new ()
        {
            Expression = "DeliveryDateTime != null ? \"delivered\" : \"ordered\"",
            Returns = Nox.Types.FormulaReturnType.@string,
        };
    
    
        /// <summary>
        /// Factory for property 'Status'
        /// </summary>
        public static Nox.Types.Formula CreateStatus(System.String value)
            => Nox.Types.Formula.From(value, StatusTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'VendingMachineId'
        /// </summary>
        public static Nox.Types.Guid CreateVendingMachineId(System.Guid value)
            => Nox.Types.Guid.From(value);
        

        /// <summary>
        /// User Interface for property 'Amount'
        /// </summary>
        public static TypeUserInterface? AmountUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CashStockOrder")
                .GetAttributeByName("Amount")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'RequestedDeliveryDate'
        /// </summary>
        public static TypeUserInterface? RequestedDeliveryDateUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CashStockOrder")
                .GetAttributeByName("RequestedDeliveryDate")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DeliveryDateTime'
        /// </summary>
        public static TypeUserInterface? DeliveryDateTimeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CashStockOrder")
                .GetAttributeByName("DeliveryDateTime")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Status'
        /// </summary>
        public static TypeUserInterface? StatusUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CashStockOrder")
                .GetAttributeByName("Status")?
                .UserInterface;
}