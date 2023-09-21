
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

public abstract record RefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderForVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler: RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<CreateRefCashStockOrderToCashStockOrderForVendingMachineCommand>
{
	public CreateRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommand(CashStockOrderKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderForVendingMachineCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler: RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommand>
{
	public DeleteRefCashStockOrderToCashStockOrderForVendingMachineCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase<TRequest>: CommandBase<TRequest, CashStockOrder>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToCashStockOrderForVendingMachineCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCashStockOrderToCashStockOrderForVendingMachineCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<CashStockOrder, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCashStockOrderForVendingMachine(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}