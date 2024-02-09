// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace ClientApi.Application.Dto;

/// <summary>
/// Static methods for the CountryQualityOfLifeIndex class.
/// </summary>
public partial class CountryQualityOfLifeIndexMetadata
{
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'IndexRating'
        /// </summary>
        public static Nox.Types.NumberTypeOptions IndexRatingTypeOptions {get; private set;} = new ()
        {
            MinValue = 1m,
            MaxValue = 999999999m,
            DecimalDigits = 0,
        };
    
    
        /// <summary>
        /// Factory for property 'IndexRating'
        /// </summary>
        public static Nox.Types.Number CreateIndexRating(System.Int32 value)
            => Nox.Types.Number.From(value, IndexRatingTypeOptions);
        
        /// <summary>
        /// User Interface for property 'IndexRating'
        /// </summary>
        public static TypeUserInterface? IndexRatingUiOptions {get; private set;} = null; 
}