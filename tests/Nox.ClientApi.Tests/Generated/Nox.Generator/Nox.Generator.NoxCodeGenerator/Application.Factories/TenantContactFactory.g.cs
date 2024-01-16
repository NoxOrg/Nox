
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
using TenantContactEntity = ClientApi.Domain.TenantContact;

namespace ClientApi.Application.Factories;

internal partial class TenantContactFactory : TenantContactFactoryBase
{
    public TenantContactFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> tenantContactLocalizedFactory,
        NoxSolution noxSolution
    ) : base(repository, tenantContactLocalizedFactory, noxSolution)
    {}
}

internal abstract class TenantContactFactoryBase : IEntityFactory<TenantContactEntity, TenantContactUpsertDto, TenantContactUpsertDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> TenantContactLocalizedFactory;
    private readonly IRepository _repository;

    public TenantContactFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<TenantContactLocalized, TenantContactEntity, TenantContactUpsertDto> tenantContactLocalizedFactory,
        NoxSolution noxSolution
        )
    {
        _repository = repository;
        TenantContactLocalizedFactory = tenantContactLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
    }

    public virtual async Task<TenantContactEntity> CreateEntityAsync(TenantContactUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            TenantContactLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantContactEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await TenantContactLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantContactEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await TenantContactLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(TenantContactEntity));
        }   
    }

    private async Task<ClientApi.Domain.TenantContact> ToEntityAsync(TenantContactUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.TenantContact();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.TenantContactMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            Dto.TenantContactMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));
        exceptionCollector.Collect("Email", () => entity.SetIfNotNull(createDto.Email, (entity) => entity.Email = 
            Dto.TenantContactMetadata.CreateEmail(createDto.Email.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TenantContactEntity entity, TenantContactUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.TenantContactMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("Description",() => entity.Description = Dto.TenantContactMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>()));
        exceptionCollector.Collect("Email",() => entity.Email = Dto.TenantContactMetadata.CreateEmail(updateDto.Email.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TenantContactEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.TenantContactMetadata.CreateName(NameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DescriptionUpdateValue, "Attribute 'Description' can't be null.");
            {
                exceptionCollector.Collect("Description",() =>entity.Description = Dto.TenantContactMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Email", out var EmailUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EmailUpdateValue, "Attribute 'Email' can't be null.");
            {
                exceptionCollector.Collect("Email",() =>entity.Email = Dto.TenantContactMetadata.CreateEmail(EmailUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}