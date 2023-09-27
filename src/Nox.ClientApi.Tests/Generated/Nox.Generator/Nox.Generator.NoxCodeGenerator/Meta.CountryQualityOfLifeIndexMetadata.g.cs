// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the CountryQualityOfLifeIndex class.
/// </summary>
public partial class CountryQualityOfLifeIndexMetadata
{
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'IndexRating'
        /// </summary>
        public static Nox.Types.Number CreateIndexRating(System.Int32 value)
            => Nox.Types.Number.From(value);
        
}