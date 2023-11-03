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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<CashStockOrderKeyDto>;

internal partial class CreateCashStockOrderCommandHandler : CreateCashStockOrderCommandHandlerBase
{
	public CreateCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,VendingMachineFactory, EmployeeFactory, entityFactory)
	{
	}
}


internal abstract class CreateCashStockOrderCommandHandlerBase : CommandBase<CreateCashStockOrderCommand,CashStockOrderEntity>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory;

	public CreateCashStockOrderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> VendingMachineFactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> EmployeeFactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.EmployeeFactory = EmployeeFactory;
	}

	public virtual async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.VendingMachineId is not null)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.VendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("VendingMachine", request.EntityDto.VendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.VendingMachine is not null)
		{
			var relatedEntity = VendingMachineFactory.CreateEntity(request.EntityDto.VendingMachine);
			entityToCreate.CreateRefToVendingMachine(relatedEntity);
		}
		if(request.EntityDto.EmployeeId is not null)
		{
			var relatedKey = Cryptocash.Domain.EmployeeMetadata.CreateId(request.EntityDto.EmployeeId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Employees.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToEmployee(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("Employee", request.EntityDto.EmployeeId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.Employee is not null)
		{
			var relatedEntity = EmployeeFactory.CreateEntity(request.EntityDto.Employee);
			entityToCreate.CreateRefToEmployee(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CashStockOrders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}