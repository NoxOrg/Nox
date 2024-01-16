// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record DeleteCashStockOrderByIdCommand(IEnumerable<CashStockOrderKeyDto> KeyDtos, System.Guid? Etag) : IRequest<bool>;

internal partial class DeleteCashStockOrderByIdCommandHandler : DeleteCashStockOrderByIdCommandHandlerBase
{
	public DeleteCashStockOrderByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class DeleteCashStockOrderByIdCommandHandlerBase : CommandCollectionBase<DeleteCashStockOrderByIdCommand, CashStockOrderEntity>, IRequestHandler<DeleteCashStockOrderByIdCommand, bool>
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
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<CashStockOrderEntity>(keys.Length);
		foreach(var keyDto in keys)
		{
			var keyId = Dto.CashStockOrderMetadata.CreateId(keyDto.keyId);		

			var entity = await DbContext.CashStockOrders.FindAsync(keyId);
			if (entity == null || entity.IsDeleted == true)
			{
				throw new EntityNotFoundException("CashStockOrder",  $"{keyId.ToString()}");
			}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}