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

public partial record DeleteAllWorkplaceAddressesForWorkplaceCommand(WorkplaceKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllWorkplaceAddressesForWorkplaceCommandHandler : DeleteAllWorkplaceAddressesForWorkplaceCommandHandlerBase
{
	public DeleteAllWorkplaceAddressesForWorkplaceCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllWorkplaceAddressesForWorkplaceCommandHandlerBase : CommandCollectionBase<DeleteAllWorkplaceAddressesForWorkplaceCommand, WorkplaceAddressEntity>, IRequestHandler <DeleteAllWorkplaceAddressesForWorkplaceCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllWorkplaceAddressesForWorkplaceCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllWorkplaceAddressesForWorkplaceCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.WorkplaceMetadata.CreateId(request.ParentKeyDto.keyId));
		
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Workplace>(keys.ToArray(), p => p.WorkplaceAddresses, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Workplace", "parentKeyId");
		
		if(parentEntity.WorkplaceAddresses is not null)
		{
			Repository.DeleteOwned(parentEntity.WorkplaceAddresses!);
			await OnCompletedAsync(request, parentEntity.WorkplaceAddresses!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}