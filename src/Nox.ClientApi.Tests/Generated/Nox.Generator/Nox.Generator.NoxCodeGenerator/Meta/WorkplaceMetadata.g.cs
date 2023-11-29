// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Workplace class.
/// </summary>
public partial class WorkplaceMetadata
{
    
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
        /// Type options for property 'ReferenceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumberTypeOptions ReferenceNumberTypeOptions {get; private set;} = new ()
        {
            StartsAt = 10,
            IncrementsBy = 5,
            Prefix = "WP-",
            SuffixCheckSumDigit = true,
        };
    
    
        /// <summary>
        /// Factory for property 'ReferenceNumber'
        /// </summary>
        public static Nox.Types.ReferenceNumber CreateReferenceNumber(System.String value)
            => Nox.Types.ReferenceNumber.From(value, ReferenceNumberTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Description'
        /// </summary>
        public static Nox.Types.TextTypeOptions DescriptionTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 255,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Description'
        /// </summary>
        public static Nox.Types.Text CreateDescription(System.String value)
            => Nox.Types.Text.From(value, DescriptionTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Greeting'
        /// </summary>
        public static Nox.Types.FormulaTypeOptions GreetingTypeOptions {get; private set;} = new ()
        {
            Expression = "$\"Hello, {Name.Value}!\"",
            Returns = Nox.Types.FormulaReturnType.@string,
        };
    
    
        /// <summary>
        /// Factory for property 'Greeting'
        /// </summary>
        public static Nox.Types.Formula CreateGreeting(System.String value)
            => Nox.Types.Formula.From(value, GreetingTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateCountryId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'TenantId'
        /// </summary>
        public static Nox.Types.NuidTypeOptions TenantIdTypeOptions {get; private set;} = new ()
        {
            Separator = "-",
            PropertyNames = new System.String[]
            {
                "Name",
            },
        };
    
    
        /// <summary>
        /// Factory for property 'TenantId'
        /// </summary>
        public static Nox.Types.Nuid CreateTenantId(System.UInt32 value)
            => Nox.Types.Nuid.From(value, TenantIdTypeOptions);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Workplace")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ReferenceNumber'
        /// </summary>
        public static TypeUserInterface? ReferenceNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Workplace")
                .GetAttributeByName("ReferenceNumber")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Description'
        /// </summary>
        public static TypeUserInterface? DescriptionUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Workplace")
                .GetAttributeByName("Description")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Greeting'
        /// </summary>
        public static TypeUserInterface? GreetingUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Workplace")
                .GetAttributeByName("Greeting")?
                .UserInterface;
}