﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record DeleteStoreOwnerByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteStoreOwnerByIdCommandHandler:DeleteStoreOwnerByIdCommandHandlerBase
{
	public DeleteStoreOwnerByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
public abstract class DeleteStoreOwnerByIdCommandHandlerBase: CommandBase<DeleteStoreOwnerByIdCommand,StoreOwner>, IRequestHandler<DeleteStoreOwnerByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreOwnerByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreOwnerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<StoreOwner,Nox.Types.Text>("Id", request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null || entity.IsDeleted.Value == true)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}