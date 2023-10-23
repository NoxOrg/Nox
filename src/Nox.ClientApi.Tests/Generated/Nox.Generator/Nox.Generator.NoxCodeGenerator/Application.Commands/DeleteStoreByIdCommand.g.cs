﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record DeleteStoreByIdCommand(System.Guid keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreByIdCommandHandler : DeleteStoreByIdCommandHandlerBase
{
	public DeleteStoreByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreByIdCommandHandlerBase : CommandBase<DeleteStoreByIdCommand, StoreEntity>, IRequestHandler<DeleteStoreByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}