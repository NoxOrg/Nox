﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<CurrencyKeyDto>;

internal partial class CreateCurrencyCommandHandler : CreateCurrencyCommandHandlerBase
{
	public CreateCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CountryFactory, MinimumCashStockFactory, entityFactory)
	{
	}
}


internal abstract class CreateCurrencyCommandHandlerBase : CommandBase<CreateCurrencyCommand,CurrencyEntity>, IRequestHandler <CreateCurrencyCommand, CurrencyKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory;

	public CreateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CountryFactory = CountryFactory;
		this.MinimumCashStockFactory = MinimumCashStockFactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CurrencyUsedByCountryId.Any())
		{
			foreach(var relatedId in request.EntityDto.CurrencyUsedByCountryId)
			{
				var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCurrencyUsedByCountry(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("CurrencyUsedByCountry", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.CurrencyUsedByCountry)
			{
				var relatedEntity = CountryFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToCurrencyUsedByCountry(relatedEntity);
			}
		}
		if(request.EntityDto.CurrencyUsedByMinimumCashStocksId.Any())
		{
			foreach(var relatedId in request.EntityDto.CurrencyUsedByMinimumCashStocksId)
			{
				var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCurrencyUsedByMinimumCashStocks(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("CurrencyUsedByMinimumCashStocks", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.CurrencyUsedByMinimumCashStocks)
			{
				var relatedEntity = MinimumCashStockFactory.CreateEntity(relatedCreateDto);
				entityToCreate.CreateRefToCurrencyUsedByMinimumCashStocks(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Currencies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}