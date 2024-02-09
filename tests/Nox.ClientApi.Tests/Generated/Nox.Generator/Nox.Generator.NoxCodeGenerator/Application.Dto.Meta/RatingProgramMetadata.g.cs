// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace ClientApi.Application.Dto;

/// <summary>
/// Static methods for the RatingProgram class.
/// </summary>
public partial class RatingProgramMetadata
{
    
        /// <summary>
        /// Factory for property 'StoreId'
        /// </summary>
        public static Nox.Types.Guid CreateStoreId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'Name'
        /// </summary>
        public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 256,
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
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions {get; private set;} = null; 
}