﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
using EmailAddressEntity = ClientApi.Domain.EmailAddress;

namespace ClientApi.Application.Commands;
public partial record DeleteEmailAddressForStoreCommand(StoreKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteEmailAddressForStoreCommandHandler : DeleteEmailAddressForStoreCommandHandlerBase
{
	public DeleteEmailAddressForStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteEmailAddressForStoreCommandHandlerBase : CommandBase<DeleteEmailAddressForStoreCommand, EmailAddressEntity>, IRequestHandler <DeleteEmailAddressForStoreCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteEmailAddressForStoreCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteEmailAddressForStoreCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Stores.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var entity = parentEntity.VerifiedEmails;
		if (entity == null)
		{
			return false;
		}

		parentEntity.DeleteRefToVerifiedEmails(entity);

		await OnCompletedAsync(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}