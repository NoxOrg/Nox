﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllCustomerRelatedTransactionsForCustomerCommand(CustomerKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllCustomerRelatedTransactionsForCustomerCommandHandler : DeleteAllCustomerRelatedTransactionsForCustomerCommandHandlerBase
{
	public DeleteAllCustomerRelatedTransactionsForCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllCustomerRelatedTransactionsForCustomerCommandHandlerBase : CommandBase<DeleteAllCustomerRelatedTransactionsForCustomerCommand, TransactionEntity>, IRequestHandler <DeleteAllCustomerRelatedTransactionsForCustomerCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllCustomerRelatedTransactionsForCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllCustomerRelatedTransactionsForCustomerCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.Customers.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.Transactions;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.Transactions.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}