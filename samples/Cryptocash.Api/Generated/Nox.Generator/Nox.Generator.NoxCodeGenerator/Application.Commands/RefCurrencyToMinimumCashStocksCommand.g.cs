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
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
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
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStock(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToMinimumCashStocks(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToMinimumCashStocksCommand(CurrencyKeyDto EntityKeyDto, List<MinimumCashStockKeyDto> RelatedEntitiesKeysDtos)
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
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetMinimumCashStock(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("MinimumCashStock", $"{keyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStock(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
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
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
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
		var keyId = Dto.CurrencyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.MinimumCashStock?> GetMinimumCashStock(MinimumCashStockKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.MinimumCashStockMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.MinimumCashStocks.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}