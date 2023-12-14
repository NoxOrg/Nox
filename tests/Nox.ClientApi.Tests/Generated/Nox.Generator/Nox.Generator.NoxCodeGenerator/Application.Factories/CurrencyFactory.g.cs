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

internal partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CurrencyFactoryBase : IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CurrencyFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CurrencyEntity> CreateEntityAsync(CurrencyCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.Currency> ToEntityAsync(CurrencyCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Currency();
        entity.Id = CurrencyMetadata.CreateId(createDto.Id.NonNullValue<System.String>());
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CurrencyMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Symbol, (entity) => entity.Symbol = 
            ClientApi.Domain.CurrencyMetadata.CreateSymbol(createDto.Symbol.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>());
        }
        if(updateDto.Symbol is null)
        {
             entity.Symbol = null;
        }
        else
        {
            entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(updateDto.Symbol.ToValueFromNonNull<System.String>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}