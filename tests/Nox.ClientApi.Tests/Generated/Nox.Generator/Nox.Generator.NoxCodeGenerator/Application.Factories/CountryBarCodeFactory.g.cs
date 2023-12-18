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
using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Factories;

internal partial class CountryBarCodeFactory : CountryBarCodeFactoryBase
{
    public CountryBarCodeFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryBarCodeFactoryBase : IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryBarCodeFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryBarCodeEntity> CreateEntityAsync(CountryBarCodeUpsertDto createDto)
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

    public virtual async Task UpdateEntityAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<ClientApi.Domain.CountryBarCode> ToEntityAsync(CountryBarCodeUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.CountryBarCode();
        entity.SetIfNotNull(createDto.BarCodeName, (entity) => entity.BarCodeName = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(createDto.BarCodeName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.BarCodeNumber, (entity) => entity.BarCodeNumber = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(updateDto.BarCodeName.NonNullValue<System.String>());
        if(updateDto.BarCodeNumber is null)
        {
             entity.BarCodeNumber = null;
        }
        else
        {
            entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(updateDto.BarCodeNumber.ToValueFromNonNull<System.Int32>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("BarCodeName", out var BarCodeNameUpdateValue))
        {
            if (BarCodeNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'BarCodeName' can't be null");
            }
            {
                entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(BarCodeNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("BarCodeNumber", out var BarCodeNumberUpdateValue))
        {
            if (BarCodeNumberUpdateValue == null) { entity.BarCodeNumber = null; }
            else
            {
                entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(BarCodeNumberUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}