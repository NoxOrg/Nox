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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<MinimumCashStockKeyDto>;

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

	protected CreateMinimumCashStockCommandHandlerBase(
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

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.VendingMachinesId.Any())
		{
			foreach(var relatedId in request.EntityDto.VendingMachinesId)
			{
				var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(relatedId);
				var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);

				if(relatedEntity is not null)
					entityToCreate.CreateRefToVendingMachines(relatedEntity);
				else
					throw new RelatedEntityNotFoundException("VendingMachines", relatedId.ToString());
			}
		}
		else
		{
			foreach(var relatedCreateDto in request.EntityDto.VendingMachines)
			{
				var relatedEntity = await VendingMachineFactory.CreateEntityAsync(relatedCreateDto, request.CultureCode);
				entityToCreate.CreateRefToVendingMachines(relatedEntity);
			}
		}
		if(request.EntityDto.CurrencyId is not null)
		{
			var relatedKey = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId.NonNullValue<System.String>());
			var relatedEntity = await DbContext.Currencies.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCurrency(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Currency", request.EntityDto.CurrencyId.NonNullValue<System.String>().ToString());
		}
		else if(request.EntityDto.Currency is not null)
		{
			var relatedEntity = await CurrencyFactory.CreateEntityAsync(request.EntityDto.Currency, request.CultureCode);
			entityToCreate.CreateRefToCurrency(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.MinimumCashStocks.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}