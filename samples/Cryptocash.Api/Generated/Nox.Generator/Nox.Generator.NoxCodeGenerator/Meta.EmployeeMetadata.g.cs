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
            => Nox.Types.AutoNumber.From(value);
        
    
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
            => Nox.Types.AutoNumber.From(value);
        

        /// <summary>
        /// User Interface for property 'FirstName'
        /// </summary>
        public TypeUserInterface? FirstNameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "FirstName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LastName'
        /// </summary>
        public TypeUserInterface? LastNameUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "LastName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EmailAddress'
        /// </summary>
        public TypeUserInterface? EmailAddressUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "EmailAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Address'
        /// </summary>
        public TypeUserInterface? AddressUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "Address")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FirstWorkingDay'
        /// </summary>
        public TypeUserInterface? FirstWorkingDayUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "FirstWorkingDay")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LastWorkingDay'
        /// </summary>
        public TypeUserInterface? LastWorkingDayUserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "Employee")?
                .Attributes?.FirstOrDefault(a => a.Name == "LastWorkingDay")?
                .UserInterface;
}