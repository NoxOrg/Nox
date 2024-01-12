// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;
using Nox;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the VendingMachine class.
/// </summary>
public partial class VendingMachineMetadata
{
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Guid CreateId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'MacAddress'
        /// </summary>
        public static Nox.Types.MacAddress CreateMacAddress(System.String value)
            => Nox.Types.MacAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'PublicIp'
        /// </summary>
        public static Nox.Types.IpAddress CreatePublicIp(System.String value)
            => Nox.Types.IpAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'GeoLocation'
        /// </summary>
        public static Nox.Types.LatLong CreateGeoLocation(ILatLong value)
            => Nox.Types.LatLong.From(value);
        
    
        /// <summary>
        /// Factory for property 'StreetAddress'
        /// </summary>
        public static Nox.Types.StreetAddress CreateStreetAddress(IStreetAddress value)
            => Nox.Types.StreetAddress.From(value);
        
    
        /// <summary>
        /// Type options for property 'SerialNumber'
        /// </summary>
        public static Nox.Types.TextTypeOptions SerialNumberTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = false,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'SerialNumber'
        /// </summary>
        public static Nox.Types.Text CreateSerialNumber(System.String value)
            => Nox.Types.Text.From(value, SerialNumberTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'InstallationFootPrint'
        /// </summary>
        public static Nox.Types.Area CreateInstallationFootPrint(System.Decimal value)
            => Nox.Types.Area.From(value);
        
    
        /// <summary>
        /// Factory for property 'RentPerSquareMetre'
        /// </summary>
        public static Nox.Types.Money CreateRentPerSquareMetre(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryId'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
            => Nox.Types.CountryCode2.From(value);
        
    
        /// <summary>
        /// Factory for property 'LandLordId'
        /// </summary>
        public static Nox.Types.Guid CreateLandLordId(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'MinimumCashStockId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateMinimumCashStockId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
        /// <summary>
        /// User Interface for property 'MacAddress'
        /// </summary>
        public static TypeUserInterface? MacAddressUiOptions {get; private set;} = new()
        {
            Label = "MacAddress", 
            IconPosition = IconPosition.Begin, 
            InputMask = "##:##:##:##:##:##", 
            PageGroup = "Details",
            InputOrder = 1,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'PublicIp'
        /// </summary>
        public static TypeUserInterface? PublicIpUiOptions {get; private set;} = new()
        {
            Label = "Public Ip", 
            IconPosition = IconPosition.Begin, 
            PageGroup = "Details",
            InputOrder = 2,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'GeoLocation'
        /// </summary>
        public static TypeUserInterface? GeoLocationUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            PageGroup = "Location",
            InputOrder = 1,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'StreetAddress'
        /// </summary>
        public static TypeUserInterface? StreetAddressUiOptions {get; private set;} = new()
        {
            IconPosition = IconPosition.Begin, 
            PageGroup = "Location",
            InputOrder = 2,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'SerialNumber'
        /// </summary>
        public static TypeUserInterface? SerialNumberUiOptions {get; private set;} = new()
        {
            Label = "Serial Number", 
            IconPosition = IconPosition.Begin, 
            PageGroup = "Details",
            InputOrder = 3,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'InstallationFootPrint'
        /// </summary>
        public static TypeUserInterface? InstallationFootPrintUiOptions {get; private set;} = new()
        {
            Label = "Installation Area", 
            IconPosition = IconPosition.Begin, 
            PageGroup = "Details",
            InputOrder = 4,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
        /// <summary>
        /// User Interface for property 'RentPerSquareMetre'
        /// </summary>
        public static TypeUserInterface? RentPerSquareMetreUiOptions {get; private set;} = new()
        {
            Label = "Rent per Square Metre", 
            IconPosition = IconPosition.Begin, 
            PageGroup = "Details",
            InputOrder = 5,
            ShowInSearchResults = ShowInSearchResultsOption.OptionalAndOnByDefault,
            CanSort = true,
            CanSearch = true, 
            CanFilter = true,
        }; 
}