// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using StoreDescription = ClientApi.Domain.StoreDescription;

namespace ClientApi.Application.Commands;

public record DeleteStoreDescriptionByIdCommand(System.Guid keyStoreId, System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

public class DeleteStoreDescriptionByIdCommandHandler:DeleteStoreDescriptionByIdCommandHandlerBase
{
	public DeleteStoreDescriptionByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(dbContext, noxSolution, serviceProvider)
	{
	}
}
public abstract class DeleteStoreDescriptionByIdCommandHandlerBase: CommandBase<DeleteStoreDescriptionByIdCommand,StoreDescription>, IRequestHandler<DeleteStoreDescriptionByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreDescriptionByIdCommandHandlerBase(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteStoreDescriptionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyStoreId = CreateNoxTypeForKey<StoreDescription,Nox.Types.Guid>("StoreId", request.keyStoreId);
		var keyId = CreateNoxTypeForKey<StoreDescription,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.StoreDescriptions.FindAsync(keyStoreId, keyId);
		if (entity == null)
		{
			return false;
		}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);DbContext.StoreDescriptions.Remove(entity);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}