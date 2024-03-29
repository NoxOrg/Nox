﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace ClientApi.Application.Dto;

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
            IsLocalized = false,
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
        public static TypeUserInterface? BarCodeNameUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'BarCodeNumber'
        /// </summary>
        public static TypeUserInterface? BarCodeNumberUiOptions {get; private set;} = null; 
}