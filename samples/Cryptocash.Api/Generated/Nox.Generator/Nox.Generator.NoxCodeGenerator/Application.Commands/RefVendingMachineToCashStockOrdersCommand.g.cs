
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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<CreateRefVendingMachineToCashStockOrdersCommand>
{
	public CreateRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<DeleteRefVendingMachineToCashStockOrdersCommand>
{
	public DeleteRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToCashStockOrdersCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToCashStockOrdersCommandHandler
	: RefVendingMachineToCashStockOrdersCommandHandlerBase<DeleteAllRefVendingMachineToCashStockOrdersCommand>
{
	public DeleteAllRefVendingMachineToCashStockOrdersCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToCashStockOrdersCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachineEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToCashStockOrdersCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToCashStockOrdersCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.CashStockOrder? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCashStockOrders(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCashStockOrders(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CashStockOrders).LoadAsync();
				entity.DeleteAllRefToCashStockOrders();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}