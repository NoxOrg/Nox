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
        return await ToEntityAsync(createDto);
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
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Currency();
        exceptionCollector.Collect("Id",() => entity.Id = CurrencyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CurrencyMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Symbol", () => entity.SetIfNotNull(createDto.Symbol, (entity) => entity.Symbol = 
            ClientApi.Domain.CurrencyMetadata.CreateSymbol(createDto.Symbol.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(updateDto.Name is null)
        {
             entity.Name = null;
        }
        else
        {
            exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(updateDto.Name.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.Symbol is null)
        {
             entity.Symbol = null;
        }
        else
        {
            exceptionCollector.Collect("Symbol",() =>entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(updateDto.Symbol.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null) { entity.Name = null; }
            else
            {
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.CurrencyMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            if (SymbolUpdateValue == null) { entity.Symbol = null; }
            else
            {
                exceptionCollector.Collect("Symbol",() =>entity.Symbol = ClientApi.Domain.CurrencyMetadata.CreateSymbol(SymbolUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}