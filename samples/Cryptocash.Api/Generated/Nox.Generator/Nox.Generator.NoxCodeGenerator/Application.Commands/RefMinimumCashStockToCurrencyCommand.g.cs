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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public abstract record RefMinimumCashStockToCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefMinimumCashStockToCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToCurrencyCommand(EntityKeyDto);

internal partial class CreateRefMinimumCashStockToCurrencyCommandHandler
	: RefMinimumCashStockToCurrencyCommandHandlerBase<CreateRefMinimumCashStockToCurrencyCommand>
{
	public CreateRefMinimumCashStockToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefMinimumCashStockToCurrencyCommand request)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrency(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefMinimumCashStockToCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefMinimumCashStockToCurrencyCommand(EntityKeyDto);

internal partial class DeleteRefMinimumCashStockToCurrencyCommandHandler
	: RefMinimumCashStockToCurrencyCommandHandlerBase<DeleteRefMinimumCashStockToCurrencyCommand>
{
	public DeleteRefMinimumCashStockToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefMinimumCashStockToCurrencyCommand request)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrency(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCurrency(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefMinimumCashStockToCurrencyCommand(MinimumCashStockKeyDto EntityKeyDto)
	: RefMinimumCashStockToCurrencyCommand(EntityKeyDto);

internal partial class DeleteAllRefMinimumCashStockToCurrencyCommandHandler
	: RefMinimumCashStockToCurrencyCommandHandlerBase<DeleteAllRefMinimumCashStockToCurrencyCommand>
{
	public DeleteAllRefMinimumCashStockToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefMinimumCashStockToCurrencyCommand request)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCurrency();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefMinimumCashStockToCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RefMinimumCashStockToCurrencyCommandHandlerBase(
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

	protected async Task<MinimumCashStockEntity?> GetMinimumCashStock(MinimumCashStockKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.MinimumCashStocks.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Currency?> GetCurrency(CurrencyKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, MinimumCashStockEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}