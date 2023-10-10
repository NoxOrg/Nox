
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public abstract record RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand>
{
	public CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand>
{
	public DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<DeleteAllRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand>
{
	public DeleteAllRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.VendingMachine? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.MinimumCashStocksRequiredByVendingMachines).LoadAsync();
				entity.DeleteAllRefToMinimumCashStocksRequiredByVendingMachines();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}