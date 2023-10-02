// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Employee class.
/// </summary>
public partial class EmployeeMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.AutoNumber CreateId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Type options for property 'FirstName'
        /// </summary>
        public static Nox.Types.TextTypeOptions FirstNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'FirstName'
        /// </summary>
        public static Nox.Types.Text CreateFirstName(System.String value)
            => Nox.Types.Text.From(value, FirstNameTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'LastName'
        /// </summary>
        public static Nox.Types.TextTypeOptions LastNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'LastName'
        /// </summary>
        public static Nox.Types.Text CreateLastName(System.String value)
            => Nox.Types.Text.From(value, LastNameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'EmailAddress'
        /// </summary>
        public static Nox.Types.Email CreateEmailAddress(System.String value)
            => Nox.Types.Email.From(value);
        
    
        /// <summary>
        /// Factory for property 'Address'
        /// </summary>
        public static Nox.Types.StreetAddress CreateAddress(IStreetAddress value)
            => Nox.Types.StreetAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'FirstWorkingDay'
        /// </summary>
        public static Nox.Types.Date CreateFirstWorkingDay(System.DateTime value)
            => Nox.Types.Date.From(value);
        
    
        /// <summary>
        /// Factory for property 'LastWorkingDay'
        /// </summary>
        public static Nox.Types.Date CreateLastWorkingDay(System.DateTime value)
            => Nox.Types.Date.From(value);
        
    
        /// <summary>
        /// Factory for property 'EmployeePhoneNumberId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateEmployeePhoneNumberId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        

        /// <summary>
        /// User Interface for property 'FirstName'
        /// </summary>
        public static TypeUserInterface? FirstNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("FirstName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LastName'
        /// </summary>
        public static TypeUserInterface? LastNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("LastName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EmailAddress'
        /// </summary>
        public static TypeUserInterface? EmailAddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("EmailAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Address'
        /// </summary>
        public static TypeUserInterface? AddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("Address")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FirstWorkingDay'
        /// </summary>
        public static TypeUserInterface? FirstWorkingDayUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("FirstWorkingDay")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LastWorkingDay'
        /// </summary>
        public static TypeUserInterface? LastWorkingDayUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Employee")
                .GetAttributeByName("LastWorkingDay")?
                .UserInterface;
}