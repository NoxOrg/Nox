
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

namespace Cryptocash.Application.Commands;

public abstract record RefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandlerBase<CreateRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand>
{
	public CreateRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandlerBase<DeleteRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand>
{
	public DeleteRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(VendingMachineKeyDto EntityKeyDto)
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(EntityKeyDto, null);

internal partial class DeleteAllRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler
	: RefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandlerBase<DeleteAllRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand>
{
	public DeleteAllRefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandlerBase<TRequest> : CommandBase<TRequest, VendingMachine>,
	IRequestHandler <TRequest, bool> where TRequest : RefVendingMachineToVendingMachineRelatedCashStockOrdersCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefVendingMachineToVendingMachineRelatedCashStockOrdersCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.VendingMachines.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		CashStockOrder? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<CashStockOrder, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToVendingMachineRelatedCashStockOrders(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToVendingMachineRelatedCashStockOrders(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.VendingMachineRelatedCashStockOrders).LoadAsync();
				entity.DeleteAllRefToVendingMachineRelatedCashStockOrders();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}