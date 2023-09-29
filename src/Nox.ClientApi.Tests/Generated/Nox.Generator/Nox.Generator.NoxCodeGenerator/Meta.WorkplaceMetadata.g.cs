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
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Description'
        /// </summary>
        public static Nox.Types.TextTypeOptions DescriptionTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
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
            => Nox.Types.AutoNumber.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Workplace")
                .GetAttributeByName("Name")?
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