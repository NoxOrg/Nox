﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public record CreateCurrencyCommand(CurrencyCreateDto EntityDto) : IRequest<CurrencyKeyDto>;

internal partial class CreateCurrencyCommandHandler: CreateCurrencyCommandHandlerBase
{
	public CreateCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
        IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
        IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,countryfactory, minimumcashstockfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateCurrencyCommandHandlerBase: CommandBase<CreateCurrencyCommand,Currency>, IRequestHandler <CreateCurrencyCommand, CurrencyKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> _entityFactory;
    private readonly IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> _countryfactory;
    private readonly IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _minimumcashstockfactory;

	public CreateCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<Country, CountryCreateDto, CountryUpdateDto> countryfactory,
        IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> minimumcashstockfactory,
        IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
        _countryfactory = countryfactory;
        _minimumcashstockfactory = minimumcashstockfactory;
	}

	public virtual async Task<CurrencyKeyDto> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.CurrencyUsedByCountry)
		{
			var relatedEntity = _countryfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCurrencyUsedByCountry(relatedEntity);
		}
		foreach(var relatedCreateDto in request.EntityDto.CurrencyUsedByMinimumCashStocks)
		{
			var relatedEntity = _minimumcashstockfactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToCurrencyUsedByMinimumCashStocks(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Currencies.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CurrencyKeyDto(entityToCreate.Id.Value);
	}
}