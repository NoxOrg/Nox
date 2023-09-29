// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the CountryTimeZone class.
/// </summary>
public partial class CountryTimeZoneMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'TimeZoneCode'
        /// </summary>
        public static Nox.Types.TimeZoneCode CreateTimeZoneCode(System.String value)
            => Nox.Types.TimeZoneCode.From(value);
        

        /// <summary>
        /// User Interface for property 'TimeZoneCode'
        /// </summary>
        public static TypeUserInterface? TimeZoneCodeUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryTimeZone")
                .GetAttributeByName("TimeZoneCode")?
                .UserInterface;
}