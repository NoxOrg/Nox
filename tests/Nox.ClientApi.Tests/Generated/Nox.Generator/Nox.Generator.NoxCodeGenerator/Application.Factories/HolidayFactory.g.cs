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

internal partial class HolidayFactory : HolidayFactoryBase
{
    public HolidayFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

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

    public virtual async Task<HolidayEntity> CreateEntityAsync(HolidayUpsertDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(HolidayEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<ClientApi.Domain.Holiday> ToEntityAsync(HolidayUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.Holiday();
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.HolidayMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Type, (entity) => entity.Type = 
            ClientApi.Domain.HolidayMetadata.CreateType(createDto.Type.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Date, (entity) => entity.Date = 
            ClientApi.Domain.HolidayMetadata.CreateDate(createDto.Date.NonNullValue<System.DateTime>()));
        entity.EnsureId(createDto.Id);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(HolidayEntity entity, HolidayUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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
        await Task.CompletedTask;
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