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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using HolidayEntity = ClientApi.Domain.Holiday;

namespace ClientApi.Application.Factories;

internal abstract class HolidayFactoryBase : IEntityFactory<HolidayEntity, HolidayUpsertDto, HolidayUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public HolidayFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual HolidayEntity CreateEntity(HolidayUpsertDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Holiday ToEntity(HolidayUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.Holiday();
        entity.Name = ClientApi.Domain.HolidayMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.Type, (entity) => entity.Type =ClientApi.Domain.HolidayMetadata.CreateType(createDto.Type.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Date, (entity) => entity.Date =ClientApi.Domain.HolidayMetadata.CreateDate(createDto.Date.NonNullValue<System.DateTime>()));
        entity.EnsureId(createDto.Id);
        return entity;
    }

    private void UpdateEntityInternal(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.HolidayMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(updateDto.Type is null)
        {
             entity.Type = null;
        }
        else
        {
            entity.Type = ClientApi.Domain.HolidayMetadata.CreateType(updateDto.Type.ToValueFromNonNull<System.String>());
        }
        if(updateDto.Date is null)
        {
             entity.Date = null;
        }
        else
        {
            entity.Date = ClientApi.Domain.HolidayMetadata.CreateDate(updateDto.Date.ToValueFromNonNull<System.DateTime>());
        }
    }

    private void PartialUpdateEntityInternal(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.HolidayMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            if (TypeUpdateValue == null) { entity.Type = null; }
            else
            {
                entity.Type = ClientApi.Domain.HolidayMetadata.CreateType(TypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Date", out var DateUpdateValue))
        {
            if (DateUpdateValue == null) { entity.Date = null; }
            else
            {
                entity.Date = ClientApi.Domain.HolidayMetadata.CreateDate(DateUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class HolidayFactory : HolidayFactoryBase
{
    public HolidayFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}