﻿
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

public abstract record RefCurrencyToCurrencyUsedByMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler: RefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase<CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand>
{
	public CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByMinimumCashStocksCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler: RefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase<DeleteRefCurrencyToCurrencyUsedByMinimumCashStocksCommand>
{
	public DeleteRefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase<TRequest>: CommandBase<TRequest, Currency>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCurrencyUsedByMinimumCashStocksCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCurrencyToCurrencyUsedByMinimumCashStocksCommandHandlerBase(
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
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCurrencyUsedByMinimumCashStocks(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCurrencyUsedByMinimumCashStocks(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}