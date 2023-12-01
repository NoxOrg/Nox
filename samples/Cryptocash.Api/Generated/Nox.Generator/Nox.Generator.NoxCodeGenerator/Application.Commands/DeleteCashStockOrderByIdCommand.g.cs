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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record DeleteCashStockOrderByIdCommand(IEnumerable<CashStockOrderKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

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
		await OnExecutingAsync(request);
		
		foreach(var keyDto in request.KeyDtos)
		{
			var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.CashStockOrders.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				return false;
			}

			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			DbContext.Entry(entity).State = EntityState.Deleted;
		}

		await OnCompletedAsync(request, new CashStockOrderEntity());

		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}