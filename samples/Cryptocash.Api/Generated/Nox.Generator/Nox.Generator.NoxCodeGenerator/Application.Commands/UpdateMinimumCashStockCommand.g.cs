﻿﻿// Generated

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

public record UpdateMinimumCashStockCommand(System.Int64 keyId, MinimumCashStockUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<MinimumCashStockKeyDto?>;

internal partial class UpdateMinimumCashStockCommandHandler : UpdateMinimumCashStockCommandHandlerBase
{
	public UpdateMinimumCashStockCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto?> Handle(UpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.VendingMachines).LoadAsync();
		var vendingMachinesEntities = new List<Cryptocash.Domain.VendingMachine>();
		foreach(var relatedEntityId in request.EntityDto.VendingMachinesId)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				vendingMachinesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachines", relatedEntityId.ToString());
		}
		entity.UpdateRefToVendingMachines(vendingMachinesEntities);

		var currencyKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId);
		var currencyEntity = await DbContext.Currencies.FindAsync(currencyKey);
						
		if(currencyEntity is not null)
			entity.CreateRefToCurrency(currencyEntity);
		else
			throw new RelatedEntityNotFoundException("Currency", request.EntityDto.CurrencyId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
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