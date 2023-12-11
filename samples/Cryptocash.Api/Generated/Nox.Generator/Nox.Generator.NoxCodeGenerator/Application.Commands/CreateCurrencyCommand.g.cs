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
using FluentValidation;
using Microsoft.Extensions.Logging;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public partial record CreateCurrencyCommand(CurrencyCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CurrencyKeyDto>;

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

	protected CreateCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.Country, CountryCreateDto, CountryUpdateDto> CountryFactory,
		IEntityFactory<Cryptocash.Domain.MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> MinimumCashStockFactory,
		IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto> entityFactory)
		: base(noxSolution)
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

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.CountriesId.Any())
		{
			foreach(var relatedId in request.EntityDto.CountriesId)
			{
				var relatedKey = Cryptocash.Domain.CountryMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.Countries.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToCountries(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("Countries", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.Countries)
			{
				var relatedEntity = await CountryFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToCountries(relatedEntity);
			}
		}
		if(request.EntityDto.MinimumCashStocksId.Any())
		{
			foreach(var relatedId in request.EntityDto.MinimumCashStocksId)
			{
				var relatedKey = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.MinimumCashStocks.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToMinimumCashStocks(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("MinimumCashStocks", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.MinimumCashStocks)
			{
				var relatedEntity = await MinimumCashStockFactory.CreateEntityAsync(relatedCreateDto);
				entityToCreate.CreateRefToMinimumCashStocks(relatedEntity);
			}
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Currencies.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyCommand>
{
    public CreateCurrencyValidator()
    {
		RuleFor(x => x.EntityDto.BankNotes)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("BankNotes.Id must be null as it is auto generated.");
		RuleFor(x => x.EntityDto.ExchangeRates)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("ExchangeRates.Id must be null as it is auto generated.");
    }
}