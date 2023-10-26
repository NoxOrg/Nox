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

public record CreateCashStockOrderCommand(CashStockOrderCreateDto EntityDto, System.String CultureCode) : IRequest<CashStockOrderKeyDto>;

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
		IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.VendingMachineFactory = VendingMachineFactory;
		this.EmployeeFactory = EmployeeFactory;
	}

	public virtual async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CashStockOrderForVendingMachineId is not null)
		{
			var relatedKey = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.EntityDto.CashStockOrderForVendingMachineId.NonNullValue<System.Guid>());
			var relatedEntity = await DbContext.VendingMachines.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrderForVendingMachine", request.EntityDto.CashStockOrderForVendingMachineId.NonNullValue<System.Guid>().ToString());
		}
		else if(request.EntityDto.CashStockOrderForVendingMachine is not null)
		{
			var relatedEntity = VendingMachineFactory.CreateEntity(request.EntityDto.CashStockOrderForVendingMachine);
			entityToCreate.CreateRefToCashStockOrderForVendingMachine(relatedEntity);
		}
		if(request.EntityDto.CashStockOrderReviewedByEmployeeId is not null)
		{
			var relatedKey = Cryptocash.Domain.EmployeeMetadata.CreateId(request.EntityDto.CashStockOrderReviewedByEmployeeId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.Employees.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrderReviewedByEmployee", request.EntityDto.CashStockOrderReviewedByEmployeeId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.CashStockOrderReviewedByEmployee is not null)
		{
			var relatedEntity = EmployeeFactory.CreateEntity(request.EntityDto.CashStockOrderReviewedByEmployee);
			entityToCreate.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.CashStockOrders.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}