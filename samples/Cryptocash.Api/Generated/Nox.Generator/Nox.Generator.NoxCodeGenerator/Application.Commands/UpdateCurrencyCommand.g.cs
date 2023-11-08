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

public record UpdateCurrencyCommand(System.String keyId, CurrencyUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<CurrencyKeyDto?>;

internal partial class UpdateCurrencyCommandHandler : UpdateCurrencyCommandHandlerBase
{
	public UpdateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
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
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CurrencyKeyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.keyId);

		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		await DbContext.Entry(entity).Collection(x => x.Countries).LoadAsync();
		var countriesEntities = new List<Country>();
		foreach(var relatedEntityId in request.EntityDto.CountriesId)
		{
			var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				countriesEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Countries", relatedEntityId.ToString());
		}
		entity.UpdateRefToCountries(countriesEntities);

		await DbContext.Entry(entity).Collection(x => x.MinimumCashStocks).LoadAsync();
		var minimumCashStocksEntities = new List<MinimumCashStock>();
		foreach(var relatedEntityId in request.EntityDto.MinimumCashStocksId)
		{
			var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedEntityId);
			var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);
						
			if(relatedEntity is not null)
				minimumCashStocksEntities.Add(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("MinimumCashStocks", relatedEntityId.ToString());
		}
		entity.UpdateRefToMinimumCashStocks(minimumCashStocksEntities);

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
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