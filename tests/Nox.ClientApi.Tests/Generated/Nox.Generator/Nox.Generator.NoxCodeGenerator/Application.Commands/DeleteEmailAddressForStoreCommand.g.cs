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
public partial record DeleteEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class DeleteEmailAddressForStoreCommandHandler : DeleteEmailAddressForStoreCommandHandlerBase
{
	public DeleteEmailAddressForStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteEmailAddressForStoreCommandHandlerBase : CommandBase<DeleteEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <DeleteEmailAddressForStoreCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteEmailAddressForStoreCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<ClientApi.Domain.Store>(keys.ToArray(), p => p.EmailAddress, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Store",  "keyId");
		}				
		var entity = parentEntity.EmailAddress;
		if (entity == null)
		{
			throw new EntityNotFoundException("Store.EmailAddress",  String.Empty);
		}

		parentEntity.DeleteEmailAddress(entity);
		
		
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}