// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using VendingMachine = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application;

public class VendingMachineMapper : EntityMapperBase<VendingMachine>
{
    public VendingMachineMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(VendingMachine entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition, "MacAddress", dto.MacAddress);
        if (noxTypeValue != null)
        {        
            entity.MacAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition, "PublicIp", dto.PublicIp);
        if (noxTypeValue != null)
        {        
            entity.PublicIp = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoLocation", dto.GeoLocation);
        if (noxTypeValue != null)
        {        
            entity.GeoLocation = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "StreetAddress", dto.StreetAddress);
        if (noxTypeValue != null)
        {        
            entity.StreetAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "SerialNumber", dto.SerialNumber);
        if (noxTypeValue != null)
        {        
            entity.SerialNumber = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition, "InstallationFootPrint", dto.InstallationFootPrint);
        if (noxTypeValue != null)
        {        
            entity.InstallationFootPrint = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "RentPerSquareMetre", dto.RentPerSquareMetre);
        if (noxTypeValue != null)
        {        
            entity.RentPerSquareMetre = noxTypeValue;
        }
    

        /// <summary>
        /// VendingMachine installed in ExactlyOne Countries
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "VendingMachineInstallationCountry", dto.CountryId);
        if (noxTypeValue != null)
        {        
            entity.CountryId = noxTypeValue;
        }

        /// <summary>
        /// VendingMachine contracted area leased by ExactlyOne LandLords
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "VendingMachineContractedAreaLandLord", dto.LandLordId);
        if (noxTypeValue != null)
        {        
            entity.LandLordId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(VendingMachine entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("MacAddress", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition, "MacAddress", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("VendingMachine", "MacAddress");
                }
                else
                {
                    entity.MacAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PublicIp", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition, "PublicIp", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("VendingMachine", "PublicIp");
                }
                else
                {
                    entity.PublicIp = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoLocation", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoLocation", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("VendingMachine", "GeoLocation");
                }
                else
                {
                    entity.GeoLocation = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("StreetAddress", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "StreetAddress", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("VendingMachine", "StreetAddress");
                }
                else
                {
                    entity.StreetAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SerialNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "SerialNumber", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("VendingMachine", "SerialNumber");
                }
                else
                {
                    entity.SerialNumber = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("InstallationFootPrint", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition, "InstallationFootPrint", value);
                if(noxTypeValue == null)
                {
                    entity.InstallationFootPrint = null;
                }
                else
                {
                    entity.InstallationFootPrint = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("RentPerSquareMetre", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "RentPerSquareMetre", value);
                if(noxTypeValue == null)
                {
                    entity.RentPerSquareMetre = null;
                }
                else
                {
                    entity.RentPerSquareMetre = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// VendingMachine installed in ExactlyOne Countries
        /// </summary>
        if (updatedProperties.TryGetValue("CountryId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "VendingMachineInstallationCountry", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CountryId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// VendingMachine contracted area leased by ExactlyOne LandLords
        /// </summary>
        if (updatedProperties.TryGetValue("LandLordId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "VendingMachineContractedAreaLandLord", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.LandLordId = noxRelationshipTypeValue;
            }
        }
    }
}