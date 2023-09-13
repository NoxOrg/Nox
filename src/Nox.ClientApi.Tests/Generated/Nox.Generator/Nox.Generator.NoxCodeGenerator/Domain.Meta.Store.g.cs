// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Store class.
/// </summary>
public partial class Store
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.NuidTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            Separator = ".",
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
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'StoreOwnerId'
        /// </summary>
        public static Nox.Types.TextTypeOptions StoreOwnerIdTypeOptions {get; private set;} = new ()
        {
            MinLength = 3,
            MaxLength = 3,
            IsUnicode = false,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'StoreOwnerId'
        /// </summary>
        public static Nox.Types.Text CreateStoreOwnerId(System.String value)
            => Nox.Types.Text.From(value, StoreOwnerIdTypeOptions);
        
}