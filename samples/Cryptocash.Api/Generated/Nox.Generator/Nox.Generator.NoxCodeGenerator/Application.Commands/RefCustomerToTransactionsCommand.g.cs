
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

public abstract record RefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class CreateRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<CreateRefCustomerToTransactionsCommand>
{
	public CreateRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCustomerToTransactionsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTransaction(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToTransactions(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, List<TransactionKeyDto> RelatedEntitiesKeysDtos)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class UpdateRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<UpdateRefCustomerToTransactionsCommand>
{
	public UpdateRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCustomerToTransactionsCommand request)
    {
		var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<Cryptocash.Domain.Transaction>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetTransaction(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Transactions).LoadAsync();
		entity.UpdateRefToTransactions(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto, TransactionKeyDto RelatedEntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class DeleteRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteRefCustomerToTransactionsCommand>
{
	public DeleteRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCustomerToTransactionsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetTransaction(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToTransactions(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCustomerToTransactionsCommand(CustomerKeyDto EntityKeyDto)
	: RefCustomerToTransactionsCommand(EntityKeyDto);

internal partial class DeleteAllRefCustomerToTransactionsCommandHandler
	: RefCustomerToTransactionsCommandHandlerBase<DeleteAllRefCustomerToTransactionsCommand>
{
	public DeleteAllRefCustomerToTransactionsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCustomerToTransactionsCommand request)
    {
        var entity = await GetCustomer(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Transactions).LoadAsync();
		entity.DeleteAllRefToTransactions();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCustomerToTransactionsCommandHandlerBase<TRequest> : CommandBase<TRequest, CustomerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCustomerToTransactionsCommand
{
	public AppDbContext DbContext { get; }

	public RefCustomerToTransactionsCommandHandlerBase(
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

	protected async Task<CustomerEntity?> GetCustomer(CustomerKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CustomerMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Customers.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Transaction?> GetTransaction(TransactionKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.TransactionMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Transactions.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CustomerEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}