
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
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public abstract record RefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<CreateRefCurrencyToMinimumCashStocksCommand>
{
	public CreateRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<DeleteRefCurrencyToMinimumCashStocksCommand>
{
	public DeleteRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<DeleteAllRefCurrencyToMinimumCashStocksCommand>
{
	public DeleteAllRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCurrencyToMinimumCashStocksCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToMinimumCashStocksCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCurrencyToMinimumCashStocksCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.MinimumCashStock? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToMinimumCashStocks(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToMinimumCashStocks(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
				entity.DeleteAllRefToMinimumCashStocks();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}