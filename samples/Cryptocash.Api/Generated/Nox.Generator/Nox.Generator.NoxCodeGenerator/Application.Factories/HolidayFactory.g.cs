// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using HolidayEntity = Cryptocash.Domain.Holiday;

namespace Cryptocash.Application.Factories;

internal abstract class HolidayFactoryBase : IEntityFactory<HolidayEntity, HolidayCreateDto, HolidayUpdateDto>
{

    public HolidayFactoryBase
    (
        )
    {
    }

    public virtual HolidayEntity CreateEntity(HolidayCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(HolidayEntity entity, HolidayUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.Holiday ToEntity(HolidayCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Holiday();
        entity.Name = Cryptocash.Domain.HolidayMetadata.CreateName(createDto.Name);
        entity.Type = Cryptocash.Domain.HolidayMetadata.CreateType(createDto.Type);
        entity.Date = Cryptocash.Domain.HolidayMetadata.CreateDate(createDto.Date);
        return entity;
    }

    private void UpdateEntityInternal(HolidayEntity entity, HolidayUpdateDto updateDto)
    {
        entity.Name = Cryptocash.Domain.HolidayMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Type = Cryptocash.Domain.HolidayMetadata.CreateType(updateDto.Type.NonNullValue<System.String>());
        entity.Date = Cryptocash.Domain.HolidayMetadata.CreateDate(updateDto.Date.NonNullValue<System.DateTime>());
    }

    private void PartialUpdateEntityInternal(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.HolidayMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            if (TypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Type' can't be null");
            }
            {
                entity.Type = Cryptocash.Domain.HolidayMetadata.CreateType(TypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Date", out var DateUpdateValue))
        {
            if (DateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Date' can't be null");
            }
            {
                entity.Date = Cryptocash.Domain.HolidayMetadata.CreateDate(DateUpdateValue);
            }
        }
    }
}

internal partial class HolidayFactory : HolidayFactoryBase
{
}