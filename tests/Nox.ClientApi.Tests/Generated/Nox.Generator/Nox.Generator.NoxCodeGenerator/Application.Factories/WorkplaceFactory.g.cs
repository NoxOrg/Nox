
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
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Factories;

internal partial class WorkplaceFactory : WorkplaceFactoryBase
{
    public WorkplaceFactory
    (
        IRepository repository,
        IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> workplaceLocalizedFactory,
        NoxSolution noxSolution,
        IEntityFactory<ClientApi.Domain.WorkplaceAddress, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> workplaceaddressfactory
    ) : base(repository, workplaceLocalizedFactory, noxSolution, workplaceaddressfactory)
    {}
}

internal abstract class WorkplaceFactoryBase : IEntityFactory<WorkplaceEntity, WorkplaceCreateDto, WorkplaceUpdateDto>
{
    private readonly Nox.Types.CultureCode _defaultCultureCode;
    protected readonly IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> WorkplaceLocalizedFactory;
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.WorkplaceAddress, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> WorkplaceAddressFactory {get;}

    public WorkplaceFactoryBase(
        IRepository repository,
        IEntityLocalizedFactory<WorkplaceLocalized, WorkplaceEntity, WorkplaceUpdateDto> workplaceLocalizedFactory,
        NoxSolution noxSolution,
        IEntityFactory<ClientApi.Domain.WorkplaceAddress, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> workplaceaddressfactory
        )
    {
        _repository = repository;
        WorkplaceLocalizedFactory = workplaceLocalizedFactory;
        _defaultCultureCode = Nox.Types.CultureCode.From(noxSolution!.Application!.Localization!.DefaultCulture);
        WorkplaceAddressFactory = workplaceaddressfactory;
    }

    public virtual async Task<WorkplaceEntity> CreateEntityAsync(WorkplaceCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            WorkplaceLocalizedFactory.CreateLocalizedEntity(entity, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
            await WorkplaceLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await WorkplaceLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
        
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(WorkplaceEntity));
        }   
    }

    private async Task<ClientApi.Domain.Workplace> ToEntityAsync(WorkplaceCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Workplace();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.WorkplaceMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Description", () => entity.SetIfNotNull(createDto.Description, (entity) => entity.Description = 
            Dto.WorkplaceMetadata.CreateDescription(createDto.Description.NonNullValue<System.String>())));
        exceptionCollector.Collect("Ownership", () => entity.SetIfNotNull(createDto.Ownership, (entity) => entity.Ownership = 
            Dto.WorkplaceMetadata.CreateOwnership(createDto.Ownership.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("Type", () => entity.SetIfNotNull(createDto.Type, (entity) => entity.Type = 
            Dto.WorkplaceMetadata.CreateType(createDto.Type.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        var nextSequenceReferenceNumber =  await _repository.GetSequenceNextValueAsync(Nox.Solution.NoxCodeGenConventions.GetDatabaseSequenceName("Workplace", "ReferenceNumber"));
        entity.EnsureReferenceNumber(nextSequenceReferenceNumber,Dto.WorkplaceMetadata.ReferenceNumberTypeOptions);
        //createDto.WorkplaceAddresses?.ForEach(async dto =>
        //{
        //    var workplaceAddress = await WorkplaceAddressFactory.CreateEntityAsync(dto, cultureCode);
        //    entity.CreateWorkplaceAddresses(workplaceAddress);
        //});
        if(createDto.WorkplaceAddresses is not null)
        {
            foreach (var dto in createDto.WorkplaceAddresses)
            {
                var workplaceAddress = WorkplaceAddressFactory.CreateEntityAsync(dto, cultureCode).Result;
                entity.CreateWorkplaceAddresses(workplaceAddress);
            }
        }        
        return entity;
    }

    private async Task UpdateEntityInternalAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.WorkplaceMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(IsDefaultCultureCode(cultureCode)) if(updateDto.Description is null)
        {
             entity.Description = null;
        }
        else
        {
            exceptionCollector.Collect("Description",() =>entity.Description = Dto.WorkplaceMetadata.CreateDescription(updateDto.Description.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.Ownership is null)
        {
             entity.Ownership = null;
        }
        else
        {
            exceptionCollector.Collect("Ownership",() =>entity.Ownership = Dto.WorkplaceMetadata.CreateOwnership(updateDto.Ownership.ToValueFromNonNull<System.Int32>()));
        }
        if(updateDto.Type is null)
        {
             entity.Type = null;
        }
        else
        {
            exceptionCollector.Collect("Type",() =>entity.Type = Dto.WorkplaceMetadata.CreateType(updateDto.Type.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(WorkplaceEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.WorkplaceMetadata.CreateName(NameUpdateValue));
            }
        }

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Description", out var DescriptionUpdateValue))
        {
            if (DescriptionUpdateValue == null) { entity.Description = null; }
            else
            {
                exceptionCollector.Collect("Description",() =>entity.Description = Dto.WorkplaceMetadata.CreateDescription(DescriptionUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Ownership", out var OwnershipUpdateValue))
        {
            if (OwnershipUpdateValue == null) { entity.Ownership = null; }
            else
            {
                exceptionCollector.Collect("Ownership",() =>entity.Ownership = Dto.WorkplaceMetadata.CreateOwnership(OwnershipUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Type", out var TypeUpdateValue))
        {
            if (TypeUpdateValue == null) { entity.Type = null; }
            else
            {
                exceptionCollector.Collect("Type",() =>entity.Type = Dto.WorkplaceMetadata.CreateType(TypeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
    private bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		await UpdateWorkplaceAddressesAsync(entity, updateDto, cultureCode);
	}

    private async Task UpdateWorkplaceAddressesAsync(WorkplaceEntity entity, WorkplaceUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(updateDto.WorkplaceAddresses is null)
            return;

        if(!updateDto.WorkplaceAddresses.Any())
        { 
            _repository.DeleteOwned(entity.WorkplaceAddresses);
			entity.DeleteAllWorkplaceAddresses();
        }
		else
		{
			var updatedWorkplaceAddresses = new List<ClientApi.Domain.WorkplaceAddress>();
			foreach(var ownedUpsertDto in updateDto.WorkplaceAddresses)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await WorkplaceAddressFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedWorkplaceAddresses.Add(ownedEntity);
                }
				else
				{
					var key = Dto.WorkplaceAddressMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Guid>());
					var ownedEntity = entity.WorkplaceAddresses.Find(x => x.Id == key);
					if(ownedEntity is null)
						updatedWorkplaceAddresses.Add(await WorkplaceAddressFactory.CreateEntityAsync(ownedUpsertDto, cultureCode));
					else
					{
						await WorkplaceAddressFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedWorkplaceAddresses.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.WorkplaceAddress>(
                entity.WorkplaceAddresses.Where(x => !updatedWorkplaceAddresses.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateWorkplaceAddresses(updatedWorkplaceAddresses);
		}
	}
}