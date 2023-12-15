// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the AProduct class.
/// </summary>
public partial class AProductMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'MyGuid'
        /// </summary>
        public static Nox.Types.Guid CreateMyGuid(System.Guid value)
            => Nox.Types.Guid.From(value);
        

        /// <summary>
        /// User Interface for property 'MyGuid'
        /// </summary>
        public static TypeUserInterface? MyGuidUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("AProduct")
                .GetAttributeByName("MyGuid")?
                .UserInterface;
}