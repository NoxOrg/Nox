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
using FluentValidation;
using Microsoft.Extensions.Logging;

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

	protected CreateEmployeeCommandHandlerBase(
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

		var entityToCreate = await EntityFactory.CreateEntityAsync(request.EntityDto);
		if(request.EntityDto.CashStockOrderId is not null)
		{
			var relatedKey = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityDto.CashStockOrderId.NonNullValue<System.Int64>());
			var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKey);
			if(relatedEntity is not null)
				entityToCreate.CreateRefToCashStockOrder(relatedEntity);
			else
				throw new RelatedEntityNotFoundException("CashStockOrder", request.EntityDto.CashStockOrderId.NonNullValue<System.Int64>().ToString());
		}
		else if(request.EntityDto.CashStockOrder is not null)
		{
			var relatedEntity = await CashStockOrderFactory.CreateEntityAsync(request.EntityDto.CashStockOrder);
			entityToCreate.CreateRefToCashStockOrder(relatedEntity);
		}

		await OnCompletedAsync(request, entityToCreate);
		DbContext.Employees.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new EmployeeKeyDto(entityToCreate.Id.Value);
	}
}

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
		RuleFor(x => x.EntityDto.EmployeePhoneNumbers)
			.Must(owned => owned.TrueForAll(x => x.Id == null))
			.WithMessage("EmployeePhoneNumbers.Id must be null as it is auto generated.");
    }
}