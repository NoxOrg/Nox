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
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

internal partial class CreateEmployeeCommandHandler: CreateEmployeeCommandHandlerBase
{
	public CreateEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> entityFactory,
		IServiceProvider serviceProvider)
		: base(dbContext, noxSolution,cashstockorderfactory, entityFactory, serviceProvider)
	{
	}
}


internal abstract class CreateEmployeeCommandHandlerBase: CommandBase<CreateEmployeeCommand,Employee>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> _entityFactory;
	private readonly IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _cashstockorderfactory;

	public CreateEmployeeCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<Employee, EmployeeCreateDto, EmployeeUpdateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		_cashstockorderfactory = cashstockorderfactory;
	}

	public virtual async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.EmployeeReviewingCashStockOrderId is not null)
		{
			var relatedKey = CreateNoxTypeForKey<CashStockOrder, Nox.Types.AutoNumber>("Id", request.EntityDto.EmployeeReviewingCashStockOrderId);
			var relatedEntity = await _dbContext.CashStockOrders.FindAsync(relatedKey);
			if(relatedEntity is not null && relatedEntity.DeletedAtUtc == null)
				entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
		}
		else if(request.EntityDto.EmployeeReviewingCashStockOrder is not null)
		{
			var relatedEntity = _cashstockorderfactory.CreateEntity(request.EntityDto.EmployeeReviewingCashStockOrder);
			entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Employees.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}