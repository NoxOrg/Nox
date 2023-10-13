// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the StoreOwner class.
/// </summary>
public partial class StoreOwnerMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            MinLength = 3,
            MaxLength = 3,
            IsUnicode = false,
<<<<<<< HEAD
            IsLocalized = false,
=======
            IsLocalized = true,
>>>>>>> main
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Text CreateId(System.String value)
            => Nox.Types.Text.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'Name'
        /// </summary>
        public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
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
        /// Factory for property 'Name'
        /// </summary>
        public static Nox.Types.Text CreateName(System.String value)
            => Nox.Types.Text.From(value, NameTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'TemporaryOwnerName'
        /// </summary>
        public static Nox.Types.Text CreateTemporaryOwnerName(System.String value)
            => Nox.Types.Text.From(value);
        
    
        /// <summary>
        /// Factory for property 'VatNumber'
        /// </summary>
        public static Nox.Types.VatNumber CreateVatNumber(IVatNumber value)
            => Nox.Types.VatNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'StreetAddress'
        /// </summary>
        public static Nox.Types.StreetAddress CreateStreetAddress(IStreetAddress value)
            => Nox.Types.StreetAddress.From(value);
        
    
        /// <summary>
        /// Type options for property 'LocalGreeting'
        /// </summary>
        public static Nox.Types.TranslatedTextTypeOptions LocalGreetingTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            CharacterCasing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'LocalGreeting'
        /// </summary>
        public static Nox.Types.TranslatedText CreateLocalGreeting(ITranslatedText value)
            => Nox.Types.TranslatedText.From(value, LocalGreetingTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'Notes'
        /// </summary>
        public static Nox.Types.Text CreateNotes(System.String value)
            => Nox.Types.Text.From(value);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TemporaryOwnerName'
        /// </summary>
        public static TypeUserInterface? TemporaryOwnerNameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("TemporaryOwnerName")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'VatNumber'
        /// </summary>
        public static TypeUserInterface? VatNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("VatNumber")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'StreetAddress'
        /// </summary>
        public static TypeUserInterface? StreetAddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("StreetAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LocalGreeting'
        /// </summary>
        public static TypeUserInterface? LocalGreetingUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("LocalGreeting")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Notes'
        /// </summary>
        public static TypeUserInterface? NotesUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("StoreOwner")
                .GetAttributeByName("Notes")?
                .UserInterface;
}