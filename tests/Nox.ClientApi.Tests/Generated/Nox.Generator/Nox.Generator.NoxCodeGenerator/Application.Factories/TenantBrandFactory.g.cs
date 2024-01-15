
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Factories;

internal partial class TenantBrandFactory : TenantBrandFactoryBase
{
    public TenantBrandFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> tenantBrandLocalizedFactory,
        NoxSolution noxSolution
    ) : base(repository, tenantBrandLocalizedFactory, noxSolution)
    {}
}

internal abstract class TenantBrandFactoryBase : IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> TenantBrandLocalizedFactory;
    private readonly IRepository _repository;

    public TenantBrandFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> tenantBrandLocalizedFactory,
        NoxSolution noxSolution
        )
    {
        _repository = repository;
        TenantBrandLocalizedFactory = tenantBrandLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
    }

    public virtual async Task<TenantBrandEntity> CreateEntityAsync(TenantBrandUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            TenantBrandLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantBrandEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await TenantBrandLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantBrandEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await TenantBrandLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantBrandEntity));
        }   
    }

    private async Task<ClientApi.Domain.TenantBrand> ToEntityAsync(TenantBrandUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.TenantBrand();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.TenantBrandMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            Dto.TenantBrandMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.TenantBrandMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("Description",() => entity.Description = Dto.TenantBrandMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.TenantBrandMetadata.CreateName(NameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DescriptionUpdateValue, "Attribute 'Description' can't be null.");
            {
                exceptionCollector.Collect("Description",() =>entity.Description = Dto.TenantBrandMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}