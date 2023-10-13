// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the CountryBarCode class.
/// </summary>
public partial class CountryBarCodeMetadata
{
    
        /// <summary>
        /// Type options for property 'BarCodeName'
        /// </summary>
        public static Nox.Types.TextTypeOptions BarCodeNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 1,
            MaxLength = 63,
            IsUnicode = true,
<<<<<<< HEAD
            IsLocalized = false,
=======
            IsLocalized = true,
>>>>>>> main
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'BarCodeName'
        /// </summary>
        public static Nox.Types.Text CreateBarCodeName(System.String value)
            => Nox.Types.Text.From(value, BarCodeNameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'BarCodeNumber'
        /// </summary>
        public static Nox.Types.Number CreateBarCodeNumber(System.Int32 value)
            => Nox.Types.Number.From(value);
        

        /// <summary>
        /// User Interface for property 'BarCodeName'
        /// </summary>
        public static TypeUserInterface? BarCodeNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryBarCode")
                .GetAttributeByName("BarCodeName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'BarCodeNumber'
        /// </summary>
        public static TypeUserInterface? BarCodeNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("CountryBarCode")
                .GetAttributeByName("BarCodeNumber")?
                .UserInterface;
}