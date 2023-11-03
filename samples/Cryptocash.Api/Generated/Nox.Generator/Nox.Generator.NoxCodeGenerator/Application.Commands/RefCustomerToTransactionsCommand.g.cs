
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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Commands;

public abstract record RefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<CreateRefCustomerToTransactionsCommand>
{
	public CreateRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteRefCustomerToTransactionsCommand>
{
	public DeleteRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteAllRefCustomerToTransactionsCommand>
{
	public DeleteAllRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToTransactionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToTransactionsCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToTransactionsCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Customers.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Transaction? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.TransactionMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Transactions.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToTransactions(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToTransactions(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.Transactions).LoadAsync();
				entity.DeleteAllRefToTransactions();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}