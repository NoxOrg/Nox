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
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class StoreLicenseFactoryBase : IEntityFactory<StoreLicenseEntity, StoreLicenseCreateDto, StoreLicenseUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public StoreLicenseFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<StoreLicenseEntity> CreateEntityAsync(StoreLicenseCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(StoreLicenseEntity entity, StoreLicenseUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(StoreLicenseEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.StoreLicense> ToEntityAsync(StoreLicenseCreateDto createDto)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}