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
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.CountryBarCode> ToEntityAsync(CountryBarCodeUpsertDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryBarCode();
        exceptionCollector.Collect("BarCodeName", () => entity.SetIfNotNull(createDto.BarCodeName, (entity) => entity.BarCodeName = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(createDto.BarCodeName.NonNullValue<System.String>())));
        exceptionCollector.Collect("BarCodeNumber", () => entity.SetIfNotNull(createDto.BarCodeNumber, (entity) => entity.BarCodeNumber = 
            ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(createDto.BarCodeNumber.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryBarCodeEntity entity, CountryBarCodeUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("BarCodeName",() => entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(updateDto.BarCodeName.NonNullValue<System.String>()));
        if(updateDto.BarCodeNumber is null)
        {
             entity.BarCodeNumber = null;
        }
        else
        {
            exceptionCollector.Collect("BarCodeNumber",() =>entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(updateDto.BarCodeNumber.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryBarCodeEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("BarCodeName", out var BarCodeNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(BarCodeNameUpdateValue, "Attribute 'BarCodeName' can't be null.");
            {
                exceptionCollector.Collect("BarCodeName",() =>entity.BarCodeName = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeName(BarCodeNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("BarCodeNumber", out var BarCodeNumberUpdateValue))
        {
            if (BarCodeNumberUpdateValue == null) { entity.BarCodeNumber = null; }
            else
            {
                exceptionCollector.Collect("BarCodeNumber",() =>entity.BarCodeNumber = ClientApi.Domain.CountryBarCodeMetadata.CreateBarCodeNumber(BarCodeNumberUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}