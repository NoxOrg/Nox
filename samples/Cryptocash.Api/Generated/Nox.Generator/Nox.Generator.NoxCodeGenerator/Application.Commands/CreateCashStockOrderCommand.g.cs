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
using Nox.Factories;
using Nox.Solution;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto) : IRequest<CashStockOrderKeyDto>;

internal partial class CreateCashStockOrderCommandHandler : CreateCashStockOrderCommandHandlerBase
{
	public CreateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> employeefactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory)
		: base(dbContext, noxSolution,vendingmachinefactory, employeefactory, entityFactory)
	{
	}
}


internal abstract class CreateCashStockOrderCommandHandlerBase : CommandBase<CreateCashStockOrderCommand,CashStockOrderEntity>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> _vendingmachinefactory;
	private readonly IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> _employeefactory;

	public CreateCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.VendingMachine, VendingMachineCreateDto, VendingMachineUpdateDto> vendingmachinefactory,
		IEntityFactory<Cryptocash.Domain.Employee, EmployeeCreateDto, EmployeeUpdateDto> employeefactory,
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory) : base(noxSolution)
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
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.CashStockOrderForVendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await _dbContext.VendingMachines.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrderForVendingMachine", request.EntityDto.CashStockOrderForVendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.CashStockOrderForVendingMachine is not null)
		{
			var relatedEntity = _vendingmachinefactory.CreateEntity(request.EntityDto.CashStockOrderForVendingMachine);
			entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
		}
		if(request.EntityDto.CashStockOrderReviewedByEmployeeId is not null)
		{
			var relatedKey = Cryptocash.Domain.EmployeeMetadata.CreateId(request.EntityDto.CashStockOrderReviewedByEmployeeId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.Employees.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrderReviewedByEmployee", request.EntityDto.CashStockOrderReviewedByEmployeeId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.CashStockOrderReviewedByEmployee is not null)
		{
			var relatedEntity = _employeefactory.CreateEntity(request.EntityDto.CashStockOrderReviewedByEmployee);
			entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.CashStockOrders.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}