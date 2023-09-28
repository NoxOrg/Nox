﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the BankNote class.
/// </summary>
public partial class BankNoteMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Type options for property 'CashNote'
        /// </summary>
        public static Nox.Types.TextTypeOptions CashNoteTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'CashNote'
        /// </summary>
        public static Nox.Types.Text CreateCashNote(System.String value)
            => Nox.Types.Text.From(value, CashNoteTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'Value'
        /// </summary>
        public static Nox.Types.Money CreateValue(IMoney value)
            => Nox.Types.Money.From(value);
        
}