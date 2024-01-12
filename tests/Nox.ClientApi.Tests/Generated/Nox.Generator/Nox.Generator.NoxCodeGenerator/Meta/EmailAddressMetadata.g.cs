// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

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
        public static TypeUserInterface? EmailUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'IsVerified'
        /// </summary>
        public static TypeUserInterface? IsVerifiedUiOptions {get; private set;} = null; 
}