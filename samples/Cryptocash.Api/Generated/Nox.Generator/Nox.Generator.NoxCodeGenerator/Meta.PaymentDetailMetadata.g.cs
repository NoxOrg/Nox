// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the PaymentDetail class.
/// </summary>
public partial class PaymentDetailMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'PaymentAccountName'
        /// </summary>
        public static Nox.Types.TextTypeOptions PaymentAccountNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PaymentAccountName'
        /// </summary>
        public static Nox.Types.Text CreatePaymentAccountName(System.String value)
            => Nox.Types.Text.From(value, PaymentAccountNameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'PaymentAccountNumber'
        /// </summary>
        public static Nox.Types.TextTypeOptions PaymentAccountNumberTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PaymentAccountNumber'
        /// </summary>
        public static Nox.Types.Text CreatePaymentAccountNumber(System.String value)
            => Nox.Types.Text.From(value, PaymentAccountNumberTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'PaymentAccountSortCode'
        /// </summary>
        public static Nox.Types.TextTypeOptions PaymentAccountSortCodeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PaymentAccountSortCode'
        /// </summary>
        public static Nox.Types.Text CreatePaymentAccountSortCode(System.String value)
            => Nox.Types.Text.From(value, PaymentAccountSortCodeTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CustomerId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCustomerId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'PaymentProviderId'
        /// </summary>
        public static Nox.Types.AutoNumber CreatePaymentProviderId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        

        /// <summary>
        /// User Interface for property 'PaymentAccountName'
        /// </summary>
        public static TypeUserInterface? PaymentAccountNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("PaymentDetail")
                .GetAttributeByName("PaymentAccountName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PaymentAccountNumber'
        /// </summary>
        public static TypeUserInterface? PaymentAccountNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("PaymentDetail")
                .GetAttributeByName("PaymentAccountNumber")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PaymentAccountSortCode'
        /// </summary>
        public static TypeUserInterface? PaymentAccountSortCodeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("PaymentDetail")
                .GetAttributeByName("PaymentAccountSortCode")?
                .UserInterface;
}