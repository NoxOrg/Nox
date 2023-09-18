
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
public record CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand(MinimumCashStockKeyDto EntityKeyDto, VendingMachineKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler: CommandBase<CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand, MinimumCashStock>, 
	IRequestHandler <CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefMinimumCashStockToMinimumCashStocksRequiredByVendingMachinesCommand request, CancellationToken cancellationToken)
	{
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

		entity.CreateRefToVendingMachineMinimumCashStocksRequiredByVendingMachines(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}