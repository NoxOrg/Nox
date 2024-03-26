﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;

namespace ClientApi.Application.Commands;
public partial record PartialUpdateWorkplaceAddressesForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, WorkplaceAddressKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <WorkplaceAddressKeyDto>;
internal partial class PartialUpdateWorkplaceAddressesForWorkplaceCommandHandler: PartialUpdateWorkplaceAddressesForWorkplaceCommandHandlerBase
{
	public PartialUpdateWorkplaceAddressesForWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateWorkplaceAddressesForWorkplaceCommandHandlerBase: CommandBase<PartialUpdateWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler <PartialUpdateWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> EntityFactory;
	
	protected PartialUpdateWorkplaceAddressesForWorkplaceCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<WorkplaceAddressEntity, WorkplaceAddressUpsertDto, WorkplaceAddressUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<WorkplaceAddressKeyDto> Handle(PartialUpdateWorkplaceAddressesForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Workplace>(keys.ToArray(),e => e.WorkplaceAddresses, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Workplace",  "keyId");
		}
		var ownedId = Dto.WorkplaceAddressMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.WorkplaceAddresses.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Workplace.WorkplaceAddresses", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new WorkplaceAddressKeyDto(entity.Id.Value);
	}
}