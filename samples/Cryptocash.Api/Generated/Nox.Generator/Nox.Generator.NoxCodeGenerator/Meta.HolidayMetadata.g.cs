// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Holiday class.
/// </summary>
public partial class HolidayMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
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
        /// Type options for property 'Type'
        /// </summary>
        public static Nox.Types.TextTypeOptions TypeTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Type'
        /// </summary>
        public static Nox.Types.Text CreateType(System.String value)
            => Nox.Types.Text.From(value, TypeTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'Date'
        /// </summary>
        public static Nox.Types.Date CreateDate(System.DateTime value)
            => Nox.Types.Date.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public TypeUserInterface? NameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Holiday")?
                .Attributes?.FirstOrDefault(a => a.Name == "Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Type'
        /// </summary>
        public TypeUserInterface? TypeUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Holiday")?
                .Attributes?.FirstOrDefault(a => a.Name == "Type")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Date'
        /// </summary>
        public TypeUserInterface? DateUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Holiday")?
                .Attributes?.FirstOrDefault(a => a.Name == "Date")?
                .UserInterface;
}