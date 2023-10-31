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

public record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<MinimumCashStockKeyDto>;

internal partial class CreateMinimumCashStockCommandHandler : CreateMinimumCashStockCommandHandlerBase
{
	public CreateMinimumCashStockCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(dbContext, noxSolution,VendingMachineFactory, CurrencyFactory, entityFactory)
	{
	}
}


internal abstract class CreateMinimumCashStockCommandHandlerBase : CommandBase<CreateMinimumCashStockCommand,MinimumCashStockEntity>, IRequestHandler <CreateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory;

	public CreateMinimumCashStockCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.CurrencyFactory = CurrencyFactory;
	}

	public virtual async Task<MinimumCashStockKeyDto> Handle(CreateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		foreach(var relatedCreateDto in request.EntityDto.MinimumCashStocksRequiredByVendingMachines)
		{
			var relatedEntity = VendingMachineFactory.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefToMinimumCashStocksRequiredByVendingMachines(relatedEntity);
		}
		if(request.EntityDto.MinimumCashStockRelatedCurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.MinimumCashStockRelatedCurrencyId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("MinimumCashStockRelatedCurrency", request.EntityDto.MinimumCashStockRelatedCurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.MinimumCashStockRelatedCurrency is not null)
		{
			var relatedEntity = CurrencyFactory.CreateEntity(request.EntityDto.MinimumCashStockRelatedCurrency);
			entityToCreate.CreateRefToMinimumCashStockRelatedCurrency(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.MinimumCashStocks.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}