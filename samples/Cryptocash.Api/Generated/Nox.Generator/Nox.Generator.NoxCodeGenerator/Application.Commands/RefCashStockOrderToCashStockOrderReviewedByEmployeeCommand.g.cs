
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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public abstract record RefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(CashStockOrderKeyDto EntityKeyDto, EmployeeKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(CashStockOrderKeyDto EntityKeyDto, EmployeeKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandlerBase<CreateRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand>
{
	public CreateRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(CashStockOrderKeyDto EntityKeyDto, EmployeeKeyDto RelatedEntityKeyDto)
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandlerBase<DeleteRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand>
{
	public DeleteRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(CashStockOrderKeyDto EntityKeyDto)
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler
	: RefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandlerBase<DeleteAllRefCashStockOrderToCashStockOrderReviewedByEmployeeCommand>
{
	public DeleteAllRefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandlerBase<TRequest> : CommandBase<TRequest, CashStockOrderEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCashStockOrderToCashStockOrderReviewedByEmployeeCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCashStockOrderToCashStockOrderReviewedByEmployeeCommandHandlerBase(
		CryptocashDbContext dbContext,
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
		var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Employee? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.EmployeeMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Employees.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCashStockOrderReviewedByEmployee(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCashStockOrderReviewedByEmployee(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCashStockOrderReviewedByEmployee();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}