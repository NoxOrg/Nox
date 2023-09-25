
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

public abstract record RefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<CreateRefTransactionToTransactionForCustomerCommand>
{
	public CreateRefTransactionToTransactionForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<DeleteRefTransactionToTransactionForCustomerCommand>
{
	public DeleteRefTransactionToTransactionForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefTransactionToTransactionForCustomerCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToTransactionForCustomerCommand(EntityKeyDto, null);

public partial class DeleteAllRefTransactionToTransactionForCustomerCommandHandler
	: RefTransactionToTransactionForCustomerCommandHandlerBase<DeleteAllRefTransactionToTransactionForCustomerCommand>
{
	public DeleteAllRefTransactionToTransactionForCustomerCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

public abstract class RefTransactionToTransactionForCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, Transaction>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToTransactionForCustomerCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefTransactionToTransactionForCustomerCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Transaction, Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Transactions.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Customer? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Customer, Nox.Types.AutoNumber>("Id", request.RelatedEntityKeyDto.keyId);
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

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}