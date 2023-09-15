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

public partial class CreateCashStockOrderCommandHandler: CommandBase<CreateCashStockOrderCommand,CashStockOrder>, IRequestHandler <CreateCashStockOrderCommand, CashStockOrderKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<CashStockOrder,CashStockOrderCreateDto> _entityFactory;
    private readonly IEntityFactory<VendingMachine,VendingMachineCreateDto> _vendingmachinefactory;
    private readonly IEntityFactory<Employee,EmployeeCreateDto> _employeefactory;

	public CreateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
        IEntityFactory<VendingMachine,VendingMachineCreateDto> vendingmachinefactory,
        IEntityFactory<Employee,EmployeeCreateDto> employeefactory,
        IEntityFactory<CashStockOrder,CashStockOrderCreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;        
        _vendingmachinefactory = vendingmachinefactory;        
        _employeefactory = employeefactory;
	}

	public async Task<CashStockOrderKeyDto> Handle(CreateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.CashStockOrderForVendingMachine is not null)
		{ 
			var relatedEntity = _vendingmachinefactory.CreateEntity(request.EntityDto.CashStockOrderForVendingMachine);
			entityToCreate.CreateRefToVendingMachineCashStockOrderForVendingMachine(relatedEntity);
		}
		if(request.EntityDto.CashStockOrderReviewedByEmployee is not null)
		{ 
			var relatedEntity = _employeefactory.CreateEntity(request.EntityDto.CashStockOrderReviewedByEmployee);
			entityToCreate.CreateRefToEmployeeCashStockOrderReviewedByEmployee(relatedEntity);
		}
					
		OnCompleted(request, entityToCreate);
		_dbContext.CashStockOrders.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entityToCreate.Id.Value);
	}
}