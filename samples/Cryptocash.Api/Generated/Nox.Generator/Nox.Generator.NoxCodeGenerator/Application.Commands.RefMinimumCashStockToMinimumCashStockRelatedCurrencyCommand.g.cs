
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

public abstract record RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<TRequest>: CommandBase<TRequest, MinimumCashStock>, 
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase(
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

		Currency? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Currency, Nox.Types.CurrencyCode3>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToMinimumCashStockRelatedCurrency(relatedEntity);
                break;
            case RelationshipAction.DeleteAll:
                entity.DeleteAllRefToMinimumCashStockRelatedCurrency();
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}