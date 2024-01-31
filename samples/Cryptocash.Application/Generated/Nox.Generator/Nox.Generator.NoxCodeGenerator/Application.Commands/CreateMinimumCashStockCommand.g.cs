﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Logging;

using Nox.Abstractions;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record CreateMinimumCashStockCommand(MinimumCashStockCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<MinimumCashStockKeyDto>;

internal partial class CreateMinimumCashStockCommandHandler : CreateMinimumCashStockCommandHandlerBase
{
	public CreateMinimumCashStockCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
		: base(repository, noxSolution,VendingMachineFactory, CurrencyFactory, entityFactory)
	{
	}
}


internal abstract class CreateMinimumCashStockCommandHandlerBase : CommandBase<CreateMinimumCashStockCommand,MinimumCashStockEntity>, IRequestHandler <CreateMinimumCashStockCommand, MinimumCashStockKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory;

	protected CreateMinimumCashStockCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Currency, CurrencyCreateDto, CurrencyUpdateDto> CurrencyFactory,
		IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
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
				var relatedKey = Dto.VendingMachineMetadata.CreateId(relatedId);
				var relatedEntity = await Repository.FindAsync<VendingMachine>(relatedKey);

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
			var relatedKey = Dto.CurrencyMetadata.CreateId(request.EntityDto.CurrencyId.NonNullValue<System.String>());
			var relatedEntity = await Repository.FindAsync<Currency>(relatedKey);
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
		await Repository.AddAsync<MinimumCashStock>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entityToCreate.Id.Value);
	}
}