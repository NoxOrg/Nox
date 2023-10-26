﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record UpdateMinimumCashStockCommand(System.Int64 keyId, MinimumCashStockUpdateDto EntityDto, System.Guid? Etag) : IRequest<MinimumCashStockKeyDto?>;

internal partial class UpdateMinimumCashStockCommandHandler : UpdateMinimumCashStockCommandHandlerBase
{
	public UpdateMinimumCashStockCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateMinimumCashStockCommandHandlerBase : CommandBase<UpdateMinimumCashStockCommand, MinimumCashStockEntity>, IRequestHandler<UpdateMinimumCashStockCommand, MinimumCashStockKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _entityFactory;

	public UpdateMinimumCashStockCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto?> Handle(UpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocksRequiredByVendingMachines).LoadAsync();
		var minimumCashStocksRequiredByVendingMachinesEntities = new List<VendingMachine>();
		foreach(var relatedEntityId in request.EntityDto.MinimumCashStocksRequiredByVendingMachinesId)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				minimumCashStocksRequiredByVendingMachinesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("MinimumCashStocksRequiredByVendingMachines", relatedEntityId.ToString());
		}
		entity.UpdateAllRefToMinimumCashStocksRequiredByVendingMachines(minimumCashStocksRequiredByVendingMachinesEntities);

		var minimumCashStockRelatedCurrencyKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.MinimumCashStockRelatedCurrencyId);
		var minimumCashStockRelatedCurrencyEntity = await DbContext.Currencies.FindAsync(minimumCashStockRelatedCurrencyKey);
						
		if(minimumCashStockRelatedCurrencyEntity is not null)
			entity.CreateRefToMinimumCashStockRelatedCurrency(minimumCashStockRelatedCurrencyEntity);
		else
			throw new RelatedEntityNotFoundException("MinimumCashStockRelatedCurrency", request.EntityDto.MinimumCashStockRelatedCurrencyId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}