// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the EmailAddress class.
/// </summary>
public partial class EmailAddress
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
        
}