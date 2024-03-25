﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Extensions;
using Nox.Exceptions;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;
using WorkplaceEntity = ClientApi.Domain.Workplace;

namespace ClientApi.Application.Commands;

public partial record UpdateWorkplaceAddressesForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, IEnumerable<WorkplaceAddressUpsertDto> EntitiesDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<IEnumerable<WorkplaceAddressKeyDto>>;

internal partial class UpdateWorkplaceAddressesForWorkplaceCommandHandler : UpdateWorkplaceAddressesForWorkplaceCommandHandlerBase
{
	public UpdateWorkplaceAddressesForWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateWorkplaceAddressesForWorkplaceCommandHandlerBase : CommandCollectionBase<UpdateWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler <UpdateWorkplaceAddressesForWorkplaceCommand, IEnumerable<WorkplaceAddressKeyDto>>
{
	private readonly IRepository _repository;
	private readonly IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> _entityFactory;

	protected UpdateWorkplaceAddressesForWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		_repository = repository;
		_entityFactory = entityFactory;
	}

	public virtual async Task<IEnumerable<WorkplaceAddressKeyDto>> Handle(UpdateWorkplaceAddressesForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await _repository.FindAndIncludeAsync<ClientApi.Domain.Workplace>(keys.ToArray(),e => e.WorkplaceAddresses, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Workplace",  "keyId");				
		List<WorkplaceAddressEntity> entities = new(request.EntitiesDto.Count());
		foreach(var entityDto in request.EntitiesDto)
		{
			WorkplaceAddressEntity? entity;
			if(entityDto.Id is null)
			{
				entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
				parentEntity.CreateWorkplaceAddresses(entity);
			}
			else
			{
				var ownedId = Dto.WorkplaceAddressMetadata.CreateId(entityDto.Id.NonNullValue<System.Guid>());
				entity = parentEntity.WorkplaceAddresses.SingleOrDefault(x => x.Id == ownedId);
				if (entity is null)
				{
					entity = await CreateEntityAsync(entityDto, parentEntity, request.CultureCode);
					parentEntity.CreateWorkplaceAddresses(entity);
				}
				else
				{
					await _entityFactory.UpdateEntityAsync(entity, entityDto, request.CultureCode);
				}
			}

			entities.Add(entity);
		}

		parentEntity.Etag = request.Etag ?? System.Guid.Empty;		
		_repository.Update(parentEntity);
		await OnCompletedAsync(request, entities!);
		await _repository.SaveChangesAsync();

		return entities.Select(entity => new WorkplaceAddressKeyDto(entity.Id.Value));
	}
	
	private async Task<WorkplaceAddressEntity> CreateEntityAsync(WorkplaceAddressUpsertDto upsertDto, WorkplaceEntity parent, Nox.Types.CultureCode cultureCode)
	{
		var entity = await _entityFactory.CreateEntityAsync(upsertDto, cultureCode);
		parent.CreateWorkplaceAddresses(entity);
		return entity;
	}
}

public class UpdateWorkplaceAddressesForWorkplaceCommandValidator : AbstractValidator<UpdateWorkplaceAddressesForWorkplaceCommand>
{
    public UpdateWorkplaceAddressesForWorkplaceCommandValidator()
    { 
    }
}