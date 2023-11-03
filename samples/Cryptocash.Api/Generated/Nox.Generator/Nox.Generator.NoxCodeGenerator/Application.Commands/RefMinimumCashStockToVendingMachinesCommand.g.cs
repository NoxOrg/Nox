
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public abstract record RefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<CreateRefMinimumCashStockToVendingMachinesCommand>
{
	public CreateRefMinimumCashStockToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<DeleteRefMinimumCashStockToVendingMachinesCommand>
{
	public DeleteRefMinimumCashStockToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefMinimumCashStockToVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToVendingMachinesCommand(EntityKeyDto, null);

internal partial class DeleteAllRefMinimumCashStockToVendingMachinesCommandHandler
	: RefMinimumCashStockToVendingMachinesCommandHandlerBase<DeleteAllRefMinimumCashStockToVendingMachinesCommand>
{
	public DeleteAllRefMinimumCashStockToVendingMachinesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefMinimumCashStockToVendingMachinesCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToVendingMachinesCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefMinimumCashStockToVendingMachinesCommandHandlerBase(
        AppDbContext dbContext,
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
		await OnExecutingAsync(request);
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
				entity.CreateRefToVendingMachines(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachines(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
				entity.DeleteAllRefToVendingMachines();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}