// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public record DeleteTransactionByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteTransactionByIdCommandHandler : DeleteTransactionByIdCommandHandlerBase
{
	public DeleteTransactionByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteTransactionByIdCommandHandlerBase : CommandBase<DeleteTransactionByIdCommand, TransactionEntity>, IRequestHandler<DeleteTransactionByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteTransactionByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteTransactionByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.keyId);

		var entity = await DbContext.Transactions.FindAsync(keyId);
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