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
using CurrencyEntity = ClientApi.Domain.Currency;

namespace ClientApi.Application.Factories;

internal abstract class CurrencyFactoryBase : IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto>
{

    public CurrencyFactoryBase
    (
        )
    {
    }

    public virtual CurrencyEntity CreateEntity(CurrencyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CurrencyEntity entity, CurrencyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.Currency ToEntity(CurrencyCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Currency();
        entity.Id = CurrencyMetadata.CreateId(createDto.Id);
        if (createDto.Name is not null)entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(createDto.Name.NonNullValue<System.String>());
        if (createDto.Symbol is not null)entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(createDto.Symbol.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(CurrencyEntity entity, CurrencyUpdateDto updateDto)
    {
        if (updateDto.Name == null) { entity.Name = null; } else {
            entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
        }
        if (updateDto.Symbol == null) { entity.Symbol = null; } else {
            entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(updateDto.Symbol.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            if (SymbolUpdateValue == null) { entity.Symbol = null; }
            else
            {
                entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(SymbolUpdateValue);
            }
        }
    }
}

internal partial class CurrencyFactory : CurrencyFactoryBase
{
}