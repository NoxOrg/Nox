﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

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
            IsLocalized = false,
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
            IsLocalized = false,
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
            IsLocalized = false,
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
        public static Nox.Types.Guid CreateCustomerId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'PaymentProviderId'
        /// </summary>
        public static Nox.Types.Guid CreatePaymentProviderId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
        /// <summary>
        /// User Interface for property 'PaymentAccountName'
        /// </summary>
        public static TypeUserInterface? PaymentAccountNameUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'PaymentAccountNumber'
        /// </summary>
        public static TypeUserInterface? PaymentAccountNumberUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'PaymentAccountSortCode'
        /// </summary>
        public static TypeUserInterface? PaymentAccountSortCodeUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
}