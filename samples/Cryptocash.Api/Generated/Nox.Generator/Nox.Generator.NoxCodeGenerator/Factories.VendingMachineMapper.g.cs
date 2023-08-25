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
using CryptocashApi.Application.Dto;
using CryptocashApi.Domain;

namespace CryptocashApi.Application;

public class VendingMachineMapper: EntityMapperBase<VendingMachine>
{
    public  VendingMachineMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(VendingMachine entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition,"MacAddress",dto.MacAddress);
        if(noxTypeValue != null)
        {        
            entity.MacAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition,"PublicIp",dto.PublicIp);
        if(noxTypeValue != null)
        {        
            entity.PublicIp = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"GeoLocation",dto.GeoLocation);
        if(noxTypeValue != null)
        {        
            entity.GeoLocation = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"StreetAddress",dto.StreetAddress);
        if(noxTypeValue != null)
        {        
            entity.StreetAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"SerialNumber",dto.SerialNumber);
        if(noxTypeValue != null)
        {        
            entity.SerialNumber = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition,"InstallationFootPrint",dto.InstallationFootPrint);
        if(noxTypeValue != null)
        {        
            entity.InstallationFootPrint = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"RentPerSquareMetre",dto.RentPerSquareMetre);
        if(noxTypeValue != null)
        {        
            entity.RentPerSquareMetre = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(VendingMachine entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("MacAddress", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.MacAddress>(entityDefinition,"MacAddress",value);
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
            if (updatedProperties.TryGetValue("PublicIp", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.IpAddress>(entityDefinition,"PublicIp",value);
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
            if (updatedProperties.TryGetValue("GeoLocation", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"GeoLocation",value);
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
            if (updatedProperties.TryGetValue("StreetAddress", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"StreetAddress",value);
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
            if (updatedProperties.TryGetValue("SerialNumber", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"SerialNumber",value);
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
            if (updatedProperties.TryGetValue("InstallationFootPrint", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition,"InstallationFootPrint",value);
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
            if (updatedProperties.TryGetValue("RentPerSquareMetre", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"RentPerSquareMetre",value);
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
    }
}