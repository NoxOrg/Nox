﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using WorkplaceAddressEntity = ClientApi.Domain.WorkplaceAddress;

namespace ClientApi.Application.Commands;
public partial record DeleteWorkplaceAddressesForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, WorkplaceAddressKeyDto EntityKeyDto, System.Guid? Etag) : IRequest <bool>;

internal partial class DeleteWorkplaceAddressesForWorkplaceCommandHandler : DeleteWorkplaceAddressesForWorkplaceCommandHandlerBase
{
	public DeleteWorkplaceAddressesForWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteWorkplaceAddressesForWorkplaceCommandHandlerBase : CommandBase<DeleteWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler <DeleteWorkplaceAddressesForWorkplaceCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteWorkplaceAddressesForWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteWorkplaceAddressesForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Workplace>(keys.ToArray(), p => p.WorkplaceAddresses, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Workplace",  "keyId");
		}
		var ownedId = Dto.WorkplaceAddressMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.WorkplaceAddresses.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("WorkplaceAddress.WorkplaceAddresses",  $"ownedId");
		}
		parentEntity.WorkplaceAddresses.Remove(entity);
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}