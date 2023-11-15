// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Tenant class.
/// </summary>
public partial class TenantMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.NuidTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            Separator = "-",
            PropertyNames = new System.String[]
            {
                "Name",
            },
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Nuid CreateId(System.UInt32 value)
            => Nox.Types.Nuid.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Name'
        /// </summary>
        public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'WorkplaceId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateWorkplaceId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Tenant")
                .GetAttributeByName("Name")?
                .UserInterface;
}