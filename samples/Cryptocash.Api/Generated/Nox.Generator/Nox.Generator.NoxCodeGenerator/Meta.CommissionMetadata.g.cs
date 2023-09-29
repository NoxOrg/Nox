// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Commission class.
/// </summary>
public partial class CommissionMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'Rate'
        /// </summary>
        public static Nox.Types.Percentage CreateRate(System.Single value)
            => Nox.Types.Percentage.From(value);
        
    
        /// <summary>
        /// Factory for property 'EffectiveAt'
        /// </summary>
        public static Nox.Types.DateTime CreateEffectiveAt(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
            => Nox.Types.CountryCode2.From(value);
        

        /// <summary>
        /// User Interface for property 'Rate'
        /// </summary>
        public static TypeUserInterface? RateUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Commission")
                .GetAttributeByName("Rate")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EffectiveAt'
        /// </summary>
        public static TypeUserInterface? EffectiveAtUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Commission")
                .GetAttributeByName("EffectiveAt")?
                .UserInterface;
}