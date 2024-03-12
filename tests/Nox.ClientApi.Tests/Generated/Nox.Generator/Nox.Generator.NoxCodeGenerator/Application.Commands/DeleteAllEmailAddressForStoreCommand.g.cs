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
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;

public partial record DeleteAllEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteAllEmailAddressForStoreCommandHandler : DeleteAllEmailAddressForStoreCommandHandlerBase
{
	public DeleteAllEmailAddressForStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteAllEmailAddressForStoreCommandHandlerBase : CommandBase<DeleteAllEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <DeleteAllEmailAddressForStoreCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteAllEmailAddressForStoreCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteAllEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId));
		
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Store>(keys.ToArray(), p => p.EmailAddress, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "Store", "parentKeyId");
		
		if(parentEntity.EmailAddress is not null)
		{
			Repository.DeleteOwned(parentEntity.EmailAddress!);
			await OnCompletedAsync(request, parentEntity.EmailAddress!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}