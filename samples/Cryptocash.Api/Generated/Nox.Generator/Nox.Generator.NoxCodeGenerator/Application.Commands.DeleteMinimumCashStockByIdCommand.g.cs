// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record DeleteMinimumCashStockByIdCommand(System.Int64 keyId, System.Guid? Etag) : IRequest<bool>;

internal class DeleteMinimumCashStockByIdCommandHandler : DeleteMinimumCashStockByIdCommandHandlerBase
{
	public DeleteMinimumCashStockByIdCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteMinimumCashStockByIdCommandHandlerBase : CommandBase<DeleteMinimumCashStockByIdCommand, MinimumCashStockEntity>, IRequestHandler<DeleteMinimumCashStockByIdCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public DeleteMinimumCashStockByIdCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteMinimumCashStockByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
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