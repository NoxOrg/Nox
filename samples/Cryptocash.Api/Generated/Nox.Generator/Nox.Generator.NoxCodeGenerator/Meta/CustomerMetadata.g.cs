// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Customer class.
/// </summary>
public partial class CustomerMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Type options for property 'FirstName'
        /// </summary>
        public static Nox.Types.TextTypeOptions FirstNameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
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
            IsLocalized = false,
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
        /// Factory for property 'MobileNumber'
        /// </summary>
        public static Nox.Types.PhoneNumber CreateMobileNumber(System.String value)
            => Nox.Types.PhoneNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
            => Nox.Types.CountryCode2.From(value);
        

        /// <summary>
        /// User Interface for property 'FirstName'
        /// </summary>
        public static TypeUserInterface? FirstNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Customer")
                .GetAttributeByName("FirstName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LastName'
        /// </summary>
        public static TypeUserInterface? LastNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Customer")
                .GetAttributeByName("LastName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EmailAddress'
        /// </summary>
        public static TypeUserInterface? EmailAddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Customer")
                .GetAttributeByName("EmailAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Address'
        /// </summary>
        public static TypeUserInterface? AddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Customer")
                .GetAttributeByName("Address")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MobileNumber'
        /// </summary>
        public static TypeUserInterface? MobileNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Customer")
                .GetAttributeByName("MobileNumber")?
                .UserInterface;
}