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
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto, System.Guid? Etag) : IRequest<CurrencyKeyDto?>;

internal partial class UpdateCurrencyCommandHandler : UpdateCurrencyCommandHandlerBase
{
	public UpdateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCurrencyCommandHandlerBase : CommandBase<UpdateCurrencyCommand, CurrencyEntity>, IRequestHandler<UpdateCurrencyCommand, CurrencyKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> _entityFactory;

	public UpdateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.CurrencyUsedByCountry).LoadAsync();
		var currencyUsedByCountryEntities = new List<Country>();
		foreach(var relatedEntityId in request.EntityDto.CurrencyUsedByCountryId)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				currencyUsedByCountryEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CurrencyUsedByCountry", relatedEntityId.ToString());
		}
		entity.UpdateAllRefToCurrencyUsedByCountry(currencyUsedByCountryEntities);

		await DbContext.Entry(entity).Collection(x => x.CurrencyUsedByMinimumCashStocks).LoadAsync();
		var currencyUsedByMinimumCashStocksEntities = new List<MinimumCashStock>();
		foreach(var relatedEntityId in request.EntityDto.CurrencyUsedByMinimumCashStocksId)
		{
			var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				currencyUsedByMinimumCashStocksEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CurrencyUsedByMinimumCashStocks", relatedEntityId.ToString());
		}
		entity.UpdateAllRefToCurrencyUsedByMinimumCashStocks(currencyUsedByMinimumCashStocksEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CurrencyKeyDto(entity.Id.Value);
	}
}