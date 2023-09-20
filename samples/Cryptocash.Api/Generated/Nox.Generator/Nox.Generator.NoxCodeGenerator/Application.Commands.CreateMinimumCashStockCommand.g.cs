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
using MinimumCashStock = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto) : IRequest<MinimumCashStockKeyDto>;

public partial class CreateMinimumCashStockCommandHandler: CreateMinimumCashStockCommandHandlerBase
{
	public CreateMinimumCashStockCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> vendingmachinefactory,
        IEntityFactory<Currency,CurrencyCreateDto> currencyfactory,
        IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,vendingmachinefactory,currencyfactory,entityFactory, serviceProvider)
	{
	}
}


public abstract class CreateMinimumCashStockCommandHandlerBase: CommandBase<CreateMinimumCashStockCommand,MinimumCashStock>, IRequestHandler <CreateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto> _entityFactory;
    private readonly IEntityFactory<VendingMachine,VendingMachineCreateDto> _vendingmachinefactory;
    private readonly IEntityFactory<Currency,CurrencyCreateDto> _currencyfactory;

	public CreateMinimumCashStockCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> vendingmachinefactory,
        IEntityFactory<Currency,CurrencyCreateDto> currencyfactory,
        IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
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
		if(request.EntityDto.MinimumCashStockRelatedCurrency is not null)
		{ 
			var relatedEntity = _currencyfactory.CreateEntity(request.EntityDto.MinimumCashStockRelatedCurrency);
			entityToCreate.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.MinimumCashStocks.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}