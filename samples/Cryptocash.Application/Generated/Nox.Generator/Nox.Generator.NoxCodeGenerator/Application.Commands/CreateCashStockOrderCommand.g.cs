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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CashStockOrderKeyDto>;

internal partial class CreateCashStockOrderCommandHandler : CreateCashStockOrderCommandHandlerBase
{
	public CreateCashStockOrderCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(repository, noxSolution,VendingMachineFactory, EmployeeFactory, entityFactory)
	{
	}
}


internal abstract class CreateCashStockOrderCommandHandlerBase : CommandBase<CreateCashStockOrderCommand,CashStockOrderEntity>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory;

	protected CreateCashStockOrderCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
	: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.EmployeeFactory = EmployeeFactory;
	}

	public virtual async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto, request.CultureCode);
		if(request.EntityDto.VendingMachineId is not null)
		{
			var relatedKey = Dto.VendingMachineMetadata.CreateId(request.EntityDto.VendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.VendingMachine>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachine", request.EntityDto.VendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.VendingMachine is not null)
		{
			var relatedEntity = await VendingMachineFactory.CreateEntityAsync(request.EntityDto.VendingMachine, request.CultureCode);
			entityToCreate.CreateRefToVendingMachine(relatedEntity);
		}
		if(request.EntityDto.EmployeeId is not null)
		{
			var relatedKey = Dto.EmployeeMetadata.CreateId(request.EntityDto.EmployeeId.NonNullValue<System.Guid>());
			var relatedEntity = await Repository.FindAsync<Cryptocash.Domain.Employee>(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToEmployee(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Employee", request.EntityDto.EmployeeId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.Employee is not null)
		{
			var relatedEntity = await EmployeeFactory.CreateEntityAsync(request.EntityDto.Employee, request.CultureCode);
			entityToCreate.CreateRefToEmployee(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		await Repository.AddAsync<Cryptocash.Domain.CashStockOrder>(entityToCreate);
		await Repository.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}