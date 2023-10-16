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
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record CreateEmployeeCommand(EmployeeCreateDto EntityDto) : IRequest<EmployeeKeyDto>;

internal partial class CreateEmployeeCommandHandler : CreateEmployeeCommandHandlerBase
{
	public CreateEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(dbContext, noxSolution,cashstockorderfactory, entityFactory)
	{
	}
}


internal abstract class CreateEmployeeCommandHandlerBase : CommandBase<CreateEmployeeCommand,EmployeeEntity>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	private readonly CryptocashDbContext _dbContext;
	private readonly IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> _entityFactory;
	private readonly IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _cashstockorderfactory;

	public CreateEmployeeCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> cashstockorderfactory,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory) : base(noxSolution)
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
			var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityDto.EmployeeReviewingCashStockOrderId.NonNullValue<System.Int64>());
			var relatedEntity = await _dbContext.CashStockOrders.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("EmployeeReviewingCashStockOrder", request.EntityDto.EmployeeReviewingCashStockOrderId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.EmployeeReviewingCashStockOrder is not null)
		{
			var relatedEntity = _cashstockorderfactory.CreateEntity(request.EntityDto.EmployeeReviewingCashStockOrder);
			entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		_dbContext.Employees.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}