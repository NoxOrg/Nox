// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCurrencyToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrencyUsedByMinimumCashStocks(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToMinimumCashStocks(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCurrencyToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.MinimumCashStock>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCurrencyUsedByMinimumCashStocks(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("MinimumCashStock", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToMinimumCashStocks(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCurrencyToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrencyUsedByMinimumCashStocks(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("MinimumCashStock", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToMinimumCashStocks(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCurrencyToMinimumCashStocksCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToMinimumCashStocks();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToMinimumCashStocksCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToMinimumCashStocksCommand
{
	public IRepository Repository { get; }

	public RefCurrencyToMinimumCashStocksCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(), x => x.MinimumCashStocks, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.MinimumCashStock?> GetCurrencyUsedByMinimumCashStocks(MinimumCashStockKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.MinimumCashStockMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<MinimumCashStock>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}