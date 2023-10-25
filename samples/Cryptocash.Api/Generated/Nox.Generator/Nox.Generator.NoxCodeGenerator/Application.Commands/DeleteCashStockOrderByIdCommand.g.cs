// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record DeleteCashStockOrderByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteCashStockOrderByIdCommandHandler : DeleteCashStockOrderByIdCommandHandlerBase
{
	public DeleteCashStockOrderByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCashStockOrderByIdCommandHandlerBase : CommandBase<DeleteCashStockOrderByIdCommand, CashStockOrderEntity>, IRequestHandler<DeleteCashStockOrderByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteCashStockOrderByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteCashStockOrderByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.keyId);

		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
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