﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

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
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CurrencyIsoNumeric'
        /// </summary>
        public static Nox.Types.CurrencyNumber CreateCurrencyIsoNumeric(System.Int16 value)
            => Nox.Types.CurrencyNumber.From(value);
        
    
        /// <summary>
        /// Type options for property 'Symbol'
        /// </summary>
        public static Nox.Types.TextTypeOptions SymbolTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Symbol'
        /// </summary>
        public static Nox.Types.Text CreateSymbol(System.String value)
            => Nox.Types.Text.From(value, SymbolTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'ThousandsSeparator'
        /// </summary>
        public static Nox.Types.TextTypeOptions ThousandsSeparatorTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'ThousandsSeparator'
        /// </summary>
        public static Nox.Types.Text CreateThousandsSeparator(System.String value)
            => Nox.Types.Text.From(value, ThousandsSeparatorTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'DecimalSeparator'
        /// </summary>
        public static Nox.Types.TextTypeOptions DecimalSeparatorTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'DecimalSeparator'
        /// </summary>
        public static Nox.Types.Text CreateDecimalSeparator(System.String value)
            => Nox.Types.Text.From(value, DecimalSeparatorTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'SpaceBetweenAmountAndSymbol'
        /// </summary>
        public static Nox.Types.Boolean CreateSpaceBetweenAmountAndSymbol(System.Boolean value)
            => Nox.Types.Boolean.From(value);
        
    
        /// <summary>
        /// Factory for property 'DecimalDigits'
        /// </summary>
        public static Nox.Types.Number CreateDecimalDigits(System.Int32 value)
            => Nox.Types.Number.From(value);
        
    
        /// <summary>
        /// Type options for property 'MajorName'
        /// </summary>
        public static Nox.Types.TextTypeOptions MajorNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'MajorName'
        /// </summary>
        public static Nox.Types.Text CreateMajorName(System.String value)
            => Nox.Types.Text.From(value, MajorNameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'MajorSymbol'
        /// </summary>
        public static Nox.Types.TextTypeOptions MajorSymbolTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'MajorSymbol'
        /// </summary>
        public static Nox.Types.Text CreateMajorSymbol(System.String value)
            => Nox.Types.Text.From(value, MajorSymbolTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'MinorName'
        /// </summary>
        public static Nox.Types.TextTypeOptions MinorNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'MinorName'
        /// </summary>
        public static Nox.Types.Text CreateMinorName(System.String value)
            => Nox.Types.Text.From(value, MinorNameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'MinorSymbol'
        /// </summary>
        public static Nox.Types.TextTypeOptions MinorSymbolTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'MinorSymbol'
        /// </summary>
        public static Nox.Types.Text CreateMinorSymbol(System.String value)
            => Nox.Types.Text.From(value, MinorSymbolTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'MinorToMajorValue'
        /// </summary>
        public static Nox.Types.Money CreateMinorToMajorValue(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'BankNoteId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateBankNoteId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'ExchangeRateId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateExchangeRateId(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public TypeUserInterface? NameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CurrencyIsoNumeric'
        /// </summary>
        public TypeUserInterface? CurrencyIsoNumericUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "CurrencyIsoNumeric")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Symbol'
        /// </summary>
        public TypeUserInterface? SymbolUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "Symbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ThousandsSeparator'
        /// </summary>
        public TypeUserInterface? ThousandsSeparatorUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "ThousandsSeparator")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DecimalSeparator'
        /// </summary>
        public TypeUserInterface? DecimalSeparatorUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "DecimalSeparator")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'SpaceBetweenAmountAndSymbol'
        /// </summary>
        public TypeUserInterface? SpaceBetweenAmountAndSymbolUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "SpaceBetweenAmountAndSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DecimalDigits'
        /// </summary>
        public TypeUserInterface? DecimalDigitsUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "DecimalDigits")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MajorName'
        /// </summary>
        public TypeUserInterface? MajorNameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "MajorName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MajorSymbol'
        /// </summary>
        public TypeUserInterface? MajorSymbolUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "MajorSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorName'
        /// </summary>
        public TypeUserInterface? MinorNameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "MinorName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorSymbol'
        /// </summary>
        public TypeUserInterface? MinorSymbolUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "MinorSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorToMajorValue'
        /// </summary>
        public TypeUserInterface? MinorToMajorValueUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Currency")?
                .Attributes?.FirstOrDefault(a => a.Name == "MinorToMajorValue")?
                .UserInterface;
}