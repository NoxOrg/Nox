
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
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<CreateRefTransactionToTransactionForCustomerCommand>
{
	public CreateRefTransactionToTransactionForCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<DeleteRefTransactionToTransactionForCustomerCommand>
{
	public DeleteRefTransactionToTransactionForCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, null);

internal partial class DeleteAllRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<DeleteAllRefTransactionToTransactionForCustomerCommand>
{
	public DeleteAllRefTransactionToTransactionForCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefTransactionToTransactionForCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToTransactionForCustomerCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTransactionToTransactionForCustomerCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Customers.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTransactionForCustomer(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTransactionForCustomer(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToTransactionForCustomer();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}