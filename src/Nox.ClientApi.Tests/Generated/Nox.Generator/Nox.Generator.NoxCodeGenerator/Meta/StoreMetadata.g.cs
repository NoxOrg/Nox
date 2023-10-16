// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Store class.
/// </summary>
public partial class StoreMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
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
        /// Factory for property 'Address'
        /// </summary>
        public static Nox.Types.StreetAddress CreateAddress(IStreetAddress value)
            => Nox.Types.StreetAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'Location'
        /// </summary>
        public static Nox.Types.LatLong CreateLocation(ILatLong value)
            => Nox.Types.LatLong.From(value);
        
    
        /// <summary>
        /// Factory for property 'OpeningDay'
        /// </summary>
        public static Nox.Types.DateTime CreateOpeningDay(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Type options for property 'StoreOwnerId'
        /// </summary>
        public static Nox.Types.TextTypeOptions StoreOwnerIdTypeOptions {get; private set;} = new ()
        {
            MinLength = 3,
            MaxLength = 3,
            IsUnicode = false,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'StoreOwnerId'
        /// </summary>
        public static Nox.Types.Text CreateStoreOwnerId(System.String value)
            => Nox.Types.Text.From(value, StoreOwnerIdTypeOptions);
        

        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Store")
                .GetAttributeByName("Name")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Address'
        /// </summary>
        public static TypeUserInterface? AddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Store")
                .GetAttributeByName("Address")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'Location'
        /// </summary>
        public static TypeUserInterface? LocationUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Store")
                .GetAttributeByName("Location")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'OpeningDay'
        /// </summary>
        public static TypeUserInterface? OpeningDayUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("Store")
                .GetAttributeByName("OpeningDay")?
                .UserInterface;
}