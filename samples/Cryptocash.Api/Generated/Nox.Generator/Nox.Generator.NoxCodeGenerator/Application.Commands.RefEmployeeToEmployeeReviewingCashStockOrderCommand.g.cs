﻿
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public abstract record RefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToEmployeeReviewingCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler: RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand>
{
	public CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToEmployeeReviewingCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler: RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommand>
{
	public DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<TRequest>: CommandBase<TRequest, Employee>, 
	IRequestHandler <TRequest, bool> where TRequest : RefEmployeeToEmployeeReviewingCashStockOrderCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Employee, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<CashStockOrder, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToEmployeeReviewingCashStockOrder(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}