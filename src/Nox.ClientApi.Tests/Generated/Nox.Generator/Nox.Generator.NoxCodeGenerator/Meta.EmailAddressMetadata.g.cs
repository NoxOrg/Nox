// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the EmailAddress class.
/// </summary>
public partial class EmailAddressMetadata
{
    
        /// <summary>
        /// Factory for property 'Email'
        /// </summary>
        public static Nox.Types.Email CreateEmail(System.String value)
            => Nox.Types.Email.From(value);
        
    
        /// <summary>
        /// Factory for property 'IsVerified'
        /// </summary>
        public static Nox.Types.Boolean CreateIsVerified(System.Boolean value)
            => Nox.Types.Boolean.From(value);
        

        /// <summary>
        /// User Interface for property 'Email'
        /// </summary>
        public static TypeUserInterface? EmailUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "EmailAddress")?
                .Attributes?.FirstOrDefault(a => a.Name == "Email")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'IsVerified'
        /// </summary>
        public static TypeUserInterface? IsVerifiedUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "EmailAddress")?
                .Attributes?.FirstOrDefault(a => a.Name == "IsVerified")?
                .UserInterface;
}