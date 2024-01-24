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
using Nox.Exceptions;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using TransactionEntity = Cryptocash.Domain.Transaction;

namespace Cryptocash.Application.Commands;

public abstract record RefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class CreateRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<CreateRefTransactionToCustomerCommand>
{
	public CreateRefTransactionToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefTransactionToCustomerCommand request)
    {
		var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto, CustomerKeyDto RelatedEntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class DeleteRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<DeleteRefTransactionToCustomerCommand>
{
	public DeleteRefTransactionToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefTransactionToCustomerCommand request)
    {
        var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetTransactionForCustomer(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Customer", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCustomer(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefTransactionToCustomerCommand(TransactionKeyDto EntityKeyDto)
	: RefTransactionToCustomerCommand(EntityKeyDto);

internal partial class DeleteAllRefTransactionToCustomerCommandHandler
	: RefTransactionToCustomerCommandHandlerBase<DeleteAllRefTransactionToCustomerCommand>
{
	public DeleteAllRefTransactionToCustomerCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefTransactionToCustomerCommand request)
    {
        var entity = await GetTransaction(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Transaction",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCustomer();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefTransactionToCustomerCommandHandlerBase<TRequest> : CommandBase<TRequest, TransactionEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefTransactionToCustomerCommand
{
	public AppDbContext DbContext { get; }

	public RefTransactionToCustomerCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<TransactionEntity?> GetTransaction(TransactionKeyDto entityKeyDto)
	{
		var keyId = Dto.TransactionMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.Transactions.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Customer?> GetTransactionForCustomer(CustomerKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.CustomerMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, TransactionEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}