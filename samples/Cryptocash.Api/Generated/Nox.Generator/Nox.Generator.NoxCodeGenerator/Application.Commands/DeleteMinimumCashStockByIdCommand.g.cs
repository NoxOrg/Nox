// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record DeleteMinimumCashStockByIdCommand(IEnumerable<MinimumCashStockKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal class DeleteMinimumCashStockByIdCommandHandler : DeleteMinimumCashStockByIdCommandHandlerBase
{
	public DeleteMinimumCashStockByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteMinimumCashStockByIdCommandHandlerBase : CommandBase<DeleteMinimumCashStockByIdCommand, MinimumCashStockEntity>, IRequestHandler<DeleteMinimumCashStockByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteMinimumCashStockByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteMinimumCashStockByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new MinimumCashStockEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}