// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

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
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application.Factories;

internal abstract class LandLordFactoryBase : IEntityFactory<LandLord, LandLordCreateDto, LandLordUpdateDto>
{

    public LandLordFactoryBase
    (
        )
    {
    }

    public virtual LandLord CreateEntity(LandLordCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(LandLord entity, LandLordUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(LandLord entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.LandLord ToEntity(LandLordCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.LandLord();
        entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(createDto.Name);
        entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(createDto.Address);
        return entity;
    }

    private void UpdateEntityInternal(LandLord entity, LandLordUpdateDto updateDto)
    {
        entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
    }

    private void PartialUpdateEntityInternal(LandLord entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.LandLordMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            if (AddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Address' can't be null");
            }
            {
                entity.Address = Cryptocash.Domain.LandLordMetadata.CreateAddress(AddressUpdateValue);
            }
        }
    }
}

internal partial class LandLordFactory : LandLordFactoryBase
{
}