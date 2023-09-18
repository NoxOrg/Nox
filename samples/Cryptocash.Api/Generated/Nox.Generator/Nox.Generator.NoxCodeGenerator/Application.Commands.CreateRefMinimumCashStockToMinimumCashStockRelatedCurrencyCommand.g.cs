
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
public record CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public partial class CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler: CommandBase<CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand, MinimumCashStock>, 
	IRequestHandler <CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand, bool>
{
	public CryptocashDbContext DbContext { get; }

	public CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand request, CancellationToken cancellationToken)
	{
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<MinimumCashStock, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Currency, Nox.Types.CurrencyCode3>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCurrencyMinimumCashStockRelatedCurrency(relatedEntity);

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}