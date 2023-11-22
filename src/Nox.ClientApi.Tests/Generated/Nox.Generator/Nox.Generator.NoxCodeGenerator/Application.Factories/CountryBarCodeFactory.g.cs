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

internal abstract class CountryBarCodeFactoryBase : IEntityFactory<CountryBarCodeEntity, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public CountryBarCodeFactoryBase
    (
        )
    {
    }

    public virtual CountryBarCodeEntity CreateEntity(CountryBarCodeUpsertDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.CountryBarCode ToEntity(CountryBarCodeUpsertDto createDto)
    {
        var entity = new ClientApi.Domain.CountryBarCode();
        entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(createDto.BarCodeName);
        entity.SetIfNotNull(createDto.BarCodeNumber, (entity) => entity.BarCodeNumber =ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>()));
        return entity;
    }

    private void UpdateEntityInternal(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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

internal partial class CountryBarCodeFactory : CountryBarCodeFactoryBase
{
}