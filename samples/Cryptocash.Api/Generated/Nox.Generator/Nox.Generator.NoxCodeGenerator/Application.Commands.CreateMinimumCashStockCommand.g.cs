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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto) : IRequest<MinimumCashStockKeyDto>;

internal partial class CreateMinimumCashStockCommandHandler : CreateMinimumCashStockCommandHandlerBase
{
	public CreateMinimumCashStockCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(dbContext, noxSolution,vendingmachinefactory, currencyfactory, entityFactory)
	{
	}
}


internal abstract class CreateMinimumCashStockCommandHandlerBase : CommandBase<CreateMinimumCashStockCommand,MinimumCashStockEntity>, IRequestHandler <CreateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
	private readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> _currencyfactory;

	public CreateMinimumCashStockCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> currencyfactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory) : base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_vendingmachinefactory = vendingmachinefactory;
		_currencyfactory = currencyfactory;
	}

	public virtual async Task<MinimumCashStockKeyDto> Handle(CreateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.MinimumCashStocksRequiredByVendingMachines)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
		}
		if(request.EntityDto.MinimumCashStockRelatedCurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.MinimumCashStockRelatedCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await _dbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("MinimumCashStockRelatedCurrency", request.EntityDto.MinimumCashStockRelatedCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.MinimumCashStockRelatedCurrency is not null)
		{
			var relatedEntity = _currencyfactory.CreateEntity(request.EntityDto.MinimumCashStockRelatedCurrency);
			entityToCreate.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.MinimumCashStocks.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}