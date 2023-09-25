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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryBarCode = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application.Factories;

internal abstract class CountryBarCodeFactoryBase : IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto>
{

    public CountryBarCodeFactoryBase
    (
        )
    {
    }

    public virtual CountryBarCode CreateEntity(CountryBarCodeCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryBarCode entity, CountryBarCodeUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private ClientApi.Domain.CountryBarCode ToEntity(CountryBarCodeCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryBarCode();
        entity.BarCodeName = ClientApi.Domain.CountryBarCode.CreateBarCodeName(createDto.BarCodeName);
        if (createDto.BarCodeNumber is not null)entity.BarCodeNumber = ClientApi.Domain.CountryBarCode.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>());
        return entity;
    }

    private void UpdateEntityInternal(CountryBarCode entity, CountryBarCodeUpdateDto updateDto)
    {
        entity.BarCodeName = ClientApi.Domain.CountryBarCode.CreateBarCodeName(updateDto.BarCodeName.NonNullValue<System.String>());
        if (updateDto.BarCodeNumber == null) { entity.BarCodeNumber = null; } else {
            entity.BarCodeNumber = ClientApi.Domain.CountryBarCode.CreateBarCodeNumber(updateDto.BarCodeNumber.ToValueFromNonNull<System.Int32>());
        }
    }
}

internal partial class CountryBarCodeFactory : CountryBarCodeFactoryBase
{
}