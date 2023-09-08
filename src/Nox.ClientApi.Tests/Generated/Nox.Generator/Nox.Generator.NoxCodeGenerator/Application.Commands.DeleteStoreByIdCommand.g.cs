// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public record DeleteStoreByIdCommand(System.UInt32 keyId) : IRequest<bool>;

public class DeleteStoreByIdCommandHandler: CommandBase<DeleteStoreByIdCommand,Store>, IRequestHandler<DeleteStoreByIdCommand, bool>
{
	public ClientApiDbContext DbContext { get; }

	public DeleteStoreByIdCommandHandler(
		ClientApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(DeleteStoreByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Store,Nuid>("Id", request.keyId);

		var entity = await DbContext.Stores.FindAsync(keyId);
		if (entity == null || entity.IsDeleted == true)
		{
			return false;
		}

		OnCompleted(entity);
		DbContext.Entry(entity).State = EntityState.Deleted;
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}