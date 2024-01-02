// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the ForReferenceNumber class.
/// </summary>
public partial class ForReferenceNumberMetadata
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
        /// Type options for property 'WorkplaceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumberTypeOptions WorkplaceNumberTypeOptions {get; private set;} = new ()
        {
            StartsAt = 100,
            IncrementsBy = 1,
            Prefix = "WKP-",
            SuffixCheckSumDigit = true,
        };
    
    
        /// <summary>
        /// Factory for property 'WorkplaceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumber CreateWorkplaceNumber(System.String value)
            => Nox.Types.ReferenceNumber.From(value, WorkplaceNumberTypeOptions);
        
        /// <summary>
        /// User Interface for property 'WorkplaceNumber'
        /// </summary>
        public static TypeUserInterface? WorkplaceNumberUiOptions {get; private set;} = null; 
}