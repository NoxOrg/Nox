
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
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;

namespace ClientApi.Application.Factories;

internal partial class WorkplaceAddressFactory : WorkplaceAddressFactoryBase
{
    public WorkplaceAddressFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<WorkplaceAddressLocalized, WorkplaceAddressEntity, WorkplaceAddressUpsertDto> workplaceAddressLocalizedFactory,
        NoxSolution noxSolution
    ) : base(repository, workplaceAddressLocalizedFactory, noxSolution)
    {}
}

internal abstract class WorkplaceAddressFactoryBase : IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<WorkplaceAddressLocalized, WorkplaceAddressEntity, WorkplaceAddressUpsertDto> WorkplaceAddressLocalizedFactory;
    private readonly IRepository _repository;

    public WorkplaceAddressFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<WorkplaceAddressLocalized, WorkplaceAddressEntity, WorkplaceAddressUpsertDto> workplaceAddressLocalizedFactory,
        NoxSolution noxSolution
        )
    {
        _repository = repository;
        WorkplaceAddressLocalizedFactory = workplaceAddressLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
    }

    public virtual async Task<WorkplaceAddressEntity> CreateEntityAsync(WorkplaceAddressUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            WorkplaceAddressLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceAddressEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(WorkplaceAddressEntity entity, WorkplaceAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await WorkplaceAddressLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceAddressEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(WorkplaceAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await WorkplaceAddressLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceAddressEntity));
        }   
    }

    private async Task<ClientApi.Domain.WorkplaceAddress> ToEntityAsync(WorkplaceAddressUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.WorkplaceAddress();
        exceptionCollector.Collect("AddressLine", () => entity.SetIfNotNull(createDto.AddressLine, (entity) => entity.AddressLine = 
            Dto.WorkplaceAddressMetadata.CreateAddressLine(createDto.AddressLine.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(WorkplaceAddressEntity entity, WorkplaceAddressUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        if(IsDefaultCultureCode(cultureCode)) exceptionCollector.Collect("AddressLine",() => entity.AddressLine = Dto.WorkplaceAddressMetadata.CreateAddressLine(updateDto.AddressLine.NonNullValue<System.String>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(WorkplaceAddressEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("AddressLine", out var AddressLineUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AddressLineUpdateValue, "Attribute 'AddressLine' can't be null.");
            {
                exceptionCollector.Collect("AddressLine",() =>entity.AddressLine = Dto.WorkplaceAddressMetadata.CreateAddressLine(AddressLineUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}