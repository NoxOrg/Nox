// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the StoreLicense class.
/// </summary>
public partial class StoreLicenseMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'Issuer'
        /// </summary>
        public static Nox.Types.TextTypeOptions IssuerTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Issuer'
        /// </summary>
        public static Nox.Types.Text CreateIssuer(System.String value)
            => Nox.Types.Text.From(value, IssuerTypeOptions);
        

        /// <summary>
        /// User Interface for property 'Issuer'
        /// </summary>
        public static TypeUserInterface? IssuerUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreLicense")
                .GetAttributeByName("Issuer")?
                .UserInterface;
}