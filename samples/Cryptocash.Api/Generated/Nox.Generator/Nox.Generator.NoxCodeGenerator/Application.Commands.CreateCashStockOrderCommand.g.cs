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
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto) : IRequest<CashStockOrderKeyDto>;

internal partial class CreateCashStockOrderCommandHandler: CreateCashStockOrderCommandHandlerBase
{
	public CreateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> employeefactory,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,vendingmachinefactory, employeefactory, entityFactory)
	{
	}
}


internal abstract class CreateCashStockOrderCommandHandlerBase: CommandBase<CreateCashStockOrderCommand,CashStockOrder>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _entityFactory;
	private readonly IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
	private readonly IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> _employeefactory;

	public CreateCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> employeefactory,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory): base(noxSolution)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_vendingmachinefactory = vendingmachinefactory;
		_employeefactory = employeefactory;
	}

	public virtual async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CashStockOrderForVendingMachineId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<VendingMachine, Nox.Types.Guid>("Id", request.EntityDto.CashStockOrderForVendingMachineId);
			var relatedEntity = await _dbContext.VendingMachines.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
		}
		else if(request.EntityDto.CashStockOrderForVendingMachine is not null)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(request.EntityDto.CashStockOrderForVendingMachine);
			entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
		}
		if(request.EntityDto.CashStockOrderReviewedByEmployeeId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<Employee, Nox.Types.AutoNumber>("Id", request.EntityDto.CashStockOrderReviewedByEmployeeId);
			var relatedEntity = await _dbContext.Employees.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
		}
		else if(request.EntityDto.CashStockOrderReviewedByEmployee is not null)
		{
			var relatedEntity = _employeefactory.CreateEntity(request.EntityDto.CashStockOrderReviewedByEmployee);
			entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.CashStockOrders.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}