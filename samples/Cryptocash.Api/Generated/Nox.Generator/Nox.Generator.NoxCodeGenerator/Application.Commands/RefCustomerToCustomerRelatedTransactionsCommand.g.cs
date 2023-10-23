﻿
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

public abstract record RefCustomerToCustomerRelatedTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCustomerToCustomerRelatedTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedTransactionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCustomerToCustomerRelatedTransactionsCommandHandler
	: RefCustomerToCustomerRelatedTransactionsCommandHandlerBase<CreateRefCustomerToCustomerRelatedTransactionsCommand>
{
	public CreateRefCustomerToCustomerRelatedTransactionsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCustomerToCustomerRelatedTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToCustomerRelatedTransactionsCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCustomerToCustomerRelatedTransactionsCommandHandler
	: RefCustomerToCustomerRelatedTransactionsCommandHandlerBase<DeleteRefCustomerToCustomerRelatedTransactionsCommand>
{
	public DeleteRefCustomerToCustomerRelatedTransactionsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCustomerToCustomerRelatedTransactionsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToCustomerRelatedTransactionsCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCustomerToCustomerRelatedTransactionsCommandHandler
	: RefCustomerToCustomerRelatedTransactionsCommandHandlerBase<DeleteAllRefCustomerToCustomerRelatedTransactionsCommand>
{
	public DeleteAllRefCustomerToCustomerRelatedTransactionsCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCustomerToCustomerRelatedTransactionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToCustomerRelatedTransactionsCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCustomerToCustomerRelatedTransactionsCommandHandlerBase(
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
				entity.CreateRefToCustomerRelatedTransactions(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCustomerRelatedTransactions(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CustomerRelatedTransactions).LoadAsync();
				entity.DeleteAllRefToCustomerRelatedTransactions();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}