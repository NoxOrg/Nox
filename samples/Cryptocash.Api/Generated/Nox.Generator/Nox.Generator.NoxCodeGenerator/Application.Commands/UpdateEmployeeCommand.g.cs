﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public record UpdateEmployeeCommand(System.Int64 keyId, EmployeeUpdateDto EntityDto, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest<EmployeeKeyDto?>;

internal partial class UpdateEmployeeCommandHandler : UpdateEmployeeCommandHandlerBase
{
	public UpdateEmployeeCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory) 
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateEmployeeCommandHandlerBase : CommandBase<UpdateEmployeeCommand, EmployeeEntity>, IRequestHandler<UpdateEmployeeCommand, EmployeeKeyDto?>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> _entityFactory;

	public UpdateEmployeeCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<EmployeeEntity, EmployeeCreateDto, EmployeeUpdateDto> entityFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<EmployeeKeyDto?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.keyId);

		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		var employeeReviewingCashStockOrderKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityDto.EmployeeReviewingCashStockOrderId);
		var employeeReviewingCashStockOrderEntity = await DbContext.CashStockOrders.FindAsync(employeeReviewingCashStockOrderKey);
						
		if(employeeReviewingCashStockOrderEntity is not null)
			entity.CreateRefToEmployeeReviewingCashStockOrder(employeeReviewingCashStockOrderEntity);
		else
			throw new RelatedEntityNotFoundException("EmployeeReviewingCashStockOrder", request.EntityDto.EmployeeReviewingCashStockOrderId.ToString());

		_entityFactory.UpdateEntity(entity, request.EntityDto, request.CultureCode);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new EmployeeKeyDto(entity.Id.Value);
	}
}