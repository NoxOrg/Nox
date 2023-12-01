// Generated

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
            IsLocalized = false,
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
            IsLocalized = false,
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
            IsLocalized = false,
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
            IsLocalized = false,
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
        /// Factory for property 'SymbolOnLeft'
        /// </summary>
        public static Nox.Types.Boolean CreateSymbolOnLeft(System.Boolean value)
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
            IsLocalized = false,
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
            IsLocalized = false,
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
            IsLocalized = false,
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
            IsLocalized = false,
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
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'ExchangeRateId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateExchangeRateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CurrencyIsoNumeric'
        /// </summary>
        public static TypeUserInterface? CurrencyIsoNumericUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("CurrencyIsoNumeric")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Symbol'
        /// </summary>
        public static TypeUserInterface? SymbolUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("Symbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ThousandsSeparator'
        /// </summary>
        public static TypeUserInterface? ThousandsSeparatorUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("ThousandsSeparator")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DecimalSeparator'
        /// </summary>
        public static TypeUserInterface? DecimalSeparatorUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("DecimalSeparator")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'SpaceBetweenAmountAndSymbol'
        /// </summary>
        public static TypeUserInterface? SpaceBetweenAmountAndSymbolUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("SpaceBetweenAmountAndSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'SymbolOnLeft'
        /// </summary>
        public static TypeUserInterface? SymbolOnLeftUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("SymbolOnLeft")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DecimalDigits'
        /// </summary>
        public static TypeUserInterface? DecimalDigitsUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("DecimalDigits")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MajorName'
        /// </summary>
        public static TypeUserInterface? MajorNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("MajorName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MajorSymbol'
        /// </summary>
        public static TypeUserInterface? MajorSymbolUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("MajorSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorName'
        /// </summary>
        public static TypeUserInterface? MinorNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("MinorName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorSymbol'
        /// </summary>
        public static TypeUserInterface? MinorSymbolUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("MinorSymbol")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MinorToMajorValue'
        /// </summary>
        public static TypeUserInterface? MinorToMajorValueUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Currency")
                .GetAttributeByName("MinorToMajorValue")?
                .UserInterface;
}