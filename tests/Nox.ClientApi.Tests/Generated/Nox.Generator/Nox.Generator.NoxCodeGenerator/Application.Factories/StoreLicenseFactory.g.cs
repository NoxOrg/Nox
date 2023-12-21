
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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Factories;

internal partial class StoreLicenseFactory : StoreLicenseFactoryBase
{
    public StoreLicenseFactory
    (
    ) : base()
    {}
}

internal abstract class StoreLicenseFactoryBase : IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto>
{

    public StoreLicenseFactoryBase(
        )
    {
    }

    public virtual async Task<StoreLicenseEntity> CreateEntityAsync(StoreLicenseCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreLicenseEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(StoreLicenseEntity entity, StoreLicenseUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreLicenseEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(StoreLicenseEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(StoreLicenseEntity));
        }   
    }

    private async Task<ClientApi.Domain.StoreLicense> ToEntityAsync(StoreLicenseCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.StoreLicense();
        exceptionCollector.Collect("Issuer", () => entity.SetIfNotNull(createDto.Issuer, (entity) => entity.Issuer = 
            ClientApi.Domain.StoreLicenseMetadata.CreateIssuer(createDto.Issuer.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(StoreLicenseEntity entity, StoreLicenseUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Issuer",() => entity.Issuer = ClientApi.Domain.StoreLicenseMetadata.CreateIssuer(updateDto.Issuer.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(StoreLicenseEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Issuer", out var IssuerUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(IssuerUpdateValue, "Attribute 'Issuer' can't be null.");
            {
                exceptionCollector.Collect("Issuer",() =>entity.Issuer = ClientApi.Domain.StoreLicenseMetadata.CreateIssuer(IssuerUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}