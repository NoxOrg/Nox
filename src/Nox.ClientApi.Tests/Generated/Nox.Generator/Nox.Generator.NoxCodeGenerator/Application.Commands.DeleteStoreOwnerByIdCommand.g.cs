// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public record DeleteStoreOwnerByIdCommand(System.String keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteStoreOwnerByIdCommandHandler : DeleteStoreOwnerByIdCommandHandlerBase
{
	public DeleteStoreOwnerByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteStoreOwnerByIdCommandHandlerBase : CommandBase<DeleteStoreOwnerByIdCommand, StoreOwnerEntity>, IRequestHandler<DeleteStoreOwnerByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreOwnerByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreOwnerByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = ClientApi.Domain.StoreOwnerMetadata.CreateId(request.keyId);

		var entity = await DbContext.StoreOwners.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
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