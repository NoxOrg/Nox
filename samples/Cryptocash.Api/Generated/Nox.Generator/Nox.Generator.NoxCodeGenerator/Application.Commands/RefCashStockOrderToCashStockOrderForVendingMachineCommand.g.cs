
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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public abstract record RefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderForVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler
	: RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<CreateRefCashStockOrderToCashStockOrderForVendingMachineCommand>
{
	public CreateRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderForVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler
	: RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommand>
{
	public DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto)
	: RefCashStockOrderToCashStockOrderForVendingMachineCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler
	: RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<DeleteAllRefCashStockOrderToCashStockOrderForVendingMachineCommand>
{
	public DeleteAllRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToCashStockOrderForVendingMachineCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
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
				entity.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCashStockOrderForVendingMachine(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCashStockOrderForVendingMachine();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}