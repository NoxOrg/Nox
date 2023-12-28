// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

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
        /// Type options for property 'Status'
        /// </summary>
        public static Nox.Types.EnumerationTypeOptions StatusTypeOptions {get; private set;} = new ()
        {
            Values = new System.Collections.Generic.List<Nox.Types.EnumerationValues>()
            {
                new Nox.Types.EnumerationValues()
                {
                    Id = 1,
                    Name = "Construction",
                },
                new Nox.Types.EnumerationValues()
                {
                    Id = 2,
                    Name = "LicensePermit",
                },
                new Nox.Types.EnumerationValues()
                {
                    Id = 3,
                    Name = "Opened",
                },
                new Nox.Types.EnumerationValues()
                {
                    Id = 4,
                    Name = "Closed",
                },
            },
            IsLocalized = false,
        };
    
    
        /// <summary>
        /// Factory for property 'Status'
        /// </summary>
        public static Nox.Types.Enumeration CreateStatus(System.Int32 value)
            => Nox.Types.Enumeration.From(value, StatusTypeOptions);
        
    
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
        /// Factory for property 'ClientId'
        /// </summary>
        public static Nox.Types.Guid CreateClientId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
        /// <summary>
        /// User Interface for property 'Name'
        /// </summary>
        public static TypeUserInterface? NameUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'Address'
        /// </summary>
        public static TypeUserInterface? AddressUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'Location'
        /// </summary>
        public static TypeUserInterface? LocationUiOptions {get; private set;} = null; 
        /// <summary>
        /// User Interface for property 'OpeningDay'
        /// </summary>
        public static TypeUserInterface? OpeningDayUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            InputOrder = 0,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true, 
            CanSearch = true, 
            CanFilter = true,
            ShowOnCreateForm = true,
            ShowOnUpdateForm = true,
        }; 
        /// <summary>
        /// User Interface for property 'Status'
        /// </summary>
        public static TypeUserInterface? StatusUiOptions {get; private set;} = null; 
}