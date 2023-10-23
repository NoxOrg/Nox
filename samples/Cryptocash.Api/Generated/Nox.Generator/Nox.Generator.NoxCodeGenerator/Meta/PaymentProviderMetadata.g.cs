﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the PaymentProvider class.
/// </summary>
public partial class PaymentProviderMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'PaymentProviderName'
        /// </summary>
        public static Nox.Types.TextTypeOptions PaymentProviderNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PaymentProviderName'
        /// </summary>
        public static Nox.Types.Text CreatePaymentProviderName(System.String value)
            => Nox.Types.Text.From(value, PaymentProviderNameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'PaymentProviderType'
        /// </summary>
        public static Nox.Types.TextTypeOptions PaymentProviderTypeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'PaymentProviderType'
        /// </summary>
        public static Nox.Types.Text CreatePaymentProviderType(System.String value)
            => Nox.Types.Text.From(value, PaymentProviderTypeTypeOptions);
        

        /// <summary>
        /// User Interface for property 'PaymentProviderName'
        /// </summary>
        public static TypeUserInterface? PaymentProviderNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("PaymentProvider")
                .GetAttributeByName("PaymentProviderName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PaymentProviderType'
        /// </summary>
        public static TypeUserInterface? PaymentProviderTypeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("PaymentProvider")
                .GetAttributeByName("PaymentProviderType")?
                .UserInterface;
}