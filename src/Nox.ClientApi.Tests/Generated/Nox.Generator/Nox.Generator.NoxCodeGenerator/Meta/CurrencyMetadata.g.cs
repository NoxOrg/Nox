// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Currency class.
/// </summary>
public partial class CurrencyMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateId(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        
    
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
        /// Type options for property 'Symbol'
        /// </summary>
        public static Nox.Types.TextTypeOptions SymbolTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Symbol'
        /// </summary>
        public static Nox.Types.Text CreateSymbol(System.String value)
            => Nox.Types.Text.From(value, SymbolTypeOptions);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Symbol'
        /// </summary>
        public static TypeUserInterface? SymbolUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("Symbol")?
                .UserInterface;
}