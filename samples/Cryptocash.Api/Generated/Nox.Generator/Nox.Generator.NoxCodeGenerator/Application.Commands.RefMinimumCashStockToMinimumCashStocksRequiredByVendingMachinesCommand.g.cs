
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

public abstract record RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand>
{
	public CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler: RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand>
{
	public DeleteRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase<TRequest>: CommandBase<TRequest, MinimumCashStock>, 
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<MinimumCashStock, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
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
                entity.CreateRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}