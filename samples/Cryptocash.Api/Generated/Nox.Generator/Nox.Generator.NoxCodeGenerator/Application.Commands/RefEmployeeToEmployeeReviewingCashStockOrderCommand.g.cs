
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using EmployeeEntity = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Commands;

public abstract record RefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToEmployeeReviewingCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler
	: RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand>
{
	public CreateRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToEmployeeReviewingCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler
	: RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommand>
{
	public DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefEmployeeToEmployeeReviewingCashStockOrderCommand(EmployeeKeyDto EntityKeyDto)
	: RefEmployeeToEmployeeReviewingCashStockOrderCommand(EntityKeyDto, null);

internal partial class DeleteAllRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler
	: RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<DeleteAllRefEmployeeToEmployeeReviewingCashStockOrderCommand>
{
	public DeleteAllRefEmployeeToEmployeeReviewingCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase<TRequest> : CommandBase<TRequest, EmployeeEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEmployeeToEmployeeReviewingCashStockOrderCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefEmployeeToEmployeeReviewingCashStockOrderCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Employees.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.CashStockOrder? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.CashStockOrders.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToEmployeeReviewingCashStockOrder(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToEmployeeReviewingCashStockOrder(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToEmployeeReviewingCashStockOrder();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}