
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
using TenantBrandEntity = ClientApi.Domain.TenantBrand;

namespace ClientApi.Application.Factories;

internal partial class TenantBrandFactory : TenantBrandFactoryBase
{
    public TenantBrandFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> tenantBrandLocalizedFactory
    ) : base(repository, tenantBrandLocalizedFactory)
    {}
}

internal abstract class TenantBrandFactoryBase : IEntityFactory<TenantBrandEntity, TenantBrandUpsertDto, TenantBrandUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    protected readonly IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> TenantBrandLocalizedFactory;
    private readonly IRepository _repository;

    public TenantBrandFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<TenantBrandLocalized, TenantBrandEntity, TenantBrandUpsertDto> tenantBrandLocalizedFactory
        )
    {
        _repository = repository;
        TenantBrandLocalizedFactory = tenantBrandLocalizedFactory;
    }

    public virtual async Task<TenantBrandEntity> CreateEntityAsync(TenantBrandUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            await TenantBrandLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await TenantBrandLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        await TenantBrandLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    public virtual async Task PartialUpdateEntityAsync(TenantBrandEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await TenantBrandLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await TenantBrandLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<ClientApi.Domain.TenantBrand> ToEntityAsync(TenantBrandUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.TenantBrand();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.TenantBrandMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            ClientApi.Domain.TenantBrandMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TenantBrandEntity entity, TenantBrandUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = ClientApi.Domain.TenantBrandMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("Description",() => entity.Description = ClientApi.Domain.TenantBrandMetadata.CreateDescription(updateDto.Description.NonNullValue<System.String>()));

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
                exceptionCollector.Collect("Name",() =>entity.Name = ClientApi.Domain.TenantBrandMetadata.CreateName(NameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DescriptionUpdateValue, "Attribute 'Description' can't be null.");
            {
                exceptionCollector.Collect("Description",() =>entity.Description = ClientApi.Domain.TenantBrandMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}