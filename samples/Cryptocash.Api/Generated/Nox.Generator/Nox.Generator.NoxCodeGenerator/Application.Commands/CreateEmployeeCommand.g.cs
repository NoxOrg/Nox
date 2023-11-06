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

public partial record CreateEmployeeCommand(EmployeeCreateDto EntityDto, Nox.Types.CultureCode CultureCode) : IRequest<EmployeeKeyDto>;

internal partial class CreateEmployeeCommandHandler : CreateEmployeeCommandHandlerBase
{
	public CreateEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(dbContext, noxSolution,CashStockOrderFactory, entityFactory)
	{
	}
}


internal abstract class CreateEmployeeCommandHandlerBase : CommandBase<CreateEmployeeCommand,EmployeeEntity>, IRequestHandler <CreateEmployeeCommand, EmployeeKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> EntityFactory;
	protected readonly IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory;

	public CreateEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<Cryptocash.Domain.CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> CashStockOrderFactory,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		this.CashStockOrderFactory = CashStockOrderFactory;
	}

	public virtual async Task<EmployeeKeyDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);
		if(request.EntityDto.EmployeeReviewingCashStockOrderId is not null)
		{
			var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityDto.EmployeeReviewingCashStockOrderId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("EmployeeReviewingCashStockOrder", request.EntityDto.EmployeeReviewingCashStockOrderId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.EmployeeReviewingCashStockOrder is not null)
		{
			var relatedEntity = CashStockOrderFactory.CreateEntity(request.EntityDto.EmployeeReviewingCashStockOrder);
			entityToCreate.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Employees.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}