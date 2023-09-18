
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

public record CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler: CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase
{
	public CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider)
	{ }
}

public abstract class CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase: CommandBase<CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand, Currency>, 
	IRequestHandler <CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency, Nox.Types.CurrencyCode3>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<MinimumCashStock, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToMinimumCashStockCurrencyUsedByMinimumCashStocks(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}