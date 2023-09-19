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

public partial class CreateEmployeeCommandHandler: CreateEmployeeCommandHandlerBase
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


public abstract class CreateEmployeeCommandHandlerBase: CommandBase<CreateEmployeeCommand,Employee>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
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
		if(request.EntityDto.EmployeeReviewingCashStockOrder is not null)
		{
			var relatedEntity = _cashstockorderfactory.CreateEntity(request.EntityDto.EmployeeReviewingCashStockOrder);
			entityToCreate.CreateRefToCashStockOrderEmployeeReviewingCashStockOrder(relatedEntity);
		}

		OnCompleted(request, entityToCreate);
		_dbContext.Employees.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}