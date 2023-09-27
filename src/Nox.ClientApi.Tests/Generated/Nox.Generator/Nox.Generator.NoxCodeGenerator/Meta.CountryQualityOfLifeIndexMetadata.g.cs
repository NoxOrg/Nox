// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
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
        

        /// <summary>
        /// User Interface for property 'IndexRating'
        /// </summary>
        public static TypeUserInterface? IndexRatingUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "CountryQualityOfLifeIndex")?
                .Attributes?.FirstOrDefault(a => a.Name == "IndexRating")?
                .UserInterface;
}