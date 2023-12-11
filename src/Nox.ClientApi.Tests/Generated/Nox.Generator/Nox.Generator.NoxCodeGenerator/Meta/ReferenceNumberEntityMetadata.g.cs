// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the ReferenceNumberEntity class.
/// </summary>
public partial class ReferenceNumberEntityMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.ReferenceNumberTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            StartsAt = 10,
            IncrementsBy = 5,
            Prefix = "ID-",
            SuffixCheckSumDigit = true,
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.ReferenceNumber CreateId(System.String value)
            => Nox.Types.ReferenceNumber.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'ReferenceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumberTypeOptions ReferenceNumberTypeOptions {get; private set;} = new ()
        {
            StartsAt = 10,
            IncrementsBy = 5,
            Prefix = "RN-",
            SuffixCheckSumDigit = true,
        };
    
    
        /// <summary>
        /// Factory for property 'ReferenceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumber CreateReferenceNumber(System.String value)
            => Nox.Types.ReferenceNumber.From(value, ReferenceNumberTypeOptions);
        

        /// <summary>
        /// User Interface for property 'ReferenceNumber'
        /// </summary>
        public static TypeUserInterface? ReferenceNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("ReferenceNumberEntity")
                .GetAttributeByName("ReferenceNumber")?
                .UserInterface;
}