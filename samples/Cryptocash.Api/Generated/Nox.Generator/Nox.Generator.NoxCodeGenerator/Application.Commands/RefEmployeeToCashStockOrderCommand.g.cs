
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

public abstract record RefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<CreateRefEmployeeToCashStockOrderCommand>
{
	public CreateRefEmployeeToCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto, CashStockOrderKeyDto RelatedEntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<DeleteRefEmployeeToCashStockOrderCommand>
{
	public DeleteRefEmployeeToCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefEmployeeToCashStockOrderCommand(EmployeeKeyDto EntityKeyDto)
	: RefEmployeeToCashStockOrderCommand(EntityKeyDto, null);

internal partial class DeleteAllRefEmployeeToCashStockOrderCommandHandler
	: RefEmployeeToCashStockOrderCommandHandlerBase<DeleteAllRefEmployeeToCashStockOrderCommand>
{
	public DeleteAllRefEmployeeToCashStockOrderCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefEmployeeToCashStockOrderCommandHandlerBase<TRequest> : CommandBase<TRequest, EmployeeEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEmployeeToCashStockOrderCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefEmployeeToCashStockOrderCommandHandlerBase(
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
		await OnExecutingAsync(request);
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
				entity.CreateRefToCashStockOrder(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCashStockOrder(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCashStockOrder();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}