﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the ExchangeRate class.
/// </summary>
public partial class ExchangeRateMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'EffectiveRate'
        /// </summary>
        public static Nox.Types.Number CreateEffectiveRate(System.Int32 value)
            => Nox.Types.Number.From(value);
        
    
        /// <summary>
        /// Factory for property 'EffectiveAt'
        /// </summary>
        public static Nox.Types.DateTime CreateEffectiveAt(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
}