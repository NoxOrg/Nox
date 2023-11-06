
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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public abstract record RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef MinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public CreateRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public DeleteRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler
	: RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand>
{
	public DeleteAllRefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefMinimumCashStockToMinimumCashStockRelatedCurrencyCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Currency? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}