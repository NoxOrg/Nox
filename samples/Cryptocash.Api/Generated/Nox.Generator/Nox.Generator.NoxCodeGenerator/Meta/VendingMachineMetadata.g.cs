// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

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
        public static Nox.Types.AutoNumber CreateLandLordId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
        /// <summary>
        /// Factory for property 'MinimumCashStockId'
        /// </summary>
        public static Nox.Types.AutoNumber CreateMinimumCashStockId(System.Int64 value)
            => Nox.Types.AutoNumber.FromDatabase(value);
        

        /// <summary>
        /// User Interface for property 'MacAddress'
        /// </summary>
        public static TypeUserInterface? MacAddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("MacAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PublicIp'
        /// </summary>
        public static TypeUserInterface? PublicIpUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("PublicIp")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GeoLocation'
        /// </summary>
        public static TypeUserInterface? GeoLocationUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("GeoLocation")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'StreetAddress'
        /// </summary>
        public static TypeUserInterface? StreetAddressUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("StreetAddress")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'SerialNumber'
        /// </summary>
        public static TypeUserInterface? SerialNumberUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("SerialNumber")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'InstallationFootPrint'
        /// </summary>
        public static TypeUserInterface? InstallationFootPrintUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("InstallationFootPrint")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'RentPerSquareMetre'
        /// </summary>
        public static TypeUserInterface? RentPerSquareMetreUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("VendingMachine")
                .GetAttributeByName("RentPerSquareMetre")?
                .UserInterface;
}