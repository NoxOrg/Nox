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

public abstract class CountryBarCodeFactoryBase : IEntityFactory<CountryBarCode, CountryBarCodeCreateDto, CountryBarCodeUpdateDto>
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

    public void UpdateEntity(CountryBarCode entity, CountryBarCodeUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private ClientApi.Domain.CountryBarCode ToEntity(CountryBarCodeCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryBarCode();
        entity.BarCodeName = ClientApi.Domain.CountryBarCode.CreateBarCodeName(createDto.BarCodeName);
        if (createDto.BarCodeNumber is not null)entity.BarCodeNumber = ClientApi.Domain.CountryBarCode.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>());
        return entity;
    }

    private void MapEntity(CountryBarCode entity, CountryBarCodeUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.BarCodeName = ClientApi.Domain.CountryBarCode.CreateBarCodeName(updateDto.BarCodeName);
        if (updateDto.BarCodeNumber is not null)entity.BarCodeNumber = ClientApi.Domain.CountryBarCode.CreateBarCodeNumber(updateDto.BarCodeNumber.NonNullValue<System.Int32>());

        // TODO: discuss about keys
    }
}

public partial class CountryBarCodeFactory : CountryBarCodeFactoryBase
{
}