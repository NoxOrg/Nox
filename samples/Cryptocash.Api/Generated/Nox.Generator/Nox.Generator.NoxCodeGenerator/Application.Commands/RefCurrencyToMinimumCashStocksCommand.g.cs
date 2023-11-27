
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

public abstract record RefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto);

internal partial class CreateRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<CreateRefCurrencyToMinimumCashStocksCommand>
{
	public CreateRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCurrencyToMinimumCashStocksCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetMinimumCashStock(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToMinimumCashStocks(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, List<MinimumCashStockKeyDto> RelatedEntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto);

internal partial class UpdateRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<UpdateRefCurrencyToMinimumCashStocksCommand>
{
	public UpdateRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCurrencyToMinimumCashStocksCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var keyDto in request.RelatedEntityKeyDto)
		{
			var relatedEntity = await GetMinimumCashStock(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		entity.UpdateRefToMinimumCashStocks(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, MinimumCashStockKeyDto RelatedEntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto);

internal partial class DeleteRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<DeleteRefCurrencyToMinimumCashStocksCommand>
{
	public DeleteRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCurrencyToMinimumCashStocksCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetMinimumCashStock(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToMinimumCashStocks(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToMinimumCashStocksCommand(EntityKeyDto);

internal partial class DeleteAllRefCurrencyToMinimumCashStocksCommandHandler
	: RefCurrencyToMinimumCashStocksCommandHandlerBase<DeleteAllRefCurrencyToMinimumCashStocksCommand>
{
	public DeleteAllRefCurrencyToMinimumCashStocksCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCurrencyToMinimumCashStocksCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		entity.DeleteAllRefToMinimumCashStocks();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToMinimumCashStocksCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToMinimumCashStocksCommand
{
	public AppDbContext DbContext { get; }

	public RefCurrencyToMinimumCashStocksCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.MinimumCashStock?> GetMinimumCashStock(MinimumCashStockKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}