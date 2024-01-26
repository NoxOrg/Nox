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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefMinimumCashStockToCurrencyCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStockRelatedCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefMinimumCashStockToCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetMinimumCashStockRelatedCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefMinimumCashStockToCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetMinimumCashStock(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("MinimumCashStock",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCurrency();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefMinimumCashStockToCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, MinimumCashStockEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefMinimumCashStockToCurrencyCommand
{
	public IRepository Repository { get; }

	public RefMinimumCashStockToCurrencyCommandHandlerBase(
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

	protected async Task<MinimumCashStockEntity?> GetMinimumCashStock(MinimumCashStockKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.MinimumCashStockMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<MinimumCashStock>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Currency?> GetMinimumCashStockRelatedCurrency(CurrencyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Currency>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, MinimumCashStockEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}